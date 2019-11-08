using HtmlAgilityPack;
using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Helpers
{
    public static class MyParser
    {
        public static async Task<IEnumerable<CompanyInfoDto>> CompanyByTitle(string title)
        {
            return await CompanyByField(title, "name");
        }

        public static async Task<IEnumerable<CompanyInfoDto>> CompanyByCode(string companyCode)
        {
            return await CompanyByField(companyCode, "code");
        }

        public static async Task<IEnumerable<CompanyInfoDto>> CompanyByField(string value, string searchField)
        {
            IList<CompanyInfoDto> companyInfoDtos = new List<CompanyInfoDto>();
            
            var postParams = new Dictionary<string, string>
            {
                { searchField, value },
                { "resetFilter", "0" }
            };

            var client = new HttpClient();
            var document = new HtmlAgilityPack.HtmlDocument();
            var content = new FormUrlEncodedContent(postParams);

            var response = await client.PostAsync("https://rekvizitai.vz.lt/imones/1/", content);
            var pageContents = await response.Content.ReadAsStringAsync();
            document.LoadHtml(pageContents);

            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//div[@class='firm']"))
            {
                string title     = "";
                string address   = "";
                string shortInfo = "";

                HtmlNode infoNode = node.SelectSingleNode(".//div[@class='info']");
                HtmlNode firmTitleNode = infoNode.SelectSingleNode(".//a[@class='firmTitle']");
                title     = firmTitleNode.InnerText;
                address   = firmTitleNode.NextSibling.NextSibling.InnerText.Replace("Adresas: ", "");
                shortInfo = firmTitleNode.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace("Veiklos sritys: ", "");


                CompanyInfoDto companyInfoDto = new CompanyInfoDto
                {
                    CompanyCode = searchField.Equals("name")?"":value,
                    Title = title,
                    Address = address,
                    ShortInfo = shortInfo,
                };

                companyInfoDtos.Add(companyInfoDto);
            }

            return companyInfoDtos;
        }
    }
}
