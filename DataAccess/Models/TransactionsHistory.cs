using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool IsAddition { get; set; }
        public float Amount { get; set; }
    }
}
