using MauiApp1.Views;

namespace MauiApp1;

public partial class App : Application
{
	public string User { get; set; }
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new PgEditor());
	}
}
