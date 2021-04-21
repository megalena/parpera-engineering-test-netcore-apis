using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parpera.TransactionService.Api.Controllers;
using Parpera.TransactionService.Data;
using Parpera.TransactionService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Parpera.TransactionService.UnitTests
{
    public class TransactionsControllerUnitTests
    {
        [Fact]
        public void Get_Returns_ListOfTransactionsOrderedByDateTimeDescending()
        {
            // Arrange
            var options = SetupTestData("GetTransactions");

            using var context = new TransactionContext(options);
            var controller = new TransactionsController(context);

            // Act
            var result = controller.Get();

            //Assert
            Assert.Equal(3, result.Count());

            var resultArray = result.ToArray();
            Assert.Equal(2, resultArray[0].Id);
            Assert.Equal(3, resultArray[1].Id);
            Assert.Equal(1, resultArray[2].Id);
        }

        [Fact]
        public async Task UpdateStatus_ReturnsBadRequest_WhenStatusInvalid()
        {
            // Arrange
            var options = SetupTestData("UpdateStatus_StatusInvalid");

            using var context = new TransactionContext(options);
            var controller = new TransactionsController(context);

            // Act
            var result = await controller.UpdateStatus(1, "Invalid");

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateStatus_ReturnsBadRequest_WhenIdInvalid()
        {
            // Arrange
            var options = SetupTestData("UpdateStatus_IdInvalid");

            using var context = new TransactionContext(options);
            var controller = new TransactionsController(context);

            // Act
            var result = await controller.UpdateStatus(4, "Cancelled");

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateStatus_UpdatesStatus_WhenValid()
        {
            // Arrange
            var options = SetupTestData("UpdateStatus_Valid");

            using var context = new TransactionContext(options);
            var controller = new TransactionsController(context);

            // Act
            var result = await controller.UpdateStatus(1, "Cancelled");

            //Assert
            Assert.IsType<OkResult>(result);
            Assert.Equal(TransactionStatus.Cancelled, context.Transactions.FirstOrDefault(t => t.Id == 1).Status);
        }

        private static DbContextOptions<TransactionContext> SetupTestData(string databaseName)
        {
            var options = new DbContextOptionsBuilder<TransactionContext>().UseInMemoryDatabase(databaseName).Options;
            using (var context = new TransactionContext(options))
            {
                if (context.Transactions.Any())
                {
                    return options;
                }

                context.Transactions.AddRange(
                    new Transaction()
                    {
                        Id = 1,
                        DateTime = DateTime.Parse("2021-01-01 10:11:12"),
                        Description = "Bank Deposit",
                        Amount = 10.00M,
                        Status = TransactionStatus.Pending
                    },
                    new Transaction()
                    {
                        Id = 2,
                        DateTime = DateTime.Parse("2021-03-03 12:13:14"),
                        Description = "Transfer",
                        Amount = -10.00M,
                        Status = TransactionStatus.Completed
                    },
                    new Transaction()
                    {
                        Id = 3,
                        DateTime = DateTime.Parse("2021-02-02 15:16:17"),
                        Description = "Refund",
                        Amount = 20.00M,
                        Status = TransactionStatus.Cancelled
                    });
                context.SaveChanges();
            }

            return options;
        }
    }
}
