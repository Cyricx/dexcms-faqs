using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Faqs.Interfaces;
using DexCMS.Faqs.Models;
using DexCMS.Faqs.WebApi.ApiModels;

namespace DexCMS.Faqs.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FaqCategoriesController : ApiController
    {
        private IFaqCategoryRepository repository;

        public FaqCategoriesController(IFaqCategoryRepository repo)
        {
            repository = repo;
        }

        // GET api/FaqCategories
        public List<FaqCategoryApiModel> GetFaqCategories()
        {
            var items = repository.Items.Select(x => new FaqCategoryApiModel
            {
                FaqCategoryID = x.FaqCategoryID,
                Name = x.Name,
                IsActive = x.IsActive,
                DisplayOrder = x.DisplayOrder,
                ItemCount = x.FaqItems.Count
            }).ToList();

            return items;
        }

        // GET api/FaqCategories/1
        [ResponseType(typeof(FaqCategoryApiModel))]
        public async Task<IHttpActionResult> GetEventAgeGroups(int id)
        {
            FaqCategory faqCategory = await repository.RetrieveAsync(id);
            if (faqCategory == null)
            {
                return NotFound();
            }

            FaqCategoryApiModel model = new FaqCategoryApiModel()
            {
                FaqCategoryID = faqCategory.FaqCategoryID,
                Name = faqCategory.Name,
                IsActive = faqCategory.IsActive,
                DisplayOrder = faqCategory.DisplayOrder,
                ItemCount = faqCategory.FaqItems.Count
            };

            return Ok(model);
        }

        //GET api/FaqCategories/byevent/1
        [ResponseType(typeof(List<FaqCategoryApiModel>))]
        public IHttpActionResult GetFaqCategories(string bytype, int id)
        {
            var items = new List<FaqCategoryApiModel>();

            if (bytype == "byevent")
            {
                items = repository.Items.OrderBy(x => x.DisplayOrder).Select(x => new FaqCategoryApiModel
                {
                    FaqCategoryID = x.FaqCategoryID,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    DisplayOrder = x.DisplayOrder,
                    ItemCount = x.FaqItems.Count
                }).ToList();
            }
            else
            {
                return NotFound();
            }

            return Ok(items);
        }

        // PUT api/FaqCategories/5
        public async Task<IHttpActionResult> PutFaqCategory(int id, FaqCategory faqCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faqCategory.FaqCategoryID)
            {
                return BadRequest();
            }

            await repository.UpdateAsync(faqCategory, faqCategory.FaqCategoryID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/FaqCategories
        [ResponseType(typeof(FaqCategory))]
        public async Task<IHttpActionResult> PostFaqCategory(FaqCategory faqCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.AddAsync(faqCategory);

            return CreatedAtRoute("DefaultApi", new { id = faqCategory.FaqCategoryID }, faqCategory);
        }

        // DELETE api/FaqCategories/5
        [ResponseType(typeof(FaqCategory))]
        public async Task<IHttpActionResult> DeleteFaqCategory(int id)
        {
            FaqCategory faqCategory = await repository.RetrieveAsync(id);
            if (faqCategory == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(faqCategory);

            return Ok(faqCategory);
        }

    }

}
