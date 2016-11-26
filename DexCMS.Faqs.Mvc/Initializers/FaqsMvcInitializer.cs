using DexCMS.Base.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Faqs.Mvc.Initializers
{
    public class FaqsMvcInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        public FaqsMvcInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            (new PageContentInitializer(Context)).Run();
        }
    }
}
