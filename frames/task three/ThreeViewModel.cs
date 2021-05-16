using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PraktikaCourse3.frames.task_three
{
    class ThreeViewModel : INotifyPropertyChanged
    {
        private Random random = new Random();
        private int[] array = new int[15];

        private string _arrayUI;
        public string ArrayUI
        {
            get
            {
                return _arrayUI;
            }
            set
            {
                _arrayUI = value;
                RaisePropertyChanged("ArrayUI");
            }
        }

        private string _sumPositiveElements;
        public string SumPositiveElements { get { return _sumPositiveElements; } set { _sumPositiveElements = value; RaisePropertyChanged("SumPositiveElements"); } }

        private string _indexElementWhereValueEquals3And5;
        public string IndexElementWhereValueEquals3And5 { get { return _indexElementWhereValueEquals3And5; } set { _indexElementWhereValueEquals3And5 = value; RaisePropertyChanged("IndexElementWhereValueEquals3And5"); } }

        private string _arrayWhereFirstNegativeElementEqualsNull;
        public string ArrayWhereFirstNegativeElementEqualsNull { get { return _arrayWhereFirstNegativeElementEqualsNull; } set { _arrayWhereFirstNegativeElementEqualsNull = value; RaisePropertyChanged("ArrayWhereFirstNegativeElementEqualsNull"); } }

        private string _arrayMultiple;
        public string ArrayMultiple { get { return _arrayMultiple; } set { _arrayMultiple = value; RaisePropertyChanged("ArrayMultiple"); } }

        private int _inputValueInt = 0;


        private string _inputValue;
        public string InputValue
        {
            get
            {
                return _inputValue;
            }
            set
            {
                _inputValue = value;
                try
                {
                    if(value != "" && value != "-")
                    {
                        _inputValueInt = Convert.ToInt32(value);
                        ExecuteDetermineElementsWhereTheirSumEqualsInputValue(array);
                    }
                }
                catch (Exception e)
                {
                    _inputValue = "";
                    OutputOnUI = $"{e.Message}";
                }
            }
        }

        private string _outputOnUI;
        public string OutputOnUI
        {
            get
            {
                return _outputOnUI;
            }
            set
            {
                _outputOnUI = value;
                RaisePropertyChanged("OutputOnUI");
            }
        }

        public ThreeViewModel()
        {
            generateArray();
            ShowArray();
        }

        private void generateArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-12, 12);
            }
        }

        private void ShowArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                ArrayUI += $" {array[i]}";
            }
            ExecuteTaskSumm(array);
            ExecuteTaskIndexElWhere3and5(array);
            ExecuteTaskSummNegativeFirstEqualsNull(array);
            ExecuteTaskMultipleArray(array);
        }

        private void ExecuteDetermineElementsWhereTheirSumEqualsInputValue(int[] arr)
        {
            OutputOnUI = "";
            string ResultForOutPut = "";

            if (_inputValueInt != 0)
            {
                for (int i = 0; i < arr.Length-1; i++)
                {
                    if((arr[i] + arr[i+1]) == _inputValueInt)
                    {
                        ResultForOutPut += $"\n index {i} (знач. {arr[i]}) + index {i+1} (знач. {arr[i+1]}) == {InputValue} \t";
                    }
                }

                if (string.IsNullOrEmpty(ResultForOutPut))
                {
                    OutputOnUI = "Ничего не найдено";
                }
                else
                {
                    OutputOnUI += $"Совпадения с вводом найдены:{ResultForOutPut}";
                }
            }
        }

        private void ExecuteTaskSumm(int[] arr)
        {
            SumPositiveElements = "1) Сумма положительных эл., значения которых < 10: \t ";
            var summEl = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 10 && arr[i] > 0)
                {
                    summEl += arr[i];
                }
            }
            SumPositiveElements += $"{summEl}";
        }
        private void ExecuteTaskIndexElWhere3and5(int[] arr)
        {
            IndexElementWhereValueEquals3And5 = "2) Индексы эл., значения которых == числу 3 или 5: \t ";
            string ResultElements = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 3 || arr[i] == 5)
                {
                    ResultElements += $" {i++}";
                }
            }
            IndexElementWhereValueEquals3And5 += ResultElements;
        }

        private void ExecuteTaskSummNegativeFirstEqualsNull(int[] arr)
        {
            ArrayWhereFirstNegativeElementEqualsNull = "3) Новый массив, где первый отрицательный эл. заменён на 0: \t ";
            int IndexWhereFirstElementEqualsNull=0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0 && IndexWhereFirstElementEqualsNull == 0)
                {
                    IndexWhereFirstElementEqualsNull = i; 
                }
            }
            var newArrayResult = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if(i == IndexWhereFirstElementEqualsNull)
                {
                    arr[i] = 0;
                }
                newArrayResult += $" {arr[i]}";
            }
            ArrayWhereFirstNegativeElementEqualsNull += newArrayResult;
        }

        private void ExecuteTaskMultipleArray(int[] arr)
        {
            ArrayMultiple = "4) Новый массив, где все элементы == 3 умножены на значение 3 элемента массива: \t ";
            string ResultArray = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == 3)
                {
                    ResultArray += $" {arr[i] * arr[2]}";
                } else
                {
                    ResultArray += $" {arr[i]}";
                }
                
            }
            ArrayMultiple += ResultArray;
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
