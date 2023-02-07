//using Android.Icu.Text;

namespace MauiApp1.Views;

public partial class PgCalc : ContentPage
{
	List<int> numbers = new List<int>();
	List<string> operators = new List<string>();
	int number1;
	string op;
	public PgCalc()
	{
		InitializeComponent();
	}

	//private void InputNumber(object sender) 
	//{
	//	int output = Convert.ToInt32(LabelOutput.Text);
	//	Button button = sender as Button;
	//	if (output == 0) LabelOutput.Text = button.Text;
	//	else LabelOutput.Text += button.Text;

	//	LabelCalculation.Text += button.Text;
	//}

	//private void Operation(object sender)
	//{
	//	Button button = sender as Button;
	//	op = button.Text;
	//	number1 = Convert.ToInt32(LabelOutput.Text);
	//	GetResult();
	//	LabelOutput.Text = "0";
	//}

	private void GetResult()
	{
		numbers.Add(Convert.ToInt32(LabelOutput.Text));

		List<double> numbersTemp = numbers.Select(n => (double)n).ToList();
		List<string> operatorsTemp = new List<string>(operators);
		List<int> indices = new List<int>();

		for (int i = 0; i < operatorsTemp.Count; i++)
		{
			if (operatorsTemp[i] == "*")
			{
				numbersTemp[i + 1] = numbersTemp[i] * numbersTemp[i + 1];
				indices.Add(i);
			}
			if (operatorsTemp[i] == "/")
			{
				numbersTemp[i + 1] = numbersTemp[i] / numbersTemp[i + 1];
				indices.Add(i);
			}
		}

		operatorsTemp = operatorsTemp.Where(o => o != "*" || o != "/").ToList();
		List<double> numberList = new List<double>();
		for (int i = 0; i < numbersTemp.Count && !indices.Contains(i); i++)
		{
			numberList.Add(numbersTemp[i]);
		}
		numbersTemp = numberList;

		for (int i = 0; i < operatorsTemp.Count; i++)
		{
			if (operatorsTemp[i] == "+")
			{
				numbersTemp[i + 1] = numbersTemp[i] + numbersTemp[i + 1];
			}
			if (operatorsTemp[i] == "-")
			{
				numbersTemp[i + 1] = numbersTemp[i] - numbersTemp[i + 1];
			}
		}
		double result = numbersTemp[numbersTemp.Count - 1];

		LabelOutput.Text = result.ToString();
	}


	private void ButtonNumber_Clicked(object sender, EventArgs e)
	{
		int output = Convert.ToInt32(LabelOutput.Text);
		Button button = sender as Button;
		if (output == 0) LabelOutput.Text = button.Text;
		else LabelOutput.Text += button.Text;

		LabelCalculation.Text += button.Text;
	}

	private void ButtonOperation_Clicked(object sender, EventArgs e)
	{
		Button button = sender as Button;
		operators.Add(button.Text);
		numbers.Add(Convert.ToInt32(LabelOutput.Text));
		LabelOutput.Text = "0";

		LabelCalculation.Text += button.Text;
	}

	private void ButtonEqual_Clicked(object sender, EventArgs e)
	{
		GetResult();
	}

	private void ButtonClear_Clicked(object sender, EventArgs e)
	{
		LabelCalculation.Text = string.Empty;
		numbers.Clear();
		operators.Clear();
		LabelOutput.Text = "0";
	}
	//private void ButtonNumber_Clicked(object sender, EventArgs e)
	//{
	//	int output = Convert.ToInt32(LabelOutput.Text);
	//	Button button = sender as Button;
	//	if (output == 0 || string.IsNullOrEmpty(op)) LabelOutput.Text = button.Text;
	//	else LabelOutput.Text += button.Text;
	//}

	//private void ButtonOperation_Clicked(object sender, EventArgs e)
	//{
	//	Button button = sender as Button;
	//	op = button.Text;

	//	int number2 = Convert.ToInt32(LabelOutput.Text);
	//	if (op == "+") number1 = number1 + number2;
	//	else if (op == "-") number1 = number1 - number2;
	//	else if (op == "*") number1 = number1 * number2;
	//	else number1 = number1 / number2;// (op == "/")
	//	LabelOutput.Text = number1.ToString();
	//}

	//private void ButtonEqual_Clicked(object sender, EventArgs e)
	//{
	//	int number2 = Convert.ToInt32(LabelOutput.Text);
	//	if (op == "+") number1 = number1 + number2;
	//	else if (op == "-") number1 = number1 - number2;
	//	else if (op == "*") number1 = number1 * number2;
	//	else number1 = number1 / number2;// (op == "/")
	//	LabelOutput.Text = number1.ToString();
	//	op = string.Empty;
	//}
}