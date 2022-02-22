using AMS.Repositories.Generic;
using AMS.Model; 
using Microsoft.AspNetCore.Mvc; 
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AMS.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository; 
        private IAgreementRepository _agreementRepository;
   
        public ProductController(IProductRepository productRepository, IAgreementRepository agreementRepository)
        { 
            _productRepository = productRepository;
            _agreementRepository = agreementRepository; 
        }
        public ActionResult GetProducts(int? id)
        {
            var prod = _productRepository.GetProductsById(id);
            return Ok(prod);

        }
        public ActionResult CreateEdit(int? id)
        {
            var model = _agreementRepository.AddEdit(id);
            return PartialView("_CreateEdit", model);
        }
        [HttpDelete]
        public IActionResult DeleteAgreement(int Id)
        {
            var entity = _agreementRepository.DeleteAgreement(Id);
            if (entity > 0)
            {
                return Ok(200);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult GetAgreements()
        {
            // Paging sorting request
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][data]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            //var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _agreementRepository.GetAgreements(draw, start, length, sortColumn, sortColumnDirection, searchValue);
            return Ok(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAgreement(NewAgreeViewModel unit)
        {
            unit.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _agreementRepository.SaveAgreement(unit);
            return RedirectToAction("Index", "Home");
        }
    }
}
