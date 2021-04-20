using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parpera.TransactionService.Data;
using Parpera.TransactionService.Domain;
using System;

namespace Parpera.TransactionService.Api.Services
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new TransactionContext(serviceProvider.GetRequiredService<DbContextOptions<TransactionContext>>());
            context.Transactions.AddRange(
                new Transaction()
                {
                    Id = 1,
                    DateTime = DateTime.Parse("2020-03-30 23:53:23"),
                    Description = "Bank Deposit",
                    Amount = 500.00M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 2,
                    DateTime = DateTime.Parse("2020-04-01 12:47:23"),
                    Description = "Amazon Online",
                    Amount = -30.00M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 3,
                    DateTime = DateTime.Parse("2020-04-09 16:26:23"),
                    Description = "Refund",
                    Amount = 30.00M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 4,
                    DateTime = DateTime.Parse("2020-06-15 18:17:23"),
                    Description = "Country Railways",
                    Amount = -167.78M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 5,
                    DateTime = DateTime.Parse("2020-08-16 21:06:23"),
                    Description = "Mini Mart",
                    Amount = -56.43M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 6,
                    DateTime = DateTime.Parse("2020-08-23 17:39:23"),
                    Description = "Mini Mart",
                    Amount = -23.76M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 7,
                    DateTime = DateTime.Parse("2020-09-06 07:33:23"),
                    Description = "Apple Store",
                    Amount = -2000.00M,
                    Status = TransactionStatus.Cancelled
                },
                new Transaction()
                {
                    Id = 8,
                    DateTime = DateTime.Parse("2020-09-06 10:32:23"),
                    Description = "Google Subscription",
                    Amount = -15.00M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 9,
                    DateTime = DateTime.Parse("2020-09-07 21:52:23"),
                    Description = "ATM withdrawal",
                    Amount = -20.00M,
                    Status = TransactionStatus.Completed
                },
                new Transaction()
                {
                    Id = 10,
                    DateTime = DateTime.Parse("2020-09-08 09:02:23"),
                    Description = "Transfer to James",
                    Amount = -20.00M,
                    Status = TransactionStatus.Pending
                },
                new Transaction()
                {
                    Id = 11,
                    DateTime = DateTime.Parse("2020-09-08 16:34:23"),
                    Description = "Bank Deposit",
                    Amount = 500.00M,
                    Status = TransactionStatus.Completed
                });
            context.SaveChanges();
        }
    }
}
