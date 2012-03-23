using System.Web.Mvc;
using BaseballIpsum.Web.Models;

namespace BaseballIpsum.Web.Controllers
{
    public class ApiController : Controller
    {
        readonly ParagraphService _paragraphService;

        public ApiController()
        {
            _paragraphService = new ParagraphService();
        }

        public JsonResult Index(int paras = 1, bool startwithlorem = false)
        {
            if (paras > 25)
                paras = 25;
            return Json(_paragraphService.GetParagraphs(paras, startwithlorem), JsonRequestBehavior.AllowGet);
        }
    }
}