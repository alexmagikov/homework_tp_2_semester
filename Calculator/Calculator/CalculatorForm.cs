namespace Calculator;

public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new();
    public CalculatorForm() 
    {
        InitializeComponent();
        InputLabel.DataBindings.Add(
            "Text",
            calculator,
            "CurrentValue"
        );
    }

    private void OnAllButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        string buttonText = button.Text;
        
        calculator.ProcessInput(buttonText);
    }
}
