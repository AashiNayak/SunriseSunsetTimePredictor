using SunriseSunsetTimePredictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SunriseSunsetTimePredictor
{
    class TimePredictor
    {
        public static async Task<DataModel> LoadTime(float lat, float lng)
        {
            string path = $"https://api.sunrise-sunset.org/json?lat={ lat }&lng={ lng }";

            using (HttpResponseMessage response = await ApiConnection.ApiClient.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    ResultModel time = await response.Content.ReadAsAsync<ResultModel>();
                    return time.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
