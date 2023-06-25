namespace MathsMAUI;

public partial class GamePage : ContentPage
{
	private string _game { get; set; }
    public string GameName
	{
		get { return $"{_game} Area"; }
	}
    private int _firstNum { get; set; }
    private int _secondNum { get; set; }

	public GamePage(string game)
	{
		InitializeComponent();
		_game = game;
		BindingContext = this;

		GenerateQuestion();
	}

	private void GenerateQuestion()
	{
        char mathOperand = _game switch
        {
            "Addition" => '+',
            "Subtraction" => '-',
            "Multiplication" => 'x',
            "Division" => '\u00F7',
            _ => ' '
        };

		Random random = new();

		_firstNum = _game != "Division" ? random.Next(1, 9) : random.Next(1, 99);
        _secondNum = _game != "Division" ? random.Next(1, 9) : random.Next(1, 99);

		if (_game == "Division")
		{
			while (_firstNum < _secondNum || _firstNum % _secondNum != 0) 
			{
				_firstNum = random.Next(1, 99);
				_secondNum = random.Next(1, 99);
			}
		}

		Question.Text = $"{_firstNum} {mathOperand} {_secondNum}";
    }

	private void HandleAnswer(object sender, EventArgs e)
	{
		int solution;
		bool isUserAnswerNum = int.TryParse(AnswerInput.Text, out int intAnswer);

		if (isUserAnswerNum)
		{
			if (_game == "Addition")
			{
                solution = _firstNum + _secondNum;

                GameResponse(solution, intAnswer);
            }

            if (_game == "Subtraction")
            {
                solution = _firstNum - _secondNum;

                GameResponse(solution, intAnswer);
            }

            if (_game == "Multiplication")
            {
                solution = _firstNum * _secondNum;

                GameResponse(solution, intAnswer);
            }

            if (_game == "Division")
            {
                solution = _firstNum / _secondNum;

                GameResponse(solution, intAnswer);
            }
        }
		else
		{
            SolutionDisplay.Text = "Your answer is not a Number";
		}
	}

    private void GameResponse(int solution, int intAnswer)
    {
        if (intAnswer == solution)
        {
            SolutionDisplay.Text = "You got it right";
            AnswerInput.Text = "";
            GenerateQuestion();
        }
        else
        {
            SolutionDisplay.Text = "That's wrong. Try again";
        }
    }
}