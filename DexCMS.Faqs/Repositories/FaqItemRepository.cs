using DexCMS.Core.Infrastructure.Repositories;
using DexCMS.Faqs.Models;
using DexCMS.Faqs.Interfaces;
using DexCMS.Faqs.Contexts;
using DexCMS.Core.Infrastructure.Contexts;
namespace DexCMS.Faqs.Repositories
{
    public class FaqItemRepository : AbstractRepository<FaqItem>, IFaqItemRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSFaqsContext _ctx { get; set; }

        public FaqItemRepository(IDexCMSFaqsContext ctx)
        {
            _ctx = ctx;
        }
    }
}