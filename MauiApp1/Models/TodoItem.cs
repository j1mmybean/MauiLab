using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
	public class TodoItem
	{
		public string Todo { get; set; }
		public string Date { get; set; }
		public override string ToString()
		{
			return this.Date + " " + this.Todo;
		}
	}
}
