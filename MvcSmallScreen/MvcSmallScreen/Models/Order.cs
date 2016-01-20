using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcSmallScreen.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        [DisplayName("Фамилия")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [DisplayName("Имя")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Введите город")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите область")]
        [StringLength(40)]
        public string State { get; set; }
        [Required(ErrorMessage = "Введите почтовый индекс")]
        [DisplayName("Почтовый индекс")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Укажите страну")]
        [StringLength(40)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Требуется номер телефона")]
        [StringLength(24)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Введите Email")]
        [DisplayName("Электронны адрес")]

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email не действителен.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}