using DexCMS.Core.Infrastructure.Repositories;
using DexCMS.Faqs.Models;
using DexCMS.Faqs.Interfaces;
using DexCMS.Faqs.Contexts;
using DexCMS.Core.Infrastructure.Contexts;
namespace DexCMS.Faqs.Repositories
{
    public class FaqSectionRepository : AbstractRepository<FaqSection>, IFaqSectionRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public FaqSectionRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}