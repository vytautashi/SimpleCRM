using HtmlAgilityPack;
using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public static async Task<CompanyInfoDto> CompanyByUrl(string url)
        {
            string companyCode = "";
            string ceoname = "";
            string website = "";

            CompanyInfoDto companyInfoDto;

            var client = new HttpClient();
            var document = new HtmlAgilityPack.HtmlDocument();

            string urlDecoded = HttpUtility.UrlDecode(url);
            var response = await client.GetAsync(urlDecoded);
            var pageContents = await response.Content.ReadAsStringAsync();
            document.LoadHtml(pageContents);

            HtmlNode infoNode        = document.DocumentNode.SelectSingleNode("//div[@class='info']");
            HtmlNode companyCodeNode = infoNode.SelectSingleNode(".//td[text() = 'Įmonės kodas']");
            HtmlNode ceoNameNode     = infoNode.SelectSingleNode(".//td[text() = 'Vadovas']");
            HtmlNode websiteNode     = infoNode.SelectSingleNode(".//td[text() = 'Tinklalapis']");

            if (companyCodeNode != null)
                companyCode = companyCodeNode.NextSibling.NextSibling.InnerText.Trim();
            if (websiteNode != null)
                website     = websiteNode.NextSibling.NextSibling.InnerText.Trim();
            if (ceoNameNode != null)
                ceoname     = ceoNameNode.NextSibling.NextSibling.InnerText
                    .Replace(", direktorius", "").Replace(", direktorė", "").Trim();

            companyInfoDto = new CompanyInfoDto
            {
                CompanyCode = companyCode,
                Ceoname     = ceoname,
                Website     = website,
                DetailsUrl  = urlDecoded,
            };

            return companyInfoDto;
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
                string name       = "";
                string address    = "";
                string shortInfo  = "";
                string detailsUrl = "";

                HtmlNode infoNode = node.SelectSingleNode(".//div[@class='info']");
                HtmlNode firmTitleNode = infoNode.SelectSingleNode(".//a[@class='firmTitle']");
                name       = firmTitleNode.InnerText;
                address    = firmTitleNode.NextSibling.NextSibling.InnerText.Replace("Adresas: ", "");
                shortInfo  = firmTitleNode.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace("Veiklos sritys: ", "");
                detailsUrl = firmTitleNode.GetAttributeValue("href", "");


                CompanyInfoDto companyInfoDto = new CompanyInfoDto
                {
                    CompanyCode = searchField.Equals("name")?"":value,
                    Name = name,
                    Address = address,
                    ShortInfo = shortInfo,
                    DetailsUrl = detailsUrl,
                };

                companyInfoDtos.Add(companyInfoDto);
            }

            return companyInfoDtos;
        }
    }
}
