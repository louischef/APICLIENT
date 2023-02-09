using APIWEB.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;
using HttpResponseMessage = System.Net.Http.HttpResponseMessage;

namespace APICLIENT.Services
{
    public class WSService : IService
    {
        private HttpClient client;

        public WSService(string uri)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public WSService()
        {
        }

        public async Task<List<Serie>> GetSeriesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> GetSerieAsync(string nomControlleur, int idSerie)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(nomControlleur+idSerie);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateSerieAsync(string nomControlleur, Serie seriemodif)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(nomControlleur + "/" + seriemodif.Serieid, seriemodif);
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public async Task<bool> CreateSerieAsync(string nomControlleur, Serie serieACreer)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(nomControlleur, serieACreer);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }          
        }

        public async Task<bool> DeleteSerieAsyc(string nomControlleur, int idSerie)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(nomControlleur+idSerie);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
