using Microsoft.AspNetCore.Mvc;

namespace ScientificPublications.WebUI.Controllers
{
    public class UsersController : Controller
    {
        [Route("")]
        public ActionResult<string> Hello()
        {
            return Ok("hello");
        }
    }
}
