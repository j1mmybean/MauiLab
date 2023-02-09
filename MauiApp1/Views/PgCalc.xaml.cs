//using Android.Icu.Text;

namespace MauiApp1.Views;

public partial class PgCalc : ContentPage
{
	List<int> numbers = new List<int>();
	List<string> operators = new List<string>();
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
			while (operatorsTemp[i] == "*" || operatorsTemp[i] == "/")
			{
				if (operatorsTemp[i] == "*")
				{
					numbersTemp[i + 1] = numbersTemp[i] * numbersTemp[i + 1];
					indices.Add(i);
				}
				else if (operatorsTemp[i] == "/")
				{
					numbersTemp[i + 1] = numbersTemp[i] / numbersTemp[i + 1];
					indices.Add(i);
				}
			}
		}

		operatorsTemp = operatorsTemp.Where(o => o == "+" || o == "-").ToList();
		List<double> numberList = new List<double>();
		for (int i = 0; i < numbersTemp.Count; i++)
		{
			if (!indices.Contains(i))
			{
				numberList.Add(numbersTemp[i]);
			}
		}
		numbersTemp = numberList;

		double result = numbersTemp[0];
		for (int i = 0; i < operatorsTemp.Count; i++)
		{
			if (operatorsTemp[i] == "+")
			{
				result += numbersTemp[i + 1];
			}
			else if (operatorsTemp[i] == "-")
			{
				result -= numbersTemp[i + 1];
			}
		}

		LabelOutput.Text = result.ToString();

		//«ö=«á¦A«ö*·|¿ù
		numbers.Clear();
		operators.Clear();

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
}