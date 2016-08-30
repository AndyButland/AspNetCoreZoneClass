using System.Collections.Generic;
using System.Threading.Tasks;
using DoctorSearch.Models;

namespace DoctorSearch.Services
{
    public class StubSearchService : ISearchService
    {
        public Task<List<Surgery>> GetSurgeries(string postcode)
        {
            return Task.FromResult(new List<Surgery>()
            {
                new Surgery
                {
                    Name = "Test surgery",
                    Website = "http://www.test.com",
                    Email = "info@test.com",
                    Telephone = "01234 56789"
                },
                new Surgery
                {
                    Name = "Another surgery",
                    Website = "http://www.test.com",
                    Email = "info@test.com",
                    Telephone = "01234 56789"
                }                
            });
        }
    }
}