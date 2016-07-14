using DexCMS.Faqs.Models;
using System.Collections.Generic;

namespace DexCMS.Faqs.Mvc.Models
{
    public class DisplayFAQs
    {
        public List<FaqCategory> faqCategories { get; set; }
        public List<FaqItem> faqItems { get; set; }

    }
}
