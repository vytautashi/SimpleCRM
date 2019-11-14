using System;

namespace SimpleCRM.App.Dto
{
    public class CompanyInfoDto
    {
        public string CompanyCode { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Ceoname { get; set; }
        public string Website { get; set; }
        public string ShortInfo { get; set; }

        public string DetailsUrl { get; set; } // rekvizitai.vz.lt url to company details
    }
}
