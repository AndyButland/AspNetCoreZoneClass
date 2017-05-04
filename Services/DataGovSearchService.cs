using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DoctorSearch.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace DoctorSearch.Services
{
    public class DataGovSearchService : ISearchService
    {
        private readonly IMemoryCache _cache;

        public DataGovSearchService (IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<List<Surgery>> GetSurgeries(string postcode)
        {
            var cacheKey = "Surgeries_" + postcode;

            List<Surgery> cachedValue;
            if (_cache.TryGetValue(cacheKey, out cachedValue))
            {
                return cachedValue;
            }

            using (var client = new HttpClient())
            {
                var url = "https://data.gov.uk/data/api/service/health/gp_surgeries/partial_postcode?partial_postcode=" + postcode;
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<DataGovSearchResponse>(json);
                    if (result.Success)
                    {
                        var surgeries = result.Surgeries
                            .OrderBy(x => x.Name)
                            .ToList();

                        _cache.Set(cacheKey, surgeries,
                            new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));

                        return surgeries;
                    }

                    throw new Exception("Request unsuccessful: response received but non-success after deserialisation.");
                }

                throw new Exception("Request unsuccessful: non-success response received.");     
            }          
        }
    }
}
