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
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Client>> Get()
        {
            using var appContext = new QuotesDBContext();
            var list = await appContext.clients.ToListAsync();
            return await Task.FromResult(list);
        }
        [HttpGet("{Id}")]
        public Client Get(Guid Id)
        {
            using (QuotesDBContext dbContext = new QuotesDBContext())
            {
                return dbContext.clients.FirstOrDefault(e => e.Id == Id);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using var appContext = new QuotesDBContext();
            await appContext.clients.AddAsync(client);
            await appContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Client client)
        {
            using var appContext = new QuotesDBContext();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var exist = await appContext.clients.FindAsync(id);
            if (exist == null)
            {
                return NotFound();
            }
            if((exist.Balance += client.Balance) < 0)
            {
                return BadRequest();
            }
            else
            {
                exist.Balance += client.Balance;
            }
            var result = await appContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            using var appContext = new QuotesDBContext();
            var exist = await appContext.clients.FindAsync(id);
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
