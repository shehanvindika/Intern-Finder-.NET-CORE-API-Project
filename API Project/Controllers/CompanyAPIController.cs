using Core.Controller;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAPIController : ControllerBase
    {
        [HttpPost]
        [Route("api/v1/InsertCompanyData")]
        public string InsertCompanyDetails([FromBody] Company company)
        {
            CompanyController companyController = new CompanyControllerImpl();
            return companyController.SaveCompanyData(company);
        }

        [HttpGet]
        [Route("api/v1/CompanyList")]
        public List<Company> GetCompanyList()
        {
            CompanyController companyController = new CompanyControllerImpl();
            return companyController.ReadAllCompnay();
        }

        [HttpGet]
        [Route("api/v1/CompanyDetailsByName")]
        public List<Company> CompanyDetailsByName(string companyName)
        {
            CompanyController companyController = new CompanyControllerImpl();
            return companyController.ReadCompanyData(companyName);
        }
    }
}
