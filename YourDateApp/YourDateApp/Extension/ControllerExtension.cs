using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YourDateApp.Models;

namespace YourDateApp.Extension
{
    public static class ControllerExtension
    {
        public static void SetNotyfication(this Controller controller, string message, string type)
        {
            var notyfication = new Notyfication(message, type);
            controller.TempData["Notyfication"] = JsonConvert.SerializeObject(notyfication);
        }
    }
}