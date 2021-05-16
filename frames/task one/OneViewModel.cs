using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PraktikaCourse3.frames.task_one
{

    class OneViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private string _inputValue;
        public string InputValueForMatch
        {
            set { 
                _inputValue = value; 
                RaisePropertyChanged("InputValueForMatch");

                try
                {
                    ComputationForResult(Convert.ToDouble(value));
                    RaisePropertyChanged("InputValueForMatch");
                }
                catch (Exception e)
                {
                    MathResult = $"Ожидание корректного ввода, так как: + {e.Message}";
                }
            }
            get { return _inputValue; }
        }

        private string _mathResult;
        public string MathResult
        {
            set { _mathResult = value; RaisePropertyChanged("MathResult"); }
            get { return _mathResult; }
        }

        private bool CheckOnDigitsAndComputation(string stroke)
        {
            for (int i = 0; i < stroke.Length; i++)
            {
                if (!Char.IsDigit(stroke[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void ComputationForResult(double x)
        {
            if(x >= 1.00)
            {
                var f1 = x - 1;
                MathResult = ComputationFunc(f1).ToString() + " (вычисление по первой ветке)";
            }
            else
            {
                var f2 = (x * x) + 1;
                MathResult = ComputationFunc(f2).ToString() + " (вычисление по второй ветке)";
            }
            
        } 
        
        private double ComputationFunc(double x)
        {
            var c = (Math.E * (Math.Sin(3) * x)) + Math.Log(x + 1);
            var z = Math.Sqrt(x);
            return c / z;
        }
    }
}
