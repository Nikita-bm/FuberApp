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
                CustomerService customerService = new CustomerService();
                var registeredCustomer = customerService.RegisterCustomer(customer);

                CabService cabService = new CabService();
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
            CabService cabService = new CabService();
            cabService.UpdateCabLocation(cab, customer);

            CustomerService customerService = new CustomerService();
            customerService.RemoveCustomer(customer);
            return Ok();
        }
    }
}
