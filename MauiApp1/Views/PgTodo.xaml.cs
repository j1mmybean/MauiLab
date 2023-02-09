//using Java.Util;

//using static Android.Telephony.CarrierConfigManager;

namespace MauiApp1.Views;

public partial class PgTodo : ContentPage
{
	public PgTodo()
	{
		InitializeComponent();
	}

	private void ButtonAdd_Clicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtTodo.Text) || string.IsNullOrEmpty(txtDate.Text)) return;
		int count = Preferences.Default.Get("count", 0);

		string keyTodo = "todo" + count;
		string keyDate = "date" + count;
		Preferences.Default.Set(keyTodo, txtTodo.Text);
		Preferences.Default.Set(keyDate, txtDate.Text);

		count++;
		Preferences.Default.Set("count", count);

		txtTodo.Text = string.Empty;
		txtDate.Text = string.Empty;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		App app = Application.Current as App;
		if (app.SelectedTodoItem == null) return;
		txtTodo.Text = app.SelectedTodoItem.Todo;
		txtDate.Text = app.SelectedTodoItem.Date;
	}
	private void ButtonTodoList_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new PgTodoList());
	}

	private void ButtonEdit_Clicked(object sender, EventArgs e)
	{
		App app = Application.Current as App;
		if (app.KeyTodo == null || app.KeyDate == null) return;
		Preferences.Default.Set(app.KeyTodo, txtTodo.Text);
		Preferences.Default.Set(app.KeyDate, txtDate.Text);

		txtTodo.Text = string.Empty;
		txtDate.Text = string.Empty;
	}

	private void ButtonDelete_Clicked(object sender, EventArgs e)
	{
		App app = Application.Current as App;
		if (app.KeyTodo == null || app.KeyDate == null) return;
		Preferences.Default.Remove(app.KeyTodo);
		Preferences.Default.Remove(app.KeyDate);
		txtTodo.Text = string.Empty;
		txtDate.Text = string.Empty;
	}
}