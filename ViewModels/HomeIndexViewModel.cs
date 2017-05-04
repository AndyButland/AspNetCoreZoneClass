using System.Collections.Generic;
using System.Linq;
using DoctorSearch.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DoctorSearch.ViewModels
{
    public class HomeIndexViewModel
    {
        public string PageTitle { get; set; }

        public string Postcode { get; set; }

        public bool SearchRequested { get; set; }

        public List<Surgery> Surgeries { get; set; }

        public string MapMarkerData
        {
            get
            {
                var surgeriesForMap = Surgeries
                    .Select(x => new 
                    {
                        Name = x.Name.Replace("'", ""),
                        x.Latitude,
                        x.Longitude
                    });
                return JsonConvert.SerializeObject(
                    surgeriesForMap,
                    Formatting.None,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
        }

        public decimal MapCentreLat
        {
            get
            {
                if (Surgeries.Any())
                {
                    return Surgeries
                        .Sum(x => x.Latitude) / Surgeries.Count();
                }

                return 0;  
            }
        }

        public decimal MapCentreLng
        {
            get
            {
                if (Surgeries.Any())
                {
                    return Surgeries
                        .Sum(x => x.Longitude) / Surgeries.Count();
                }

                return 0;  
            }
        }       
    }
}
