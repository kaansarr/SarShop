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

		[StringLength(100), Column(TypeName = "varchar(100)")]
		public string Address { get; set; }



	}
}
