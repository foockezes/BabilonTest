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
            var list = await appContext.Clients.ToListAsync();
            return await Task.FromResult(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            client.Id = Guid.NewGuid();
            using var appContext = new QuotesDBContext();
            await appContext.Clients.AddAsync(client);
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
            var exist = await appContext.Clients.FindAsync(id);
            if (exist == null)
            {
                return NotFound();
            }
            exist.Name = client.Name;
            exist.LastName = client.LastName;
            exist.Identification = true;
            exist.AccountCode = client.AccountCode;
            var result = await appContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            using var appContext = new QuotesDBContext();
            var exist = await appContext.Clients.FindAsync(id);
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
