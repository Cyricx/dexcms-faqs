using System;
using System.Collections.Generic;
using DexCMS.Base.Contexts;
using DexCMS.Core.Globals;

namespace DexCMS.Faqs.Mvc.Initializers
{
    public class FaqsMvcInitializer : DexCMSLibraryInitializer<IDexCMSBaseContext>
    {
        public FaqsMvcInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>
                {
                    typeof(PageContentInitializer)
                };
            }
        }
    }
}
