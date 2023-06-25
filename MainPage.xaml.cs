namespace MathsMAUI;

public partial class MainPage : ContentPage
{
	public MainPage() { 
		InitializeComponent();
	}

	private async void ButtonAlert(object sender, EventArgs e)
	{
		Button btn = (Button)sender;

		switch (btn.Text)
		{
			case "Addition":
				await DisplayAlert("Game Chosen", "Addition", "Play");
				break;
			case "Subtraction":
                await DisplayAlert("Game Chosen", "Subtraction", "Play");
                break;
            case "Multiplication":
                await DisplayAlert("Game Chosen", "Multiplication", "Play");
                break;
            case "Division":
                await DisplayAlert("Game Chosen", "Division", "Play");
                break;
        }
	}
}

