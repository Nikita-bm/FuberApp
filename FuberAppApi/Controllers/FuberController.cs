using FuberAppApi.Domain;
using FuberApps.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FuberAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuberController : ControllerBase
    {
       
        [HttpPost]
        public ActionResult<Cab> BookARide(Customer customer)
        {
            CustomerService customerService = new CustomerService();
            var newCustomer = customerService.RegisterCustomer(customer);

            CabService cabService = new CabService();
            var identifiedCab= cabService.AssignClosestAvailableCab(customer);


            return identifiedCab; //error if no cab identified 
        }

        [HttpPost]
        public ActionResult EndRide(Cab cab, Customer customer)
        {
            CabService cabService = new CabService();
            cabService.UpdateCabLocation(cab, customer);

            CustomerService customerService = new CustomerService();
            customerService.RemoveCustomer(customer);
            return null;
                
           
        }

    }
}
