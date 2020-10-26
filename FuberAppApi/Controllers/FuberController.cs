using FuberApps.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FuberAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuberController : ControllerBase
    {
       
        [HttpPost]
        public ActionResult<string> BookRide(Customer customer)
        {
            //Get available Cabs based on  closest location

            //Assign Cabs
            return null;
        }

        [HttpPost]
        public ActionResult<string> StopRide(Customer customer)
        {
            return "value";
        }

    }
}
