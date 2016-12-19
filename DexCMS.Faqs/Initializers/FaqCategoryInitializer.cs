using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Faqs.Contexts;
using DexCMS.Faqs.Initializers.Helpers;
using DexCMS.Faqs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Faqs.Initializers
{
    class FaqCategoryInitializer : DexCMSInitializer<IDexCMSFaqsContext>
    {
        private FaqSectionReference Sections { get; set; }

        public FaqCategoryInitializer(IDexCMSFaqsContext context) : base(context)
        {
            Sections = new FaqSectionReference(context);
        }

        public override void Run()
        {
            if (Context.FaqCategories.Count() == 0)
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
