using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(Country)), Range(1, int.MaxValue), Required]
        public int CountryId { get; set; }

        [ForeignKey(nameof(City)), Range(1, int.MaxValue), Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(ClientType)), Range(1, int.MaxValue), Required]
        public int ClientTypeId { get; set; }

        [StringLength(50), Required]
        public string FirstName { get; set; }

        [StringLength(50), Required]
        public string LastName { get; set; }

        [StringLength(150), Required]
        public string Address { get; set; }

        [StringLength(100), DataType(DataType.EmailAddress), EmailAddress, Required]
        public string Email { get; set; }

        [StringLength(50), DataType(DataType.PhoneNumber), Required]
        public string Phone { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
        public ClientType ClientType { get; set; }

        [ForeignKey("UserId"), Required]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
