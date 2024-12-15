using System.ComponentModel.DataAnnotations;

namespace Sticker_Web_dotnet.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
