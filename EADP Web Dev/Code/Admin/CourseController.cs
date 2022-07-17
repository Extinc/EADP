using System.Web.Mvc;

namespace EADP_Web_Dev.Code.Admin
{
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
			CourseDAO cdao = new CourseDAO();
			ViewBag.listCourse = cdao.findAll();
            return View();
        }
    }
}