namespace MauiApp1.Views;

public partial class PgClickDemo : ContentPage
{
	public PgClickDemo()
	{
		InitializeComponent();
	}

	//public double a => double.Parse(Entry1.Text);
	//public double b => double.Parse(Entry2.Text);
	//public double c => double.Parse(Entry2.Text);

	private void Button_Clicked(object sender, EventArgs e)
	{
		double a = double.Parse(Entry1.Text);
		double b = double.Parse(Entry2.Text);
		double c = double.Parse(Entry3.Text);
		double r = Math.Sqrt(b * b - 4 * a * c);
		double solution1 = (-b + r) / 2 * a;
		double solution2 = (-b - r) / 2 * a;
		LabelShow.Text = "X = " + solution1.ToString("0.0#") +" or "+ solution2.ToString();
	}
}