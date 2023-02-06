using MauiApp1.NewFolder;

namespace MauiApp1;

public partial class PgLotto : ContentPage
{
	public PgLotto()
	{
		InitializeComponent();

		List<int> numberIist = CLottoGen.GetLottoNumbers(6, 50);

		for (int i = 0; i < numberIist.Count(); i++)
		{
			LabelLottoNumbers.Text += numberIist[i] + ", ";
		}
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		List<int> numberIist = CLottoGen.GetLottoNumbers(6, 50);

		LabelLottoNumbers.Text = string.Empty;

		for (int i = 0; i < numberIist.Count(); i++)
		{
			LabelLottoNumbers.Text += numberIist[i] + ", ";
		}

	}
}