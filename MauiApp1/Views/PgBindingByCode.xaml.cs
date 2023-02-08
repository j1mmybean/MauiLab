namespace MauiApp1.Views;

public partial class PgBindingByCode : ContentPage
{
	public PgBindingByCode()
	{
		InitializeComponent();
		label.BindingContext = slider;
		label.SetBinding(Label.FontSizeProperty, "Value");
	}
}