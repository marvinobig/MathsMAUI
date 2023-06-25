namespace MathsMAUI;

public partial class GamePage : ContentPage
{
	private string _game { get; set; }
    public string GameName
	{
		get { return $"{_game} Game"; }
	}
	public GamePage(string game)
	{
		InitializeComponent();
		_game = game;
		BindingContext = this;
	}

}