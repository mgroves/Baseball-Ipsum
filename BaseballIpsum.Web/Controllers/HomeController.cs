using System.Collections.Generic;
using System.Web.Mvc;
using BaseballIpsum.Web.Models;

namespace BaseballIpsum.Web.Controllers
{
    public class HomeController : Controller
    {
        ParagraphGenerator _paragraphGenerator;

        public HomeController()
        {
            var dict = new IpsumDictionary();
            var sent = new SentenceGenerator(dict);
            _paragraphGenerator = new ParagraphGenerator(sent);
        }

        public ViewResult Index()
        {
            var initialModel = new SubmitFormViewModel();
            initialModel.NumParagraphs = 5;
            return View(initialModel);
        }

        [HttpPost]
        public ViewResult Index(SubmitFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.GeneratedParagraphs = new List<string>();
                for (int i = 0; i < model.NumParagraphs; i++)
                {
                    var paragraph = _paragraphGenerator.GetParagraph();
                    if (model.StartWithBaseballIpsum)
                    {
                        var tokens = paragraph.Split(' ');
                        tokens[0] = "Baseball";
                        tokens[1] = "ipsum";
                        tokens[2] = "dolor";
                        tokens[3] = "sit";
                        tokens[4] = "amet";
                        paragraph = string.Join(" ", tokens);
                    }
                    model.GeneratedParagraphs.Add(paragraph);
                }
            }
            return View(model);
        }

        public ViewResult RestApi()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}