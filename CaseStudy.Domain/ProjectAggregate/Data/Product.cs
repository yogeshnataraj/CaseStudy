using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Domain.ProjectAggregate.Data;

public class Product
{
    public static Random random = new Random();
    public static int ProductNameInt = 1000000;

    [Key]
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int ChennalId { get; set; }
    public string ProductName { get; set; }
    public string ProductCode => GetProductName(ChennalId);
    public Guid SizeScaleId { get; set; }
    public ICollection<Artical> Articals { get; set; }
    public DateTime CreateDate => DateTime.UtcNow;
    public string CreatedBy { get; set; }

    private string GetProductName(int chennalId)
    {
        string productName = string.Empty;
        switch (chennalId)
        {
            case 1:
                productName = this.Year.ToString() + random.NextInt64(1000);
                break;
            case 2:
                productName = GetAlphaNumeric(6);
                break;
            case 3:
                ProductNameInt += 1;
                productName = ProductNameInt.ToString();
                break;
        }

        return productName;
    }

    private static string GetAlphaNumeric(int length)
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(characters, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}