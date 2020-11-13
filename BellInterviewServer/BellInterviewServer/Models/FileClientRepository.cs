using BellInterviewClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace BellInterviewServer.Models
{
    public class FileClientRepository : IClientRepository
    {
        public FileClientRepository()
        {
            //TODO: Implement File Based Repository.
        }

        public Task<bool> DeleteClient(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientByID(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateClient(Client client, Guid clientId)
        {
            throw new NotImplementedException();
        }
    }
}
