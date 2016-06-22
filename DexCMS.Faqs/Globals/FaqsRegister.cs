using Ninject;
using DexCMS.Faqs.Contexts;
using DexCMS.Faqs.Repositories;
using DexCMS.Faqs.Interfaces;

namespace DexCMS.Faqs.Globals
{
    public static class FaqsRegister<T> where T : IDexCMSFaqsContext
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IFaqCategoryRepository>().To<FaqCategoryRepository>();
            kernel.Bind<IFaqItemRepository>().To<FaqItemRepository>();
            kernel.Bind<IFaqSectionRepository>().To<FaqSectionRepository>();
        }
    }
}
