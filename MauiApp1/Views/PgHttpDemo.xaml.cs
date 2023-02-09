namespace MauiApp1.Views;

public partial class PgHttpDemo : ContentPage
{
	public PgHttpDemo()
	{
		InitializeComponent();
	}

	private async void ButtonOK_Clicked(object sender, EventArgs e)
	{
		HttpClient client = new HttpClient();
		Uri uri = new Uri("https://www.google.com/");
		HttpResponseMessage response = await client.GetAsync(uri);
		if (response.IsSuccessStatusCode)
		{
			LabelHttp.Text = await response.Content.ReadAsStringAsync();
		}
	}
}