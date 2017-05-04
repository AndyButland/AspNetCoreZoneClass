using System.Collections.Generic;
using System.Threading.Tasks;
using DoctorSearch.Models;

namespace DoctorSearch.Services
{
    public interface ISearchService
    {
        Task<List<Surgery>>  GetSurgeries(string postcode);
    }
}