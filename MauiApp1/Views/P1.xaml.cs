namespace MauiApp1.Views;

public partial class P1 : ContentPage
{
	public P1()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		App a = Application.Current as App;
		a.User = "j1mmybean";

		Navigation.PushAsync(new P2());
	}
}