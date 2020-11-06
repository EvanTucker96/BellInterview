using BellInterviewClient.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BellInterviewClient.Services
{
    class RestClientService
    {
        const string API_URI = "http://localhost:5000/api/ClientsController/";

        public async Task<bool> CreateClientAsync(Client client)
        {
            var httpClient = new HttpClient();

            var result = await httpClient.PostAsync(API_URI, new JSONContent(client));

            return result.IsSuccessStatusCode;
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            var httpClient = new HttpClient();

            var result = await httpClient.GetAsync(API_URI);
            
        }

        public async Client GetClientAsync(Client client)
        {
            var httpClient = new HttpClient();

            var result = await httpClient.GetAsync(API_URI + client.clientId);
        }

        public async
    }
}
