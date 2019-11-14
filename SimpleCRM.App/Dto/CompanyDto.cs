using System;

namespace SimpleCRM.App.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ceoname { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
    }
}
