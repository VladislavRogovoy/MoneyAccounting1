using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public float Balance { get; set; }
        [MaxLength(3)]
        public string Currency { get; set; }
    }
}
