using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Domain.Infra
{
    public interface IRestClient
    {
        Task<string> GetColors();
        Task<string> GetSizes();
    }
}