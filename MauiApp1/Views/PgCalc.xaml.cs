//using Android.Icu.Text;

namespace MauiApp1.Views;

public partial class PgCalc : ContentPage
{
	int number1;
	string op;
	public PgCalc()
	{
		InitializeComponent();
	}

	private void InputNumber(object sender) 
	{
		int output = Convert.ToInt32(LabelOutput.Text);
		Button button = sender as Button;
		if (output == 0) LabelOutput.Text = button.Text;
		else LabelOutput.Text += button.Text;
	}

	private void Operation(object sender)
	{
		Button button = sender as Button;
		op = button.Text;
		//number1 = Convert.ToInt32(LabelOutput.Text);
		GetResult();
		LabelOutput.Text = "0";
	}

	private void GetResult()
	{
		int number2 = Convert.ToInt32(LabelOutput.Text);
		if (op == "+") number1 = number1 + number2;
		else if (op == "-") number1 = number1 - number2;
		else if (op == "*") number1 = number1 * number2;
		else number1 = number1 / number2;// (op == "/")
		LabelOutput.Text = number1.ToString();
	}

	private void ButtonEqual_Clicked(object sender, EventArgs e)
	{
		GetResult();
	}

	private void ButtonNumber_Clicked(object sender, EventArgs e)
	{
		InputNumber(sender);
	}

	private void ButtonOperation_Clicked(object sender, EventArgs e)
	{
		Operation(sender);
	}
}