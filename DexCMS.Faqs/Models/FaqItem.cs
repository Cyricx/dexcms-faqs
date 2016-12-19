using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Faqs.Models
{
    public class FaqItem
    {
        [Key]
        public int FaqItemID { get; set; }

        [Required]
        [StringLength(250)]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        public int? HelpfulMarks { get; set; }
        public int? UnhelpfulMarks { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [Column(TypeName="datetime")]
        public DateTime LastUpdated { get; set; }

        [Required]
        [StringLength(256)]
        public string LastUpdatedBy { get; set; }

        [Required]
        public int FaqCategoryID { get; set; }

        public virtual FaqCategory FaqCategory { get; set; }

        [NotMapped]
        public bool? ResetMarks { get; set; }
    }
}
