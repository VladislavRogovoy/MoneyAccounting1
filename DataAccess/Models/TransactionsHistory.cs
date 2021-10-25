using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class TransactionsHistory
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string History { get; set; }
    }
}
