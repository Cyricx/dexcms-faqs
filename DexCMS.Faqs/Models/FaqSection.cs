using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Faqs.Models
{
    public class FaqSection
    {
        [Key]
        public int FaqSectionID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<FaqCategory> FaqCategories { get; set; }
    }
}
