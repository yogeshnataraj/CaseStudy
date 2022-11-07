using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Application.Authentication
{
    public class ProductResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public Guid SizeScaleId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public int ChannelId { get; set; }
        public List<Article> Articles { get; set; }
        public List<Sizes> Sizes { get; set; }
    }

    public record Article
    {
        public Guid ArticleId { get; set; }
        public string ArticleName { get; set; }
        public Guid ColourId { get; set; }
        public string ColourCode { get; set; }
        public string ColourName { get; set; }
    }

    public record Sizes
    {
        public Guid SizeId { get; set; }
        public string SizeName { get; set; }
    }
}