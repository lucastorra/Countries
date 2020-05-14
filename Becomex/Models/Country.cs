using System.Collections.Generic;

namespace Country.Models
{
    public class Country
    {
        public string Name { get; set; }

        public string Capital { get; set; }

        public string Flag { get; set; }

        public string Alpha3Code { get; set; }

        public int Population { get; set; }

        public List<string> TimeZones { get; set; }

        public List<Currency> Currencies { get; set; } 

        public List<Language> Languages { get; set; }

        public List<string> Borders { get; set; }
               
    }
}