using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSmallScreen.Models;

namespace MvcSmallScreen.Models
{
    [Bind(Exclude = "GoodsId")]
    public class Goods
    {
        [ScaffoldColumn(false)]
        public int GoodsId { get; set; }

        [DisplayName("ProductId")]
        public int ProductId { get; set; }
        [DisplayName("LaptopId")]
        public int LaptopId { get; set; }
        [Required(ErrorMessage = "Необходимо ввеси наименование")]
        [StringLength(160)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Цена обязательна")]
        [Range(0.01, 100000.00,
            ErrorMessage = "Диапазон цены от 0.01 до 100000.00")]
        public decimal Price { get; set; }
        [DisplayName("Ссылка на изображение")]
        [StringLength(1024)]
        public string GoodArtUrl { get; set; }
        public virtual Product products { get; set; }
        public virtual Laptop Laptop { get; set; }
    }
}