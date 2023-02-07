namespace MauiApp1.Views;

public partial class P2 : ContentPage
{
	public P2()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		App a = Application.Current as App;
		buttonP2.Text = a.User;

		//Navigation.PopAsync();
	}
}