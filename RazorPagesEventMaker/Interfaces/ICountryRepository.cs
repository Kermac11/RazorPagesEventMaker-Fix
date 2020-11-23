using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Interfaces
{
   public interface ICountryRepository
    {
        List<Country> GetAllCountries();
        public string GetCountryName(string code);
        void AddCountry(Country country);

    }
}
