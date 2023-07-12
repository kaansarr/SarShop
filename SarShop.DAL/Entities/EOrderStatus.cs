using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarShop.DAL.Entities
{
	public enum EOrderStatus
	{
		Hazirlaniyor=1,
		Paketlendi,
		KargoyaVerildi,
		TeslimEdildi,
		İptalEdildi
	}
}
