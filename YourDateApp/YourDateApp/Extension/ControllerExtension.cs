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

        public static bool IsLoggedIn(this Controller controller)
        {
            var user = controller.HttpContext.User;
            if (user == null || user.Identity == null) return false;
            return user.Identity.IsAuthenticated;
        }

        public static string GetCurrentUsername(this Controller controller)
        {
            return controller.HttpContext!.User!.Identity!.Name!;
        }
    }
}