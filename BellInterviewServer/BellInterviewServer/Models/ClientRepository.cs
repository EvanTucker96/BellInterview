using BellInterviewClient;
using BellInterviewServer.SQLServer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellInterviewServer.Models
{
    public class ClientRepository : IClientRepository
    {
        private ServerAPIContext _context;
        public ClientRepository(ServerAPIContext context)
        {
            _context = context;
        }
        public async Task<Client> GetClientByID(Guid clientId)
        {
            return await _context.Clients.FindAsync(clientId);
        }
        public async Task<bool> DeleteClient(Guid clientId)
        {
            try
            {
                Client client = _context.Clients.Find(clientId);
                _context.Clients.Remove(client);
                return ((await _context.SaveChangesAsync()) > 0);
            }
            catch (Exception ex)
            {
                //implement logging
                return false;
            }
            
        }
        public async Task<bool> UpdateClient(Client client, Guid clientId)
        {
            try
            {
                _context.Entry(client).State = EntityState.Modified;
                return ((await _context.SaveChangesAsync()) > 0);
            }
            catch(Exception ex)
            {
                //implement logging
                return false;
            }
            
        }

        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public async Task<bool> InsertClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                return ((await _context.SaveChangesAsync()) > 0);
            }
            catch (Exception ex)
            {
                //implement logging
                return false;
            }
            
        }
    }
}
