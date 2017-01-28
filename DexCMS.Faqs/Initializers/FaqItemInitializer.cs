using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Faqs.Contexts;
using DexCMS.Faqs.Initializers.Helpers;
using DexCMS.Faqs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DexCMS.Faqs.Initializers
{
    class FaqItemInitializer : DexCMSInitializer<IDexCMSFaqsContext>
    {
        private FaqCategoryReference Categories { get; set; }

        public FaqItemInitializer(IDexCMSFaqsContext context) : base(context)
        {
            Categories = new FaqCategoryReference(context);
        }

        public override void Run(bool addDemoContent = true)
        {
            if (addDemoContent && Context.FaqItems.Count() == 0)
            {
                Context.FaqItems.AddRange(new List<FaqItem>
                {
                    new FaqItem
                    {
                        Answer = "<p>Veggies es bonus vobis, proinde vos postulo essum magis kohlrabi welsh onion daikon amaranth tatsoi tomatillo melon azuki bean garlic.</p>",
                        DisplayOrder = 0,
                        FaqCategoryID = Categories.Some,
                        HelpfulMarks = 5,
                        IsActive = true,
                        LastUpdated = DateTime.Now,
                        LastUpdatedBy = "Sample Data",
                        Question = "How do I yadda yadda?",
                        UnhelpfulMarks = 1
                    },
                    new FaqItem
                    {
                        Answer = "<p>Either blow us all up or rub soup in our hair. It's a toss-up. I've seen the best and the worst of you. If you say 'adorabubble,' I'm leaving.</p>",
                        DisplayOrder = 1,
                        FaqCategoryID = Categories.Some,
                        HelpfulMarks = 0,
                        IsActive = true,
                        LastUpdated = DateTime.Now,
                        LastUpdatedBy = "Sample Data",
                        Question = "Can I something or other?",
                        UnhelpfulMarks = 5
                    },
                    new FaqItem
                    {
                        Answer = "<p>Vaporware pour-over man bun organic, VHS bicycle rights blog franzen fashion axe. Af lo-fi trust fund vinyl craft beer, leggings taxidermy fingerstache gluten-free coloring book next level. Wolf wayfarers coloring book mlkshk fam.</p>",
                        DisplayOrder = 0,
                        FaqCategoryID = Categories.Another,
                        IsActive = true,
                        LastUpdated = DateTime.Now,
                        LastUpdatedBy = "Sample Data",
                        Question = "Where do I do this?"
                    }
                });
                Context.SaveChanges();
            }
        }
    }
}
