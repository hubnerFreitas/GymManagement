using System.Text.Json.Serialization;

namespace GymManagement.Contracts.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionType
    {
        Free,
        Starter,
        Pro
    }
}
