using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Quantori.NETCompetence.EFTipsAndTricks.Models;

public class User : EntityBase<Guid>
{
    public User()
    {
        Id = Guid.NewGuid();
    }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public DynamicData? AddressData { get; set; }

    [NotMapped, JsonIgnore]
    public object? StructuredAddress
    {
        get => AddressData!.Data.ToObject(Type.GetType(AddressData.Type)!);
        set => AddressData = new DynamicData(value!.GetType().FullName!, JObject.FromObject(value));
    }
}