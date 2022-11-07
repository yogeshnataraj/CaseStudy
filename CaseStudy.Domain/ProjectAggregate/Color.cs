using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Domain.ProjectAggregate
{
    public class Color
    {
        public Guid ColorId { get; set; }
        public string ColourCode { get; set; }
        public string ColourName { get; set; }
    }
}