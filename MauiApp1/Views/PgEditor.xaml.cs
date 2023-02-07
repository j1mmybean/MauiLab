using MauiApp1.Models;

namespace MauiApp1.Views;

public partial class PgEditor : ContentPage
{
	int index=0;
	List<Customer> list = new List<Customer>();
	public PgEditor()
	{
		InitializeComponent();
		list.Add(new Customer() { id = 1, name = "jimmy", phone = "0000000000", email = "jimmy@gmail.com", address = "sdfasdsdf" });
		list.Add(new Customer() { id = 2, name = "tommy", phone = "0000000001", email = "tommy@gmail.com", address = "sddfasfasdf" });
		list.Add(new Customer() { id = 3, name = "mary", phone = "0000000002", email = "mary@gmail.com", address = "sgsgsdfasdf" });
	}

	private void Show(int index)
	{
		txtId.Text = list[index].id.ToString();
		txtName.Text = list[index].name;
		txtPhone.Text = list[index].phone;
		txtEmail.Text = list[index].email;
		txtAddress.Text = list[index].address;
	}

	private void btnFirst_Clicked(object sender, EventArgs e)
	{
		index = 0;
		Show(index);
	}

	private void btnPrevious_Clicked(object sender, EventArgs e)
	{
		if (index>0)index--;

		Show(index);
	}

	private void btnNext_Clicked(object sender, EventArgs e)
	{
		if (index < list.Count) index++;

		Show(index);
	}

	private void btnLast_Clicked(object sender, EventArgs e)
	{
		index = list.Count-1;

		Show(index);
	}

	private void btnQuery_Clicked(object sender, EventArgs e)
	{

	}

	private void btnList_Clicked(object sender, EventArgs e)
	{

	}
}