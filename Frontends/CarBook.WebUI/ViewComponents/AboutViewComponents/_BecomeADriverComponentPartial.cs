using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial:ViewComponent
    {     
        public IViewComponentResult Invoke()
        {           
            return View();
        }
    }
}
