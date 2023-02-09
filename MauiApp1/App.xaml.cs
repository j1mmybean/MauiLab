using MauiApp1.Models;
using MauiApp1.Views;

namespace MauiApp1;

public partial class App : Application
{
	public string User { get; set; }
	public List<Customer> customerList { get; set; }
	public string Keyword { get; set; }
	public int SelectedCustomerIndex { get; set; }
	public TodoItem SelectedTodoItem { get; set; }
	//public List<TodoItem> TodoList { get; set; }
	public string KeyTodo { get; set; }
	public string KeyDate { get; set; }

	public App()
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new PgCalc());
		MainPage = new NavigationPage(new PgHttpDemo());
	}
}
