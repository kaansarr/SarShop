﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarShop.DAL.Entities
{
	public class Category
	{
		public int ID { get; set; }

		[Display(Name="Üst Kategori")]
		public int? ParentID { get; set; }
		public Category ParentCategory { get; set; }


		[Display(Name = "Alt Kategori")]
		public ICollection<Category> SubCategories { get; set; }

		[StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Kategori Adı Boş Geçilemez"), Display(Name = "Kategori Adı")]
		public string Name { get; set; }

		[Display(Name = "Görüntülenme Sırası")]
		public int DisplayIndex { get; set; }

		public ICollection<ProductCategory> ProductCategories { get; set; }

		
	}
}
