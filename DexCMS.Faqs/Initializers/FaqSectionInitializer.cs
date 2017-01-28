using DexCMS.Core.Extensions;
using DexCMS.Core.Globals;
using DexCMS.Faqs.Contexts;
using DexCMS.Faqs.Models;

namespace DexCMS.Faqs.Initializers
{
    class FaqSectionInitializer : DexCMSInitializer<IDexCMSFaqsContext>
    {
        public FaqSectionInitializer(IDexCMSFaqsContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.FaqSections.AddIfNotExists(x => x.Name,
                new FaqSection { Name = "Public", IsActive = true });
            Context.SaveChanges();
        }
    }
}
