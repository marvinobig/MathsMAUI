namespace MathsMAUI;

public partial class GameHistory : ContentPage
{
    private string _page { get; set; }
    public string PageName
    {
        get { return $"{_page} Screen"; }
    }
    public GameHistory(string page)
    {
        InitializeComponent();
        _page = page;
        BindingContext = this;
    }
}