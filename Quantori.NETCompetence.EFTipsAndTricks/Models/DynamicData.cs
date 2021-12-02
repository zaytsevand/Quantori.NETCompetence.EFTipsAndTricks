using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Quantori.NETCompetence.EFTipsAndTricks.Models;

public record DynamicData([JsonProperty("$type")]string Type, [JsonProperty("$data")]JObject Data);