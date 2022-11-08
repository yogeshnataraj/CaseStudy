using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CaseStudy.Domain.Infra;
using Newtonsoft.Json;

namespace CaseStudy.Infrastructure.RestClient
{
    public class RestClient : IRestClient
    {
        private readonly string baseurl = "https://185be643-ec2f-4dea-965e-b6ee49c8ee22.mock.pstmn.io/localho:5454/";
        private readonly HttpClient client = new HttpClient();

        public async Task<List<Domain.ProjectAggregate.Data.Color>> GetColors()
        {
            var httpResponseMessage = await client.GetAsync($"{baseurl}/Colors");
            var color = await httpResponseMessage.Content.ReadAsStringAsync();
            var listColor = JsonConvert.DeserializeObject<List<Domain.ProjectAggregate.Data.Color>>(color);
            return listColor;
        }

        public async Task<List<Domain.ProjectAggregate.Data.Size>> GetSizes()
        {
            var httpResponseMessage = await client.GetAsync($"{baseurl}/Sizes");
            var sizes = await httpResponseMessage.Content.ReadAsStringAsync();
            var listsize = JsonConvert.DeserializeObject<List<Domain.ProjectAggregate.Data.Size>>(sizes);
            return listsize;
        }
    }
}