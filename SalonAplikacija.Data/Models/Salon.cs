using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class Salon
    {
        [Key]
        public int SaloonId { get; set; }

        [ForeignKey(nameof(City)), Range(1, int.MaxValue), Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(Country)), Range(1, int.MaxValue), Required]
        public int CountryId { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(150), Required]
        public string Address { get; set; }

        [StringLength(150), DataType(DataType.PhoneNumber), Phone, Required]
        public string Phone { get; set; }

        [StringLength(150), DataType(DataType.PhoneNumber), Phone, Required]
        public string Mobile { get; set; }

        [StringLength(150), DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime OpeningTime { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime ClosingTime { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
    }
}
