using FuberApps.Model;
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
          //Get available cars based on  closest location

            //Assign cars
        }

        [HttpPost]
        public ActionResult<string> StopRide(Customer customer)
        {
            return "value";
        }

    }
}
