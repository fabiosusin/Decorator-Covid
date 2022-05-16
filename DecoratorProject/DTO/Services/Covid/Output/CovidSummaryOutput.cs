using System;
using System.Collections.Generic;

namespace DecoratorProject.DTO.Services.Covid.Output
{
    public class CovidSummaryOutput
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public Global Global { get; set; }
        public List<CountryOutput> Countries { get; set; }
        public DateTime Date { get; set; }
    }

    public class CountryOutput
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Slug { get; set; }
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }
    }

    public class Global
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }
    }

}
