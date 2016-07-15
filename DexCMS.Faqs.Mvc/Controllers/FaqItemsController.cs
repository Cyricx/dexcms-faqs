using DexCMS.Faqs.Interfaces;
using DexCMS.Faqs.Models;
using DexCMS.Faqs.Mvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DexCMS.Faqs.Mvc.Controllers
{
    public class FaqItemsController : Controller
    {
        private IFaqItemRepository itemsRepository;
        private IFaqCategoryRepository categoryRepository;

        public FaqItemsController(IFaqItemRepository itemsRepo, IFaqCategoryRepository categoryRepo)
        {
            itemsRepository = itemsRepo;
            categoryRepository = categoryRepo;
        }

        public ActionResult Index()
        {
            DisplayFAQs faqDisplay = new DisplayFAQs
            {
                faqCategories = new List<FaqCategory>(),
                faqItems = new List<FaqItem>()
            };

            foreach (var faqCat in categoryRepository.Items.Where(x => x.IsActive).OrderBy(x => x.DisplayOrder).ToList())
            {
                List<FaqItem> faqItems = faqCat.FaqItems.Where(x => x.IsActive).OrderBy(x => x.DisplayOrder).ToList();

                faqDisplay.faqCategories.Add(new FaqCategory
                {
                    FaqCategoryID = faqCat.FaqCategoryID,
                    Name = faqCat.Name,
                    FaqItems = faqItems
                });
                faqDisplay.faqItems.AddRange(faqItems);
            }

            return View(faqDisplay);
        }


        // GET: FaqItems
        public async Task<JsonResult> Helpful(int id)
        {
            var faq = await itemsRepository.RetrieveAsync(id);

            if (faq == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            if (faq.HelpfulMarks.HasValue)
            {
                faq.HelpfulMarks++;
            }
            else
            {
                faq.HelpfulMarks = 1;
            }

            await itemsRepository.UpdateAsync(faq, faq.FaqItemID);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Unhelpful(int id)
        {
            var faq = await itemsRepository.RetrieveAsync(id);

            if (faq == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            if (faq.UnhelpfulMarks.HasValue)
            {
                faq.UnhelpfulMarks--;
            }
            else
            {
                faq.UnhelpfulMarks = -1;
            }

            await itemsRepository.UpdateAsync(faq, faq.FaqItemID);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }

}
