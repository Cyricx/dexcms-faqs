
namespace DexCMS.Faqs.WebApi.ApiModels
{
    public class FaqCategoryApiModel
    {
        public int FaqCategoryID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public int ItemCount { get; set; }
        public int FaqSectionID { get; set; }
    }
}
