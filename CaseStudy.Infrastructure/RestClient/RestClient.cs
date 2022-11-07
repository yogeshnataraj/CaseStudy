using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Domain.Infra;

namespace CaseStudy.Infrastructure.RestClient
{
    public class RestClient : IRestClient
    {
        private readonly string baseurl = "https://185be643-ec2f-4dea-965e-b6ee49c8ee22.mock.pstmn.io/localho:5454/";
        HttpClient client;

        private RestClient()
        {
            client = new HttpClient();
        }

        public async Task<string> GetColors()
        {
            var httpResponseMessage = await client.GetAsync($"{baseurl}/Colors");
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async Task<string> GetSizes()
        {
            var httpResponseMessage = await client.GetAsync($"{baseurl}/Sizes");
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}