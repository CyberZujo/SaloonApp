using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalonAplikacija.Web.Helpers.Enumerations;
using Microsoft.AspNetCore.Html;
using SalonAplikacija.Web.Helpers.AjaxMessages;

namespace SalonAplikacija.Web.Helpers.AjaxMessages
{
    public class AjaxFlashMessage:IAjaxFlashMessage
    {
        private const string Key = "_temp_data_ajax_flash_message";
        private const string AlertTemplate = "<div class=\"alert alert-{0} alert-dismissable\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\"></button><div>{1}</div></div>";

        private readonly ITempDataDictionary _tempData;

        public AjaxFlashMessage(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
        }

        public void Success(string message)
        {
            Message(Enumerations.Enumerations.AjaxFlashMessageType.Success, "test");
            Message(Enumerations.Enumerations.AjaxFlashMessageType.Success, message);
        }

        public void Danger(string message)
        {
            Message(Enumerations.Enumerations.AjaxFlashMessageType.Danger, message);
        }

        private void Message(Enumerations.Enumerations.AjaxFlashMessageType type, string message)
        {
            if (_tempData.ContainsKey(Key))
                _tempData.Remove(Key);

            _tempData.Add(Key, string.Format(AlertTemplate, type.ToString().ToLower(), message));
        }

        public IHtmlContent Display()
        {
            if (!_tempData.TryGetValue(Key, out var text))
                return HtmlString.Empty;

            var htmlString = new HtmlString(text.ToString());
            if (htmlString.Value == null)
                return HtmlString.Empty;

            _tempData.Remove(Key);

            return htmlString;
        }
    }
}
