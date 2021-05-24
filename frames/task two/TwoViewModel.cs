using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PraktikaCourse3.frames.task_two
{
    class TwoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        // Свойства из задания 2.1
        private string _qtyDigitInValue;
        public string QtyDigitInValue
        {
            set
            {
                _qtyDigitInValue = value;
                RaisePropertyChanged("QtyDigitInValue");
            }
            get
            {
                return _qtyDigitInValue;
            }
        }

        private string _InputValue;
        public string InputValue
        {
            set
            {
                if (CheckStringOnLetters(value))
                {
                    _InputValue = value;
                    CountQtyDigit(value);
                    RaisePropertyChanged("InputValue");
                    DetermineResult();
                }
                else
                {
                    _InputValue = "";
                    _qtyDigitInValue = "";
                    ResultAB = "Пустые поля";
                    RaisePropertyChanged("QtyDigitInValue");
                    RaisePropertyChanged("InputValue");
                }
            }
            get
            {
                return _InputValue;
            }
        }

        //---------------------



        // Свойства из задания 2.2
        private string _digitA;
        public string DigitA
        {
            set
            {
                _digitA = value;
                RaisePropertyChanged("DigitA");
                DetermineResult();
            }
            get
            {
                return _digitA;
            }
        }

        private string _digitB;
        public string DigitB
        {
            set
            {
                _digitB = value;
                RaisePropertyChanged("DigitB");
                DetermineResult();
            }
            get
            {
                return _digitB;
            }
        }

        private string _resultAB;
        public string ResultAB
        {
            set
            {
                _resultAB = value;
                RaisePropertyChanged("ResultAB");
            }
            get
            {
                return _resultAB;
            }
        }

        private void DetermineResult()
        {
            if (!string.IsNullOrWhiteSpace(DigitA) && !string.IsNullOrWhiteSpace(DigitB))
            {
                var A = DigitA.ToCharArray().First();
                var B = DigitB.ToCharArray().First();
                if (_InputValue.ToCharArray().First() == A && _InputValue.ToCharArray().Last() == B)
                {
                    ResultAB = "Да";
                }
                else
                {
                    ResultAB = "Нет";
                }
            }
            else
            {
                ResultAB = "Введите цифру А и Б";
            }
        }

        //----------Бизнес логика-----------
        private void CountQtyDigit(string sequence)
        {
            char oneDigit = '0';
            int qty = 0;
            var digitArray = sequence.ToCharArray();
            for (int i = 0; i < digitArray.Length; i++)
            {
                if(i == 0)
                {
                    oneDigit = digitArray[i];
                }
                else
                {
                    if(oneDigit == digitArray[i])
                    {
                        qty++; 
                        QtyDigitInValue = qty.ToString();
                    }
                }
            }

        }

        private bool CheckStringOnLetters(string sequence)
        {
            if(sequence.Length != 0)
            {
                foreach (var i in sequence.ToCharArray())
                {

                    if (!Char.IsDigit(i))
                    {
                        MessageBox.Show("Ввести можно только цифры!", "Ошибка");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
