using System;
using System.Collections.Generic;
using System.Text;

namespace POSstation.Tmex
{
	public class DS1992
	{
		public byte[] contenido;
		public String IDRom;

		public DS1992()
		{
		}

		public DS1992(byte[] contenido, String idRom)
		{
			this.IDRom = idRom;
			this.contenido = contenido;
		}
	}
}