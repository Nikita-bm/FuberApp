using FuberAppApi.Domain;
using FuberAppApi.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FuberAppApi.Controllers
{
    [Route("api/fuber")]
    [ApiController]
    public class FuberController : ControllerBase
    {
        [HttpPost]
        [Route("book-ride")]
        public ActionResult<Cab> BookARide(Customer customer)
        {
            try
            {
                var customerService = new CustomerService();
                var registeredCustomer = customerService.RegisterCustomer(customer);

                var cabService = new CabService();
                var identifiedCab = cabService.AssignClosestAvailableCab(registeredCustomer);

                return Ok(identifiedCab);
            }
            catch (CabNotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("end-ride")]
        public ActionResult EndRide(Cab cab, Customer customer)
        {
            var cabService = new CabService();
            cabService.EndRide(cab, customer);
            return Ok();
        }
    }
}
