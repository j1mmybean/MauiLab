using System;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;
	Dictionary<string, string> colorLabel = new Dictionary<string, string>();
	public MainPage()
	{
		colorLabel.Add(LabelBlue.Text, "藍");
		colorLabel.Add(LabelGreen.Text, "綠");
		colorLabel.Add(LabelYellow.Text, "黃");
		colorLabel.Add(LabelRed.Text, "紅");
		InitializeComponent();
		Random random = new Random(Guid.NewGuid().GetHashCode());

		LabelBlue.Text = Choose(colorLabel, LabelBlue.Text);
		LabelGreen.Text = Choose(colorLabel, LabelGreen.Text);
		LabelYellow.Text = Choose(colorLabel, LabelYellow.Text);
		LabelRed.Text = Choose(colorLabel, LabelRed.Text);
	}

	private string Choose(Dictionary<string,string> dictionary, string labelText)
	{
		int index;
		string colorText;
		List<string> colors = dictionary.Keys.ToList();
		if (colors.Count() == 1) return colors[0];
		//為了不讓最後剩的顏色和Label對應到的顏色相同
		if (colors.Count == 2)
		{
			if (dictionary.ContainsValue(colors[0]) && dictionary[labelText] != colors[0])
			{
				colorText = colors[0];
				colors.RemoveAt(0);
				return colorText;

			}
			if (dictionary.ContainsValue(colors[1]) && dictionary[labelText] != colors[1])
			{
				colorText = colors[1];
				colors.RemoveAt(1);
				return colorText;
			};
		}

		Random random = new Random(Guid.NewGuid().GetHashCode());
		do
		{
			index = random.Next(0, colors.Count());
			colorText = colors[index];
		} while (dictionary[labelText] == colorText);
		colors.RemoveAt(index);
		dictionary.Remove(labelText);
		return colorText;
	}
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

