using System.Web.Mvc;
using BaseballIpsum.Web.Models;

namespace BaseballIpsum.Web.Controllers
{
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
            ViewBag.BaseUrl = "http://" + Request.ServerVariables["SERVER_NAME"];
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}