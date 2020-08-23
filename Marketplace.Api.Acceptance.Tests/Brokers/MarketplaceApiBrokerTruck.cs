using Marketplace.Api.Acceptance.Tests.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Api.Acceptance.Tests.Brokers
{
    public partial class MarketplaceApiBroker
    {
        private const string TrucksRelativeUrl = "/Truck";

        //public async ValueTask<IApiResponse<Truck>> PostTruckAsync(Truck truck) => 
        //    await apiFactoryClient.PostContentAsync(TrucksRelativeUrl, truck);

        public async ValueTask<Truck> PostTruckAsync(Truck truck)
        {
            StringContent contentString = StringifyJsonifyContent(truck);

            var response = await baseClient.PostAsync(TrucksRelativeUrl, contentString);

            string responseStream = await response.Content.ReadAsStringAsync();
            
            var apiData = JsonConvert.DeserializeObject<ApiResponse<Truck>>(responseStream);

            return apiData.Data;
        }

        public async ValueTask<Truck> GetTruckByIdAsync(int id) =>
            await apiFactoryClient.GetContentAsync<Truck>($"{TrucksRelativeUrl}/{id}");

        public async ValueTask<Truck> DeleteTruckByIdAsync(int id) =>
            await apiFactoryClient.DeleteContentAsync<Truck>($"{TrucksRelativeUrl}/{id}");

        private static StringContent StringifyJsonifyContent<T>(T content)
        {
            string serializedRestrictionRequest = JsonConvert.SerializeObject(content);

            var contentString =
                new StringContent(serializedRestrictionRequest, Encoding.UTF8, "text/json");

            return contentString;
        }
    }
}
