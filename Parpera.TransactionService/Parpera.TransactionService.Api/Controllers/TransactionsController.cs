using Microsoft.AspNetCore.Mvc;
using Parpera.TransactionService.Data;
using Parpera.TransactionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parpera.TransactionService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionContext _context;

        public TransactionsController(TransactionContext context)
        {
            _context = context;
        }

        // GET: api/<TransactionsController>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _context.Transactions.OrderByDescending(t => t.DateTime);
        }
    }
}
