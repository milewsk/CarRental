using System.Reflection;
namespace CarRental.Application.Common.Extensions;

public static class MappingHelper
{
    public static TDestination? Map<TSource, TDestination>(TSource sourceObject, TDestination? destinationObject)
        where TDestination : class 
    {
        if (sourceObject == null || destinationObject == null)
            return null;

        var sourceObjectType = sourceObject.GetType();
        var sourcePropList = sourceObjectType.GetProperties();

        var destinationObjectType = destinationObject.GetType();
        var destinationPropList = destinationObjectType.GetProperties();

        foreach (var sourcePropInfo in sourcePropList)
        {
            foreach (var destinationPropInfo in destinationPropList)
            {
                if (sourcePropInfo.Name == destinationPropInfo.Name &&
                    !sourcePropInfo.GetGetMethod()!.IsVirtual && !destinationPropInfo.GetGetMethod()!.IsVirtual)
                {
                    destinationPropInfo.SetValue(destinationObject, sourcePropInfo.GetValue(sourceObject, null), null);
                    break;
                }
            }
        }

        return destinationObject;
    }
}