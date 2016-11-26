using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;
using System;
using System.Linq;

namespace DexCMS.Faqs.Mvc.Initializers
{
    class PageContentInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        public PageContentInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            DateTime Today = DateTime.Now;
            int Public = Context.ContentAreas.Where(x => x.Name == "Public").Select(x => x.ContentAreaID).Single();
            int SiteContent = Context.PageTypes.Where(x => x.Name == "Site Content").Select(x => x.PageTypeID).Single();

            Context.PageContents.AddIfNotExists(x => x.PageTitle,
                new PageContent
                {
                    Body = "",
                    PageTitle = "Calendar",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Calendar",
                    ContentAreaID = Public,
                    ContentCategoryID = null,
                    UrlSegment = "calendar",
                    PageTypeID = SiteContent
                }
            );
            Context.SaveChanges();
        }
    }
}
