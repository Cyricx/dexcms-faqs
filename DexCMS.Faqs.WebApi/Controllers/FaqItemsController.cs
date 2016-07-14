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
    public class FaqItemsController : ApiController
    {
        private IFaqItemRepository repository;

        public FaqItemsController(IFaqItemRepository repo)
        {
            repository = repo;
        }

        // GET api/FaqItems
        public List<FaqItemApiModel> GetFaqItems()
        {
            var items = repository.Items.Select(x => new FaqItemApiModel
            {
                FaqItemID = x.FaqItemID,
                Answer = x.Answer,
                DisplayOrder = x.DisplayOrder,
                FaqCategoryName = x.FaqCategory.Name,
                FaqCategoryID = x.FaqCategoryID,
                HelpfulMarks = x.HelpfulMarks,
                IsActive = x.IsActive,
                LastUpdated = x.LastUpdated,
                LastUpdatedBy = x.LastUpdatedBy,
                Question = x.Question,
                UnhelpfulMarks = x.UnhelpfulMarks
            }).ToList();

            return items;
        }

        // GET api/FaqItems/1
        [ResponseType(typeof(FaqItemApiModel))]
        public async Task<IHttpActionResult> GetFaqItems(int id)
        {
            FaqItem faqItem = await repository.RetrieveAsync(id);
            if (faqItem == null)
            {
                return NotFound();
            }

            FaqItemApiModel model = new FaqItemApiModel()
            {
                FaqItemID = faqItem.FaqItemID,
                Answer = faqItem.Answer,
                DisplayOrder = faqItem.DisplayOrder,
                FaqCategoryName = faqItem.FaqCategory.Name,
                FaqCategoryID = faqItem.FaqCategoryID,
                HelpfulMarks = faqItem.HelpfulMarks,
                IsActive = faqItem.IsActive,
                LastUpdated = faqItem.LastUpdated,
                LastUpdatedBy = faqItem.LastUpdatedBy,
                Question = faqItem.Question,
                UnhelpfulMarks = faqItem.UnhelpfulMarks
            };

            return Ok(model);
        }

        //GET api/FaqItems/byfaqcategory/1
        [ResponseType(typeof(List<FaqItemApiModel>))]
        public IHttpActionResult GetFaqItems(string bytype, int id)
        {
            var items = new List<FaqItemApiModel>();

            if (bytype == "byfaqcategory")
            {
                items = repository.Items.Where(x => x.FaqCategoryID == id).OrderBy(x => x.DisplayOrder).Select(x => new FaqItemApiModel
                {
                    FaqItemID = x.FaqItemID,
                    Answer = x.Answer,
                    DisplayOrder = x.DisplayOrder,
                    FaqCategoryName = x.FaqCategory.Name,
                    FaqCategoryID = x.FaqCategoryID,
                    HelpfulMarks = x.HelpfulMarks,
                    IsActive = x.IsActive,
                    LastUpdated = x.LastUpdated,
                    LastUpdatedBy = x.LastUpdatedBy,
                    Question = x.Question,
                    UnhelpfulMarks = x.UnhelpfulMarks
                }).ToList();
            }
            else
            {
                return NotFound();
            }

            return Ok(items);
        }

        // PUT api/FaqItems/5
        public async Task<IHttpActionResult> PutFaqItem(int id, FaqItem faqItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faqItem.FaqItemID)
            {
                return BadRequest();
            }

            if (faqItem.ResetMarks.HasValue && faqItem.ResetMarks.Value)
            {
                faqItem.HelpfulMarks = null;
                faqItem.UnhelpfulMarks = null;
            }

            await repository.UpdateAsync(faqItem, faqItem.FaqItemID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/FaqItems
        [ResponseType(typeof(FaqItem))]
        public async Task<IHttpActionResult> PostFaqItem(FaqItem faqItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.AddAsync(faqItem);

            return CreatedAtRoute("DefaultApi", new { id = faqItem.FaqItemID }, faqItem);
        }

        // DELETE api/FaqItems/5
        [ResponseType(typeof(FaqItem))]
        public async Task<IHttpActionResult> DeleteFaqItem(int id)
        {
            FaqItem faqItem = await repository.RetrieveAsync(id);
            if (faqItem == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(faqItem);

            return Ok(faqItem);
        }

    }

}
