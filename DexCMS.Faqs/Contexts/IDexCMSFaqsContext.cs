﻿using System.Data.Entity;
using DexCMS.Faqs.Models;
using DexCMS.Core.Infrastructure.Contexts;

namespace DexCMS.Faqs.Contexts
{
    public interface IDexCMSFaqsContext: IDexCMSContext
    {
        DbSet<FaqCategory> FaqCategories { get; set; }
        DbSet<FaqItem> FaqItems { get; set; }
    }
}
