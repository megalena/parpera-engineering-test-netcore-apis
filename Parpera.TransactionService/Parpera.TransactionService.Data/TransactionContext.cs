using Microsoft.EntityFrameworkCore;
using Parpera.TransactionService.Domain;

namespace Parpera.TransactionService.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
