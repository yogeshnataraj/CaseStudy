using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Domain.ProjectAggregate.Data
{
    public class Artical
    {        
        [Key]       
        public Guid ArticalId {get; set;}
        public Guid ColorId {get; set;}
    }
}