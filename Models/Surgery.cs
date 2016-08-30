using Newtonsoft.Json;

namespace DoctorSearch.Models
{
    public class Surgery
    {
        [JsonProperty(PropertyName = "organisation_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public decimal Longitude { get; set; }    

        [JsonProperty(PropertyName = "latitude")]
        public decimal Latitude { get; set; }                                                                    
    }
}