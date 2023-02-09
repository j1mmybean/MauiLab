using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
	public class CustomerViewModel : INotifyPropertyChanged
	{
		private SQLiteAsyncConnection _con;
		int index = 0;

		List<Customer> _list = new List<Customer>();

		public event PropertyChangedEventHandler PropertyChanged;

		public CustomerViewModel()
		{
			LoadData();
		}
		private void LoadData()
		{
			_list.Add(new Customer() { id = 1, name = "jimmy", phone = "0900000000", email = "jimmy@gmail.com", address = "Taipei" });
			_list.Add(new Customer() { id = 2, name = "tommy", phone = "0900000001", email = "tommy@gmail.com", address = "Taichung" });
			_list.Add(new Customer() { id = 3, name = "mary", phone = "0900000002", email = "mary@gmail.com", address = "Taipei" });
		}

		public void MoveFirst()
		{
			index = 0;
			PropertyChanged(this, new PropertyChangedEventArgs("Current"));
		}
		public void MovePrevious()
		{
			if (index > 0) index--;
			PropertyChanged(this, new PropertyChangedEventArgs("Current"));
		}
		public void MoveNext()
		{
			if (index < _list.Count - 1) index++;
			PropertyChanged(this, new PropertyChangedEventArgs("Current"));
		}
		public void MoveLast()
		{
			index = _list.Count - 1;
			PropertyChanged(this, new PropertyChangedEventArgs("Current"));
		}
		public void MoveTo(int to)
		{
			index = to;
			PropertyChanged(this, new PropertyChangedEventArgs("Current"));
		}

		internal Customer QueryByKeyword(string keyword)
		{
			for (int i = 0; i < _list.Count - 1; i++)
			{
				if (_list[i].name.Contains(keyword) ||
					_list[i].phone.Contains(keyword) ||
					_list[i].email.Contains(keyword) ||
					_list[i].address.Contains(keyword))
				{
					index = i;
					PropertyChanged(this, new PropertyChangedEventArgs("Current"));
					return _list[i];
				}
			}
			PropertyChanged(this, new PropertyChangedEventArgs("Current"));
			return null;
		}

		public Customer Current 
		{ 
			get { return _list[index]; }
			set { _list[index] = value; } 
		}
		public List<Customer> All => _list;
	}
}
