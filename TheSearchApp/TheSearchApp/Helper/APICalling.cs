using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TheSearchApp.Helper
{
    public class APICalling
    {
        public APICalling() : base()
        {

        }

        public async Task<string> SearchMovie(int movie_id, string apikey, string url)
        {
            string retResponse = string.Empty;
            try
            {
                string requestURL = url + movie_id + "?api_key="+ apikey;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(new Uri(requestURL));
                    string jsonString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        retResponse = jsonString;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retResponse;
        }

        public async Task<string> SearchPeople(int person_id, string apikey, string url)
        {
            string retResponse = string.Empty;
            try
            {
                string requestURL = url + person_id + "?api_key=" + apikey;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(new Uri(requestURL));
                    string jsonString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        retResponse = jsonString;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retResponse;
        }

        public async Task<string> SearchTVShows(int tv_id, string apikey, string url)
        {
            string retResponse = string.Empty;
            try
            {
                string requestURL = url + tv_id + "?api_key=" + apikey;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(new Uri(requestURL));
                    string jsonString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        retResponse = jsonString;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retResponse;
        }
    }
}
