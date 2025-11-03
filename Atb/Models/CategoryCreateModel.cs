using System.ComponentModel.DataAnnotations;

namespace Atb.Models
{
    public class CategoryCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }


    }
}
