using FuberAppApi.Domain;
using FuberAppApi.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FuberAppApi.Controllers
{
    [Route("api/fuber")]
    [ApiController]
    public class FuberController : ControllerBase
    {
        /// <summary>
        /// Book a ride
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("book-ride")]
        public ActionResult<Ride> BookARide(Customer customer)
        {
            try
            {
                var cabService = new CabService();
                var identifiedCab = cabService.AssignClosestAvailableCab(customer);

                return Ok(identifiedCab);
            }
            catch (CabNotFoundException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// End a ride
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("end-ride")]
        public ActionResult<string> EndRide(Ride ride)
        {
            var cabService = new CabService();
            var estimatedFare = cabService.EndRide(ride);
            return Ok(estimatedFare);
        }
    }
}
