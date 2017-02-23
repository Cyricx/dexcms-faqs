using DexCMS.Faqs.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Faqs.Initializers.Helpers
{
    class FaqSectionReference
    {
        public int Public { get; set; }

        public FaqSectionReference(IDexCMSFaqsContext context)
        {
            Public = context.FaqSections.Where(x => x.Name == "Public").Select(x => x.FaqSectionID).SingleOrDefault();
        }
    }
}
