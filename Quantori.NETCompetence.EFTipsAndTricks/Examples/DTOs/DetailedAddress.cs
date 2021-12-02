namespace Quantori.NETCompetence.EFTipsAndTricks.Examples.DTOs;

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