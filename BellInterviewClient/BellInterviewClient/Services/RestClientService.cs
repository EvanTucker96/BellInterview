﻿using BellInterviewClient.Utility;
using Newtonsoft.Json;
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

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Client>>(response);
            }
            else
            {
                //to do: error for failed response.
                return null;
            }

            
        }

        public async Task<Client> GetClientAsync(Client client)
        {
            var httpClient = new HttpClient();

            var result = await httpClient.GetAsync(API_URI + client.clientId);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(response);
            }
            else
            {
                //to do: error for failed response.
                return null;
            }
        }

    }
}
