using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktikaCourse3.frames.task_four
{
    class ModelFour: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        protected Random rnd = new Random();

        private string _array_4_1;
        public string Array_4_1
        {
            get
            {
                return _array_4_1;
            }
            set
            {
                _array_4_1 = value;
                RaisePropertyChanged("Array_4_1");
            }
        }

        private string _array_4_2;
        public string Array_4_2
        {
            get
            {
                return _array_4_2;
            }
            set
            {
                _array_4_2 = value;
                RaisePropertyChanged("Array_4_2");
            }
        }

        private string _array_4_3;
        public string Array_4_3
        {
            get
            {
                return _array_4_3;
            }
            set
            {
                _array_4_3 = value;
                RaisePropertyChanged("Array_4_3");
            }
        }


        private string _array_4_4;
        public string Array_4_4
        {
            get
            {
                return _array_4_4;
            }
            set
            {
                _array_4_4 = value;
                RaisePropertyChanged("Array_4_4");
            }
        }

        //отрефакторенные массивы
        private string _arrayRef_4_1;
        public string ArrayRef_4_1
        {
            get
            {
                return _arrayRef_4_1;
            }
            set
            {
                _arrayRef_4_1 = value;
                RaisePropertyChanged("ArrayRef_4_1");
            }
        }

        private string _arrayRef_4_2;
        public string ArrayRef_4_2
        {
            get
            {
                return _arrayRef_4_2;
            }
            set
            {
                _arrayRef_4_2 = value;
                RaisePropertyChanged("ArrayRef_4_2");
            }
        }

        private string _arrayRef_4_3;
        public string ArrayRef_4_3
        {
            get
            {
                return _arrayRef_4_3;
            }
            set
            {
                _arrayRef_4_3 = value;
                RaisePropertyChanged("ArrayRef_4_3");
            }
        }
        
        private string _arrayRef_4_4;
        public string ArrayRef_4_4
        {
            get
            {
                return _arrayRef_4_4;
            }
            set
            {
                _arrayRef_4_4 = value;
                RaisePropertyChanged("ArrayRef_4_4");
            }
        }

        //сервис: создание массива  && получение в строковом формате
        protected string GetStringFromArray(int[,] array)
        {
            var arrayString = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                arrayString += "\v\v";
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayString += $"\t{array[i, j]}";
                }
            }
            return arrayString;
        }

        protected int[,] CreateMultipleArray(int[,] array)
        {
            var height = array.GetLength(0);
            var width = array.GetLength(1);
            var multipleArray = array;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    multipleArray[i, j] = rnd.Next(0, 10);

                }
            }
            return multipleArray;
        }

        protected int[,] CreateMultipleArray(int[,] array, int value)
        {
            var height = array.GetLength(0);
            var width = array.GetLength(1);
            var multipleArray = array;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    multipleArray[i, j] = value;

                }
            }
            return multipleArray;
        }

        protected string GetStringFromVector(int[] array)
        {
            var arrayString = "";
            for (int i = 0; i < array.Length; i++)
            {
                arrayString += $" {array[i]}";
            }
            return arrayString;
        }
    }
}
