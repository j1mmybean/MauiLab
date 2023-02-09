namespace MauiApp1.Views;

public partial class PgPreference : ContentPage
{
	public PgPreference()
	{
		InitializeComponent();
	}

	private void btnSave_Clicked(object sender, EventArgs e)
	{
		Preferences.Default.Set("k", txtSet.Text);
	}

	private void btnRead_Clicked(object sender, EventArgs e)
	{
		LabelGet.Text = Preferences.Default.Get("k", "沒有資料");
	}
}