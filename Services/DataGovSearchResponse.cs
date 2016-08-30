using System.Collections.Generic;
using DoctorSearch.Models;
using Newtonsoft.Json;

namespace DoctorSearch.Services
{
    public class DataGovSearchResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "result")]
        public List<Surgery> Surgeries { get; set; }                     
    }
}