using BellInterviewClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellInterviewServer.Models
{
    public interface IClientRepository
    {
        List<Client> GetClients();
        Task<Client> GetClientByID(Guid clientId);
        Task<bool> InsertClient(Client client);
        Task<bool> DeleteClient(Guid clientId);
        Task<bool> UpdateClient(Client client, Guid clientId);
    }
}
