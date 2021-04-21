using Microsoft.AspNetCore.Mvc;
using Parpera.TransactionService.Data;
using Parpera.TransactionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPatch]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            if (!Enum.TryParse<TransactionStatus>(status, out  var statusValue))
            {
                return BadRequest();
            }

            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return BadRequest();
            }

            _context.Transactions.Attach(transaction);
            transaction.Status = statusValue;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
