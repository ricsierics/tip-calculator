using System;
using System.Collections.Generic;
using System.Text;

namespace TipCalculator
{
    public class Calculator
    {
        public double BillAmount { get; set; }
        public double TipFactor { get; set; }
        public double TipAmount { get; set; }
        public double TotalBill { get; set; }
        public ComputeMode ComputeMode { get; set; }

        public Calculator(double _billAmount, double _tipFactor, ComputeMode _computeMode)
        {
            BillAmount = _billAmount;
            TipFactor = _tipFactor;
            ComputeMode = _computeMode;
        }

        public void Calculate()
        {
            TipAmount = BillAmount * TipFactor;
            TotalBill = BillAmount + TipAmount;
            switch (ComputeMode)
            {
                case ComputeMode.Exact:
                    break;
                case ComputeMode.RoundUp:
                    TipAmount = Math.Ceiling(TipAmount);
                    TotalBill = Math.Ceiling(TotalBill);
                    break;
                case ComputeMode.RoundDown:
                    TipAmount = Math.Floor(TipAmount);
                    TotalBill = Math.Floor(TotalBill);
                    break;
                default:
                    break;
            }
        }
    }
}
