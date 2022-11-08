using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Domain.Infra
{
    public interface IRestClient
    {
        Task<List<Domain.ProjectAggregate.Data.Color>> GetColors();
        Task<List<Domain.ProjectAggregate.Data.Size>> GetSizes();
    }
}