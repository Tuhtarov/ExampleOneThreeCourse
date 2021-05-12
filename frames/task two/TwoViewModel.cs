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


        public TwoViewModel()
        {
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

        private string _InputValue;
        public string InputValue
        {
            set
            {
                if (CheckStringOnLetters(value))
                {
                    _InputValue = value.ToString();
                    RaisePropertyChanged("InputValue");
                }
                else
                {
                    _InputValue = "";
                    RaisePropertyChanged("InputValue");
                }
            }
            get
            {
                return _InputValue;
            }
        }

    }
}
