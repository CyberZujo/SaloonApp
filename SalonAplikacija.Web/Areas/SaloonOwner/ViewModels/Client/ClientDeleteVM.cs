using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Client
{
    public class ClientDeleteVM
    {
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientEmail { get; set; }
    }
}
