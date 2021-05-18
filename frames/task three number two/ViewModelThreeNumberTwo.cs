using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PraktikaCourse3.frames.task_three_number_two
{
    class ViewModelThreeNumberTwo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private int fromInputValue;
        private string _inputValue;
        public string InputValue
        {
            get
            {
                return _inputValue;
            }
            set
            {
                try
                {
                    fromInputValue = Convert.ToInt32(value);
                    _inputValue = $"{fromInputValue}";
                    InsertInArray(fromInputValue);
                }
                catch (Exception)
                {
                    _inputValue = "";
                    ArrayRefactoringWhereKBeforeValueOne = "";
                    MessageBox.Show("Ввод только цифр.");
                }
                RaisePropertyChanged("InputValue");
            }
        }

        private int fromBeforeValue;
        private int fromAfterValue;

        private string _beforeValue;
        public string BeforeValue
        {
            get
            {
                return _beforeValue;
            }
            set
            {
                try
                {
                    fromBeforeValue = Convert.ToInt32(value);
                    _beforeValue = $"{fromBeforeValue}";
                    RaisePropertyChanged("BeforeValue");
                }
                catch (Exception)
                {
                    _beforeValue = "-30";
                    MessageBox.Show("Ввод только цифр.");
                    RaisePropertyChanged("BeforeValue");
                }
            }
        }

        private string _afterValue;
        public string AfterValue
        {
            get
            {
                return _afterValue;
            }
            set
            {
                try
                {
                    fromAfterValue = Convert.ToInt32(value);
                    _afterValue = $"{fromAfterValue}";
                    RaisePropertyChanged("AfterValue");
                }
                catch (Exception)
                {
                    _afterValue = "40";
                    MessageBox.Show("Ввод только цифр.");
                    RaisePropertyChanged("AfterValue");
                }
            }
        }

        private string _arraySource;
        public string ArraySource
        {
            get
            {
                return _arraySource;
            }
            set
            {
                _arraySource = value;
                RaisePropertyChanged("ArraySource");
            }
        }

        //массивы, реализация которых происходит на основании исходного массива, где n=10
        private string _arrayRefactoringWhereEnditicalValueRemove;
        public string ArrayRefactoringWhereEnditicalValueRemove
        {
            get
            {
                return _arrayRefactoringWhereEnditicalValueRemove;
            }
            set
            {
                _arrayRefactoringWhereEnditicalValueRemove = value;
                RaisePropertyChanged("ArrayRefactoringWhereEnditicalValueRemove");
            }
        }

        private string _arrayRefactoringWhereKBeforeValueOne;
        public string ArrayRefactoringWhereKBeforeValueOne
        {
            get
            {
                return _arrayRefactoringWhereKBeforeValueOne;
            }
            set
            {
                _arrayRefactoringWhereKBeforeValueOne = value;
                RaisePropertyChanged("ArrayRefactoringWhereKBeforeValueOne");
            }
        }

        private string _arrayRefactoringWhereReplaceFirstThreeLastThree;

        public string ArrayRefactoringWhereReplaceFirstThreeLastThree
        {
            get
            {
                return _arrayRefactoringWhereReplaceFirstThreeLastThree;
            }
            set
            {
                _arrayRefactoringWhereReplaceFirstThreeLastThree = value;
                RaisePropertyChanged("ArrayRefactoringWhereReplaceFirstThreeLastThree");
            }
        }



        private Random rnd = new Random();

        private int[] _array = new int[10];

        //логика
        public ViewModelThreeNumberTwo()
        {
            UpdateData();
        }

        private void UpdateData()
        {
            _array = CreateArray(_array);
            ArraySource = GetStringFromArray(_array);
            ArrayRefactoringWhereEnditicalValueRemove = GetStringFromArray(RemoveArrayElementsWhereValuesidentical(_array));
            ArrayRefactoringWhereReplaceFirstThreeLastThree = GetStringFromArray(ReplaceThreeElementsInArray(_array));
            if (!string.IsNullOrWhiteSpace(InputValue))
            {
                if (fromInputValue != null)
                {
                    InsertInArray(fromInputValue);
                }
            }
        }


        //есть предположение, что лучше перезаписывать пришедший массив, а уже потом инициализировать arrayRef исходным, т.е после всех манипуляций с исходным массивом.
        //предположения оказались верны, ибо операция сортировки выполнялась несколько раз, но в итоге только одна из всех операций доходила до arrayRef.
        //UPD: на 100% эта логика не работает, так как при нахождении элемента, удовлетворяющй условию, удаляется перебираемый символ, но никак не все символы, при удалённом символе, оставшиеся не удаляться, 
        //ибо при методе .Count(), уже будет приходить значение меньшее, чем было до удаления элемента

        //РЕШЕНО: в итоге пришлось создать второй массив (arrayNew), который инициализируется уже в сортированном виде, а потом в случае положительного предиката,
        //он ещё раз пересортировывается, и таким образом все одиннаковые элементы из последовательности удаляются
        private int[] RemoveArrayElementsWhereValuesidentical(int[] array)
        {
            var arrayNew = array;
            for (int i = 0; i < array.Length; i++)
            {
                var query = array.Where(a => a == array[i]);
                if (query.Count() > 1)
                {
                    //arrayRef = (int[])array.Where(a => a != element).ToArray();
                    arrayNew = arrayNew.Where(a => a != array[i]).ToArray();
                }
            }
            return arrayNew;
        }

        private int[] ReplaceThreeElementsInArray(int[] array)
        {
            var arrayReplace = array;
            var v1 = 0;
            var v2 = 0;
            var v3 = 0;
            var v10 = 0;
            var v9 = 0;
            var v8 = 0;

            for (int i = 0; i < array.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        v1 = array[i];
                        break;
                    case 1:
                        v2 = array[i];
                        break;
                    case 2:
                        v3 = array[i];
                        break;
                    case 9:
                        v10 = array[i];
                        break;
                    case 8:
                        v9 = array[i];
                        break;
                    case 7:
                        v8 = array[i];
                        break;
                }
            }
            arrayReplace[0] = v8;
            arrayReplace[1] = v9;
            arrayReplace[2] = v10;
            arrayReplace[9] = v3;
            arrayReplace[8] = v2;
            arrayReplace[7] = v1;
            return arrayReplace;
        }

        private void InsertInArray(int value)
        {
            ArrayRefactoringWhereKBeforeValueOne = GetStringFromArray(InsertValueInArray(_array, value));
        }

        private int[] InsertValueInArray(int[] array, int value)
        {
            int[] firstMolety = new int[15];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 1)
                {
                    firstMolety = firstMolety.Append(array[i]).ToArray();
                }
                else
                {
                    firstMolety = firstMolety.Append(value).ToArray();
                    firstMolety = firstMolety.Append(array[i]).ToArray();
                }
            }
            var result = firstMolety.Where(v => v != 0).ToArray();
            return result;
        }

        public ICommand UpdateArraySource
        {
            get
            {
                return new RelayCommand(() => UpdateData());
            }
        }

        private int[] CreateArray(int[] arr)
        {
            var before = string.IsNullOrWhiteSpace(BeforeValue) ? -40 : fromBeforeValue;
            var after = string.IsNullOrWhiteSpace(AfterValue) ? 30 : fromAfterValue;
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rnd.Next(before, after);
                }
            }
            catch (Exception e)
            {
                BeforeValue = "-40";
                AfterValue = "30";
                before = string.IsNullOrWhiteSpace(BeforeValue) ? -40 : fromBeforeValue;
                after = string.IsNullOrWhiteSpace(AfterValue) ? 30 : fromAfterValue;
                MessageBox.Show($"{e.Message}");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rnd.Next(before, after);
                }
            }
            return arr;
        }

        private string GetStringFromArray(int[] array)
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
