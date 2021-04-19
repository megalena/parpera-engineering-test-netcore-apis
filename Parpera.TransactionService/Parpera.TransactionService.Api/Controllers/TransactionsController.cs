using Microsoft.AspNetCore.Mvc;
using Parpera.TransactionService.Domain;
using System;
using System.Collections.Generic;

namespace Parpera.TransactionService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // GET: api/<TransactionsController>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return new Transaction[]
            {
                new Transaction()
                {
                    Id = 1, DateTime = DateTime.Parse("2020-03-30 23:53:23"), Description = "Bank Deposit", Amount = 500M, Status = TransactionStatus.Completed
                }
            };
        }
    }
}
