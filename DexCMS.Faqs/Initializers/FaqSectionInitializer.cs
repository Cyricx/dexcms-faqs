using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Faqs.Contexts;
using DexCMS.Faqs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Faqs.Initializers
{
    class FaqSectionInitializer : DexCMSInitializer<IDexCMSFaqsContext>
    {
        public FaqSectionInitializer(IDexCMSFaqsContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.FaqSections.AddIfNotExists(x => x.Name,
                new FaqSection { Name = "Public", IsActive = true });
            Context.SaveChanges();
        }
    }
}
