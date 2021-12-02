namespace Quantori.NETCompetence.EFTipsAndTricks.Examples.DTOs;

public class Address
{
    public string? FullAddress { get; set; }

    public override string ToString()
    {
        return FullAddress ?? string.Empty;
    }
}