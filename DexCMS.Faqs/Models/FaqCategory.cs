using System.ComponentModel.DataAnnotations;

namespace DexCMS.Faqs.Models
{
    public class FaqCategory
    {
        [Key]
        public int FaqCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int FaqSectionID { get; set; }

        public virtual FaqSection FaqSection { get; set; }
    }
}
