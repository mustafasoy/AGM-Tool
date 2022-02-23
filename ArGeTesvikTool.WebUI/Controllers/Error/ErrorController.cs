using Microsoft.AspNetCore.Mvc;

namespace ArGeTesvikTool.WebUI.Controllers.Error
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            string viewName = string.Empty;

            switch (statusCode)
            {
                case 404:
                    viewName = "NotFound";
                    break;
                case 500:
                    viewName = "InternalError";
                    break;
            }
           
            return View(viewName);
        }
    }
}
