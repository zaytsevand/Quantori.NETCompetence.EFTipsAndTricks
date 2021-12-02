using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Quantori.NETCompetence.EFTipsAndTricks.Models;

public class DetailedAddress : Address
{
    public string? Country { get; init; }
    public string? State { get; init; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? Zip { get; init; }

    public override string ToString()
    {
        return $"{Zip}, {Country}, {State}, {City}, {Street}";
    }
}

public class Address
{
    public string? FullAddress { get; set; }

    public override string ToString()
    {
        return FullAddress ?? string.Empty;
    }
}