using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Faqs.Contexts;
using System;
using System.Collections.Generic;

namespace DexCMS.Faqs.Initializers
{
    public class FaqsInitializer : DexCMSLibraryInitializer<IDexCMSFaqsContext>
    {
        public FaqsInitializer(IDexCMSFaqsContext context) : base(context)
        {
        }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>
                {
                    typeof(FaqSectionInitializer),
                    typeof(FaqCategoryInitializer),
                    typeof(FaqItemInitializer)
                };
            }
        }
    }
}
