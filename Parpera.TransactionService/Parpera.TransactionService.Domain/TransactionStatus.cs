using System.Text.Json.Serialization;

namespace Parpera.TransactionService.Domain
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionStatus
    {
        Pending,

        Completed,

        Cancelled
    }
}
