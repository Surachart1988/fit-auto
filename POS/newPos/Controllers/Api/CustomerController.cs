using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace newPos.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class CustomerController : ApiController
    {
        private IDropDownService _dropDownService;
        private ICustomerService _customerService;
        public CustomerController(
            IDropDownService dropDownService,
            ICustomerService customerService
            )
        {
            _dropDownService = dropDownService;
            _customerService = customerService;
        }

        public IHttpActionResult CarRegList([FromBody] DTParameters dataTableRequestModel)
        {
            return Json(_customerService.CarRegList(dataTableRequestModel));
        }

        public IHttpActionResult CustomerList([FromBody] DTParameters dataTableRequestModel)
        {
            return Json(_customerService.CustomerList(dataTableRequestModel));
        }
    }
}
