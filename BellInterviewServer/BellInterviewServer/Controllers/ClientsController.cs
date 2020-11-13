using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BellInterviewClient;
using BellInterviewServer.SQLServer.Context;
using BellInterviewServer.Models;

namespace BellInterviewServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ServerAPIContext _context;
        private readonly ClientRepository _clientRepository;

        public ClientsController(ServerAPIContext context, ClientRepository clientRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            //return await _context.Clients.ToListAsync();
            return _clientRepository.GetClients();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<Client> GetClient(Guid id)
        {
            //var client = await _context.Clients.FindAsync(id);
            var client = await _clientRepository.GetClientByID(id);

            return client;
            
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(Guid id, Client client)
        {
           if (await _clientRepository.UpdateClient(client, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostClient(Client client)
        {
            var validator = new ClientValidator();
            var result = validator.Validate(client);

            if (result.IsValid)
            {
                if (await _clientRepository.InsertClient(client)) 
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                //to do: Log error from result.Errors
                return BadRequest();
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(Guid id)
        {
           if (await _clientRepository.DeleteClient(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
