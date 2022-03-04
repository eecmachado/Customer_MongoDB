using Microsoft.AspNetCore.Mvc;

namespace Store.Host.Controllers;

public class HomeController : ControllerBase
{
    public ActionResult Index() => new RedirectResult("~/swagger");
}