using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaseballIpsum.Web.Models;

namespace BaseballIpsum.Web.Controllers;

public class HomeController : Controller
{
    readonly ParagraphService _paragraphService;

    public HomeController()
    {
        _paragraphService = new ParagraphService();
    }

    public ViewResult Index()
    {
        var initialModel = new SubmitFormViewModel {NumParagraphs = 5};
        return View(initialModel);
    }

    [HttpPost]
    public ViewResult Index(SubmitFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.GeneratedParagraphs = _paragraphService.GetParagraphs(model.NumParagraphs, model.StartWithBaseballIpsum);
        }
        return View(model);
    }

    public ViewResult RestApi()
    {
        ViewBag.BaseUrl = Request.Scheme + "://" + Request.Host.Value;
        return View();
    }

    public ViewResult About()
    {
        return View();
    }
}