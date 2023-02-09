using MauiApp1.Models;

namespace MauiApp1.Views;

public partial class PgTodoList : ContentPage
{
	List<string> keyTodos = new List<string>();
	List<string> keyDates = new List<string>();
	List<TodoItem> todoList = new List<TodoItem>();

	public PgTodoList()
	{
		InitializeComponent();
		int count = Preferences.Default.Get("count", 0);
		string result = string.Empty;

		for (int i = 0; i < count; i++)
		{
			string keyTodo = "todo" + i;
			string keyDate = "date" + i;
			string todo = string.Empty;
			string date = string.Empty;
			if (Preferences.Default.ContainsKey(keyTodo)) todo = Preferences.Default.Get(keyTodo, "沒有資料");
			if (Preferences.Default.ContainsKey(keyDate)) date = Preferences.Default.Get(keyDate, "沒有資料");

			TodoItem item = new TodoItem()
			{
				Todo = todo,
				Date = date,
			};
			todoList.Add(item);

			keyTodos.Add(keyTodo);
			keyDates.Add(keyDate);
		}

		lvTodo.ItemsSource = todoList;
	}

	private void lvTodo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItemIndex < 0) return;
		App app = Application.Current as App;
		app.SelectedTodoItem = todoList[e.SelectedItemIndex];
		app.KeyTodo = keyTodos[e.SelectedItemIndex];
		app.KeyDate = keyDates[e.SelectedItemIndex];
		Navigation.PopAsync();
	}
}