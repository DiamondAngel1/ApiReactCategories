using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Atb.Data.Entitys
{
    [Table("tbl_categories")]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(255)]
        public string Image { get; set; } = string.Empty;

    }
}
