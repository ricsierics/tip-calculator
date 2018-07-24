using System;
using Xamarin.Forms;

namespace TipCalculator
{
	public partial class MainPage : ContentPage
	{
        public string DeveloperName { get; } = "Rics";

        public MainPage()
		{
			InitializeComponent();

            imgDollar.Source = ImageSource.FromResource("TipCalculator.Resources.dollar.jpg"); //Build action: Embedded resource
		}

        private void Onbtn15PercentClicked(object sender, EventArgs e)
        {
            Process(Convert.ToDouble(entBill.Text), 0.15);
        }

        private void Onbtn20PercentClicked(object sender, EventArgs e)
        {
            Process(Convert.ToDouble(entBill.Text), 0.20);
        }

        private void OnbtnRoundDownClicked(object sender, EventArgs e)
        {
            Process(Convert.ToDouble(entBill.Text), sdrTipPercentage.Value/100, ComputeMode.RoundDown);
        }

        private void OnbtnRoundUpClicked(object sender, EventArgs e)
        {
            Process(Convert.ToDouble(entBill.Text), sdrTipPercentage.Value/100, ComputeMode.RoundUp);
        }

        private void OnsdrValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblTipPercent.Text = string.Format("{0:F2}%", e.NewValue);
            Process(Convert.ToDouble(entBill.Text), e.NewValue/100);
        }

        private void OnentBillTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                Process(0, sdrTipPercentage.Value / 100);
            }
            else
            {
                Process(Convert.ToDouble(e.NewTextValue), sdrTipPercentage.Value / 100);
            }
        }

        private bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
        
        private void UpdateUI(Calculator calculator)
        {
            sdrTipPercentage.Value = calculator.TipFactor*100;
            lblTipPercent.Text = string.Format("{0:F2}%", calculator.TipFactor*100);
            lblTipAmount.Text = $"${calculator.TipAmount.ToString("#,##0.00")}";
            lblTotal.Text = $"${calculator.TotalBill.ToString("#,##0.00")}";
        }

        private void Process(double billAmount, double tipFactor, ComputeMode computeMode = ComputeMode.Exact)
        {
            Calculator calculator;
            if (IsValid(entBill.Text))
            {
                calculator = new Calculator(billAmount, tipFactor, computeMode);
            }
            else
            {
                calculator = new Calculator(0, tipFactor, computeMode);
            }
            calculator.Calculate();
            UpdateUI(calculator);
        }
    }
}
