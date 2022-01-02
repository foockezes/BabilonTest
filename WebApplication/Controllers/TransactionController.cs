using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public static decimal MonOperation { get; set; }
        [HttpGet]
        public async Task<List<Transaction>> Get()
        {
            using var appContext = new QuotesDBContext();
            var list = await appContext.transactions.ToListAsync();
            return await Task.FromResult(list);
        }
        [HttpGet("{Id}")]
        public Transaction Get(Guid Id)
        {
            using (QuotesDBContext dbContext = new QuotesDBContext())
            {
                return dbContext.transactions.FirstOrDefault(e => e.ClientId == Id);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using var appContext = new QuotesDBContext();
            await appContext.transactions.AddAsync(transaction);
            await appContext.SaveChangesAsync();
            transaction.Sum = MonOperation;
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Transaction transaction)
        {
            using var appContext = new QuotesDBContext();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var exist = await appContext.transactions.FindAsync(id);
            if (exist == null)
            {
                return NotFound();
            }
            exist.Sum = transaction.Sum;
            var result = await appContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            using var appContext = new QuotesDBContext();
            var exist = await appContext.transactions.FindAsync(id);
            if (exist == null)
            {
                return BadRequest();
            }
            appContext.Remove(exist);
            var result = await appContext.SaveChangesAsync();
            return Ok();
        }

      }
}
