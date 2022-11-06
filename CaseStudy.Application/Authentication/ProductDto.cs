using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Application.Authentication
{
    public class ProductDTO
    {
        public Guid ProductId {get;set;}
        public string ProductName { get; set; }
        public int ProductYear { get; set; }
        public int ChannelId { get; set; }
        public Guid  SizeScaleId { get; set; }  
        public IList<ArticleDTO> Articles {get; set;}
    }

    public class ArticleDTO
    {
        public Guid ArticleId { get; set; }
        public Guid ColourId { get; set; }
    }
}