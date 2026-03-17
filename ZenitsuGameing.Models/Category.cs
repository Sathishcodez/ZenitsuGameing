using System.ComponentModel.DataAnnotations;

namespace ZenitsuGameing.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public int DisplayOrder { get; set; }

    }
}
