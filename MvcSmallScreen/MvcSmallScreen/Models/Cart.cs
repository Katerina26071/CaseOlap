using System.ComponentModel.DataAnnotations;

namespace MvcSmallScreen.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int GoodsId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Goods Goods { get; set; }
    }
}