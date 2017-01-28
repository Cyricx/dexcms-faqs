using DexCMS.Core.Repositories;
using DexCMS.Faqs.Models;
using DexCMS.Faqs.Interfaces;
using DexCMS.Faqs.Contexts;
using DexCMS.Core.Contexts;
namespace DexCMS.Faqs.Repositories
{
    public class FaqItemRepository : AbstractRepository<FaqItem>, IFaqItemRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public FaqItemRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}