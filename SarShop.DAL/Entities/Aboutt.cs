using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SarShop.DAL.Entities
{
	[Table("About")]
	public class Aboutt
	{
		public int ID { get; set; }

		[StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Hakkımızda Başlığı")]
		public string Title { get; set; }

		[StringLength(int.MaxValue), Column(TypeName = "varchar(MAX)"), Display(Name = "Hakkımızda Açıklaması")]
		public string Description { get; set; }

		public int DisplayIndex { get; set; }
	}
}
