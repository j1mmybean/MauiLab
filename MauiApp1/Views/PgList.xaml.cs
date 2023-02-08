namespace MauiApp1.Views;

public partial class PgList : ContentPage
{
	public PgList()
	{
		InitializeComponent();
		App app = Application.Current as App;
		lvCustomer.ItemsSource = app.customerList;
	}

	private void lvCustomer_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItemIndex < 0 ) return;
		App app = Application.Current as App;
		app.SelectedCustomerIndex = e.SelectedItemIndex;
		Navigation.PopAsync();
	}
}