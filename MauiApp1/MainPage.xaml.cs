using System;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	List<string> colorList = new List<string> { "藍", "綠", "黃", "紅" };

	string blue = "藍";
	string green = "綠";
	string yellow = "黃";
	string red = "紅";
	public MainPage()
	{
		InitializeComponent();
	}

	private string Choose(List<string> textsLeft, List<string> labelsLeft, string labelColor)
	{
		//為了不讓最後Text剩的顏色和Label對應到的顏色相同
		if (textsLeft.Count == 2)
		{
			foreach (var text in textsLeft)
			{
				if (labelsLeft.Contains(text) && labelColor != text)
				{
					textsLeft.Remove(text);
					labelsLeft.Remove(labelColor);

					return text;
				}
			}
		}

		int index;
		string labelText;

		Random random = new Random(Guid.NewGuid().GetHashCode());
		do
		{
			index = random.Next(0, textsLeft.Count);
			labelText = textsLeft[index];
		} while (labelColor == labelText);

		textsLeft.RemoveAt(index);
		labelsLeft.Remove(labelColor);

		return labelText;
	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		List<string> textsLeft = new List<string>(colorList);
		List<string> labelsLeft = new List<string>(colorList);

		LabelGreen.Text = Choose(textsLeft, labelsLeft, green);
		LabelBlue.Text = Choose(textsLeft, labelsLeft, blue);
		LabelRed.Text = Choose(textsLeft, labelsLeft, red);
		LabelYellow.Text = Choose(textsLeft, labelsLeft, yellow);
	}
}

