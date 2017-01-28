using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Faqs.Contexts;
using DexCMS.Faqs.Initializers.Helpers;
using DexCMS.Faqs.Models;
using System.Collections.Generic;
using System.Linq;

namespace DexCMS.Faqs.Initializers
{
    class FaqCategoryInitializer : DexCMSInitializer<IDexCMSFaqsContext>
    {
        private FaqSectionReference Sections { get; set; }

        public FaqCategoryInitializer(IDexCMSFaqsContext context) : base(context)
        {
            Sections = new FaqSectionReference(context);
        }

        public override void Run(bool addDemoContent = true)
        {
            if (addDemoContent && Context.FaqCategories.Count() == 0)
            {
                Context.FaqCategories.AddRange(new List<FaqCategory>
                {
                    new FaqCategory { DisplayOrder = 0, FaqSectionID = Sections.Public, IsActive = true, Name = "Some Category" },
                    new FaqCategory { DisplayOrder = 1, FaqSectionID = Sections.Public, IsActive = true, Name = "Another Category" },
                });
                Context.SaveChanges();
            }
        }
    }
}
