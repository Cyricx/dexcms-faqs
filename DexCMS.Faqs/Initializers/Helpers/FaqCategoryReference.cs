using DexCMS.Faqs.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Faqs.Initializers.Helpers
{
    class FaqCategoryReference
    {
        public int Some { get; set; }
        public int Another { get; set; }

        public FaqCategoryReference(IDexCMSFaqsContext context)
        {
            Some = context.FaqCategories.Where(x => x.Name == "Some Category").Select(x => x.FaqCategoryID).Single();
            Another = context.FaqCategories.Where(x => x.Name == "Another Category").Select(x => x.FaqCategoryID).Single();
        }
    }
}
