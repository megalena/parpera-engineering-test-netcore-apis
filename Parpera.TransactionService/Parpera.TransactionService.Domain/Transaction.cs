using System;
using System.Text.Json.Serialization;

namespace Parpera.TransactionService.Domain
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransactionStatus Status { get; set; }
    }
}
