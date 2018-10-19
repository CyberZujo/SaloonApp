using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Helpers.AjaxMessages
{
   public interface IAjaxFlashMessage
    {
        void Success(string message);
        void Danger(string message);
        IHtmlContent Display();
    }
}
