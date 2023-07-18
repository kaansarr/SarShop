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
    [Table("Members")]
    public class Members
    {
        public int ID { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Yetkili adı boş geçilemez..."), Display(Name = "Üye Adı")]
        public string Name { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Yetkili soyadı boş geçilemez..."), Display(Name = "Üye Soyadı")]
        public string Surname { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Kullanıcı adı boş geçilemez..."), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [StringLength(32), Column(TypeName = "varchar(32)"), Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}
