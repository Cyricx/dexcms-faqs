using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;
using System;
using DexCMS.Base.Initializers.Helpers;

namespace DexCMS.Faqs.Mvc.Initializers
{
    class PageContentInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        
        private AreasReference Areas { get; set; }
        private PageTypesReference PageTypes { get; set; }
        private LayoutTypesReference LayoutTypes { get; set; }

        public PageContentInitializer(IDexCMSBaseContext context) : base(context)
        {
            Areas = new AreasReference(context);
            PageTypes = new PageTypesReference(context);
            LayoutTypes = new LayoutTypesReference(context);
        }

        public override void Run(bool addDemoContent = true)
        {
            DateTime Today = DateTime.Now;

            Context.PageContents.AddIfNotExists(x => x.PageTitle,
                new PageContent
                {
                    Body = "",
                    PageTitle = "Faqs",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Faqs",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = null,
                    UrlSegment = "faqs",
                    PageTypeID = PageTypes.SiteContent,
                    IsDisabled = false,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    RequiresLogin = false
                }
            );
            Context.SaveChanges();
        }
    }
}
