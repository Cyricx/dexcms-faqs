using System;

namespace DexCMS.Faqs.WebApi.ApiModels
{
    public class FaqItemApiModel
    {
        public int FaqItemID { get; set; }
        public string Answer { get; set; }
        public int DisplayOrder { get; set; }
        public int FaqCategoryID { get; set; }
        public string FaqCategoryName { get; set; }
        public int? HelpfulMarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public string Question { get; set; }
        public bool? ResetMarks { get; set; }
        public int? UnhelpfulMarks { get; set; }
    }
}
