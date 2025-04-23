using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator;

/// <summary>
/// Class of the calculator.
/// </summary>
public class Calculator : INotifyPropertyChanged
{
    private float currentValue = 0;
    public float CurrentValue {
        get { return currentValue; }
        set
        {
            if (currentValue != value)
            {
                currentValue = value;
                NotifyPropertyChanged();
            }
        }
    }

    private bool IsOperandEntered { get; set; } = false;
    private bool IsOperatorEntered { get; set; } = false;
    private string CurrentOperator { get; set; } = string.Empty;

    enum States { EnteringFirstOperand, EnteringOperator, EnteringSecondOperand }
    private States State { get; set; } = States.EnteringFirstOperand;

    public void ProcessInput(string textButton)
    {
        if (int.TryParse(textButton, out int value))
        {
            switch (State)
            {
                case States.EnteringFirstOperand:
                    CurrentValue = value;
                    State = States.EnteringOperator;
                    break;
                case States.EnteringOperator:
                    var currentNumber = CurrentValue.ToString() + textButton;
                    if (int.TryParse(currentNumber, out int result))
                    {
                        CurrentValue = result;
                    }
                    break;
                case States.EnteringSecondOperand:
                    CurrentValue = Calculate(value, CurrentOperator);
                    State = States.EnteringFirstOperand;
                    break;
            }
        }
        else if (textButton == "Clear")
        {
            IsOperatorEntered = false;
            IsOperandEntered = false;
            State = States.EnteringFirstOperand;
            CurrentValue = 0;
        }
        else if (textButton == "=")
        {
            State = States.EnteringOperator;
        }
        else
        {
            if (State == States.EnteringOperator)
            {
                CurrentOperator = textButton;
                State = States.EnteringSecondOperand;
            }
        }
    }

    public float Calculate(float inputValue, string operatorValue)
        => operatorValue switch
        {
            "+" => inputValue + CurrentValue,
            "-" => CurrentValue - inputValue,
            "*" => inputValue * CurrentValue,
            "/" => inputValue == 0 ? throw new DivideByZeroException() : CurrentValue / inputValue,
            _ => throw new InvalidOperationException($"Unknown operator: {operatorValue}")
        };
    

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
