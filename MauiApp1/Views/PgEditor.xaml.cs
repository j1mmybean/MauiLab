using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class PgEditor : ContentPage
{
	//CustomerViewModel vm = new CustomerViewModel();
	CustomerViewModel vm = null;

	public PgEditor()
	{
		InitializeComponent();
		vm = this.BindingContext as CustomerViewModel;
	}

	//private void Show()
	//{
	//	txtId.Text = vm.Current.id.ToString();
	//	txtName.Text = vm.Current.name;
	//	txtPhone.Text = vm.Current.phone;
	//	txtEmail.Text = vm.Current.email;
	//	txtAddress.Text = vm.Current.address;
	//}

	private void btnFirst_Clicked(object sender, EventArgs e)
	{
		vm.MoveFirst();
		//Show();
	}

	private void btnPrevious_Clicked(object sender, EventArgs e)
	{
		vm.MovePrevious();
		//Show();
	}

	private void btnNext_Clicked(object sender, EventArgs e)
	{
		vm.MoveNext();
		//Show();
	}

	private void btnLast_Clicked(object sender, EventArgs e)
	{
		vm.MoveLast();
		//Show();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		App app = Application.Current as App;
		if (!string.IsNullOrEmpty(app.Keyword))
		{
			vm.QueryByKeyword(app.Keyword);
			//if (vm.QueryByKeyword(app.Keyword) != null) Show();
		}
		else if (app.SelectedCustomerIndex >= 0)
		{
			vm.MoveTo(app.SelectedCustomerIndex);
			//Show();
		}
	}

	private void btnQuery_Clicked(object sender, EventArgs e)
	{
		ClearCache();
		Navigation.PushAsync(new PgKeyword());
	}

	private void ClearCache()
	{
		App app = Application.Current as App;
		app.Keyword = String.Empty;
		app.SelectedCustomerIndex = -1;
	}
	private void btnList_Clicked(object sender, EventArgs e)
	{
		ClearCache();
		App app = Application.Current as App;
		app.customerList = vm.All;
		Navigation.PushAsync(new PgList());
	}
}