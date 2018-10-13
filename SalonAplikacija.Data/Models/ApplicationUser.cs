using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class ApplicationUser:IdentityUser
    {   
        public string PhotoURL { get; set; }
    }
}
