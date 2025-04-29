// <copyright file="CalculatorForm.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace Calculator;

/// <summary>
/// Form of the calculator.
/// </summary>
public partial class CalculatorForm : Form
{
    private readonly CalculatorProcess calculator = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
    /// </summary>
    public CalculatorForm()
    {
        this.InitializeComponent();
        this.InputLabel.DataBindings.Add("Text", this.calculator, "CurrentValue");

        this.MinimumSize = new Size(500, 500);
    }

    private void OnAllButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        string buttonText = button.Text;

        this.calculator.ProcessInput(buttonText);
    }
}
