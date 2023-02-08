namespace MauiApp1.Views;

public partial class PgKeyword : ContentPage
{
	public PgKeyword()
	{
		InitializeComponent();
	}

	private void ButtonQuery_Clicked(object sender, EventArgs e)
	{
		App a = Application.Current as App;
		a.Keyword = EntryKeyword.Text;
		Navigation.PopAsync();
	}
}