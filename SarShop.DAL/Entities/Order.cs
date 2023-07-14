using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarShop.DAL.Entities
{
	public class Order
	{
		public int ID { get; set; }


		[StringLength(10), Column(TypeName = "varchar(10)"), Display(Name = "Sipariş Numarası"),Required(ErrorMessage ="Sipariş Numarası boş geçilemez")]
		public string OrderNumber { get; set; }


		[StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Ad"),Required(ErrorMessage = "Ad Bilgisi boş geçilemez")]
		public string Name { get; set; }

		[StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Soyad"), Required(ErrorMessage = "Soyad Bilgisi boş geçilemez")]
		public string Surname { get; set; }

		[StringLength(100), Column(TypeName = "varchar(100)"),Display(Name ="Adres Tanımı"), Required(ErrorMessage = "Adres Bilgisi boş geçilemez")]
		public string Address { get; set; }

		[Display(Name ="Şehir")]
		public int? CityID { get; set; }
		public City City { get; set; }

		[StringLength(5), Column(TypeName = "char(5)"), Display(Name = "Posta Kodu"),Required(ErrorMessage = "Posta Kodu boş geçilemez")]
		public string ZipCode { get; set; }

		[StringLength(16), Column(TypeName = "char(16)"), Display(Name = "Kart Numarası"), Required(ErrorMessage = "Kart numarası boş geçilemez")]
		public string CartNumber { get; set; }

		[StringLength(2), Column(TypeName = "char(2)"), Display(Name = "Kart Ayı"), Required(ErrorMessage = " Boş geçilemez")]
		public string ExpMounth { get; set; }

		[StringLength(2), Column(TypeName = "char(2)"), Display(Name = "Kart Yılı"), Required(ErrorMessage = " Boş geçilemez")]
		public string ExpYear { get; set; }

		[StringLength(3), Column(TypeName = "char(3)"), Display(Name = "Kart Yılı")]
		public string CVV { get; set; }
		[Display(Name ="Ödeme Türü")]
		public EPaymentOption PaymentOption { get; set; }

		[Display(Name = "Sipariş Durumu")]
		public EOrderStatus OrderStatus { get; set; }

		[Display(Name = "Sipariş Durumu")]
		public DateTime RecDate { get; set; }


		[StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "IP Numarası")]
		public string IPNO { get; set; }

		public ICollection<OrderDetail> OrderDetails { get; set; }

	}
}
