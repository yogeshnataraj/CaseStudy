using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Domain.Exceptions
{
    public class ProducNotFoundException : Exception
    {
        public ProducNotFoundException() : base("Product not found")
        {
            
        }
    }
}