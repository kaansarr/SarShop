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
	public class Brand
	{
		public int ID { get; set; }

		[StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Marka Adı Boş Geçilemez"), Display(Name = "Marka Adı")]
		public string Name { get; set; }

		public ICollection<Product>Products { get; set; }
	}
}
