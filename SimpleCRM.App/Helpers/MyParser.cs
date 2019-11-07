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
        public static async Task<IEnumerable<CompanyInfoDto>> CompanyByCode(string companyCode)
        {
            IList<CompanyInfoDto> companyInfoDtos = new List<CompanyInfoDto>();
            
            var postParams = new Dictionary<string, string>
            {
                { "code", companyCode },
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

                HtmlNode infoNode = node.SelectSingleNode("//div[@class='info']");
                HtmlNode firmTitleNode = infoNode.SelectSingleNode("//a[@class='firmTitle']");
                title     = firmTitleNode.InnerText;
                address   = firmTitleNode.NextSibling.NextSibling.InnerText.Replace("Adresas: ", "");
                shortInfo = firmTitleNode.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace("Veiklos sritys: ", "");

                CompanyInfoDto companyInfoDto = new CompanyInfoDto
                {
                    CompanyCode = companyCode,
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
