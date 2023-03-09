using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureNet7WebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductId { get; set; }        = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string ProductCategory { get; set; } = string.Empty;
        public string ProductDescriptionCategory { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime DreatedDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}
