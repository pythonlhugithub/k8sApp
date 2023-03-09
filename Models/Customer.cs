using System.ComponentModel.DataAnnotations;

namespace AzureNet7WebApi.Models
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; } 
        public string City { get; set; }    
        public string Region { get; set; }
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }
    }

