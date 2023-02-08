using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
	public class Customer
	{
		public int id { get; set; }
		public string name { get; set; }
		public string phone { get; set; }
		public string email { get; set; }
		public string address { get; set; }
		public override string ToString()
		{
			return this.name + "(" + this.phone + ")";
		}
	}
}
