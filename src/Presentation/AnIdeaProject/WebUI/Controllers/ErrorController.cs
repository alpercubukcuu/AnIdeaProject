using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class ErrorController : Controller
{
    public IActionResult UrlError()
    {
        ErrorModel errorModel = new();
        errorModel.ErrCode = "404";
        errorModel.ErrMesage = "Url request doesn't work. Url data not found!";

        return View("~/Views/Error/404Error.cshtml", errorModel);
    }

    public IActionResult PageError()
    {
        ErrorModel errorModel = new();
        errorModel.ErrCode = "404";
        errorModel.ErrMesage = "Page data not found!";

        return View("~/Views/Error/404Error.cshtml", errorModel);
    }
}
