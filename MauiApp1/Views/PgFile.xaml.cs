namespace MauiApp1.Views;

public partial class PgFile : ContentPage
{
	public PgFile()
	{
		InitializeComponent();
	}

	private void ButtonSave_Clicked(object sender, EventArgs e)
	{
		string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string path = Path.Combine(folder, "text.txt");
		File.WriteAllText(path, txtSet.Text);
		txtSet.Text = string.Empty;
	}

	private void ButtonRead_Clicked(object sender, EventArgs e)
	{
		string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string path = Path.Combine(folder, "text.txt");
		LabelGet.Text = File.ReadAllText(path);
	}
}