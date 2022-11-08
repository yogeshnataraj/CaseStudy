using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Domain.ProjectAggregate.Data
{
    public class Color
    {
        public Guid ColorId { get; set; }
        public string colourCode { get; set; }
        public string colorName { get; set; }
    }
}