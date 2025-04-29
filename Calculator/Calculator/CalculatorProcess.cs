// <copyright file="CalculatorProcess.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace Calculator;

using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// Class of the calculator.
/// </summary>
public class CalculatorProcess : INotifyPropertyChanged
{
    /// <summary>
    /// Gets or sets current Value of the calculator.
    /// </summary>
    public float CurrentValue { get; set; }

    private string CurrentOperator { get; set; } = string.Empty;

    private float LastValue { get; set; }

    private bool ShouldRepeatLastOperator { get; set; } = false;

    private bool IsNegativeInput { get; set; } = false;

    private enum States
    {
        EnteringFirstOperand,
        EnteringOperator,
        EnteringSecondOperand,
    }

    private States State { get; set; } = States.EnteringFirstOperand;

    /// <summary>
    /// Proccess input commands.
    /// </summary>
    /// <param name="textButton">Text of the button.</param>
    public void ProcessInput(string textButton)
    {
        if (int.TryParse(textButton, out int value))
        {
            switch (this.State)
            {
                case States.EnteringFirstOperand:
                    this.CurrentValue = this.IsNegativeInput ? -value : value;
                    this.NotifyPropertyChanged(nameof(this.CurrentValue));
                    this.State = States.EnteringOperator;
                    this.IsNegativeInput = false;
                    break;
                case States.EnteringOperator:
                    var currentNumber = this.CurrentValue.ToString() + textButton;
                    if (int.TryParse(currentNumber, out int result))
                    {
                        this.CurrentValue = result;
                        this.NotifyPropertyChanged(nameof(this.CurrentValue));
                    }

                    break;
                case States.EnteringSecondOperand:
                    this.LastValue = this.CurrentValue;
                    this.CurrentValue = this.IsNegativeInput ? -value : value;
                    this.NotifyPropertyChanged(nameof(this.CurrentValue));
                    this.State = States.EnteringOperator;
                    this.ShouldRepeatLastOperator = false;
                    this.IsNegativeInput = false;
                    break;
            }
        }
        else if (textButton == "Clear")
        {
            this.Clear();
        }
        else if (textButton == "=")
        {
            if (this.State == States.EnteringOperator)
            {
                var tmp = this.CurrentValue;
                this.CurrentValue = this.Calculate(this.CurrentValue, this.CurrentOperator);
                if (!this.ShouldRepeatLastOperator)
                {
                    this.LastValue = tmp;
                }

                this.ShouldRepeatLastOperator = true;
            }

            this.NotifyPropertyChanged(nameof(this.CurrentValue));
        }
        else if (textButton == "-")
        {
            if (this.State == States.EnteringFirstOperand ||
                this.State == States.EnteringSecondOperand)
            {
                this.IsNegativeInput = true;
            }
            else
            {
                this.ProcessOperator(textButton);
            }
        }
        else
        {
            this.ProcessOperator(textButton);
        }
    }

    private void ProcessOperator(string textButton)
    {
        if (this.State == States.EnteringOperator &&
            !string.IsNullOrEmpty(this.CurrentOperator) &&
            !this.ShouldRepeatLastOperator)
        {
            this.CurrentValue = this.Calculate(this.CurrentValue, this.CurrentOperator);
        }

        this.CurrentOperator = textButton;
        this.State = States.EnteringSecondOperand;
        this.NotifyPropertyChanged(nameof(this.CurrentValue));
    }

    private void Clear()
    {
        this.State = States.EnteringFirstOperand;
        this.CurrentValue = 0;
        this.LastValue = 0;
        this.ShouldRepeatLastOperator = false;
        this.IsNegativeInput = false;
        this.NotifyPropertyChanged(nameof(this.CurrentValue));
    }

    private float Calculate(float inputValue, string operatorValue)
        => operatorValue switch
        {
            "+" => this.LastValue + inputValue,
            "-" => this.LastValue - inputValue,
            "*" => this.LastValue * inputValue,
            "/" => inputValue == 0 ? throw new DivideByZeroException() : this.LastValue / inputValue,
            _ => throw new InvalidOperationException($"Unknown operator: {operatorValue}"),
        };

    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
