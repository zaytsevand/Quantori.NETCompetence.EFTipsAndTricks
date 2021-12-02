using System.ComponentModel.DataAnnotations;

namespace Quantori.NETCompetence.EFTipsAndTricks.Models;

public class EntityBase<TKey> where TKey: IComparable<TKey>, IEquatable<TKey>
{
    [Key] public TKey Id { get; init; }
}