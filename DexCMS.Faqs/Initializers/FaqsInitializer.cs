using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Faqs.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Faqs.Initializers
{
    public class FaqsInitializer : DexCMSInitializer<IDexCMSFaqsContext>
    {
        public FaqsInitializer(IDexCMSFaqsContext context) : base(context)
        {
        }

        public override void Run()
        {
            (new FaqSectionInitializer(Context)).Run();
            (new FaqCategoryInitializer(Context)).Run();
            (new FaqItemInitializer(Context)).Run();
        }
    }
}
