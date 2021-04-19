using System;

namespace Parpera.TransactionService.Domain
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public TransactionStatus Status { get; set; }
    }
}
