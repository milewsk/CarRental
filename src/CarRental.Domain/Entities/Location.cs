using System.ComponentModel.DataAnnotations;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Entities;

public class Location : Entity
{
    // Properties
    public string Name { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }

    // Relationships
    public ICollection<Asset> Assets { get; set; } = new List<Asset>();

    // Constructors
    public Location(string name, string country, string address)
    {
        Name = name;
        Country = country;
        Address = address;
    } 
    
    public Location(string name, string country, string address, ICollection<Asset> assets)
    {
        Name = name;
        Country = country;
        Address = address;
        Assets = assets;
    }
}