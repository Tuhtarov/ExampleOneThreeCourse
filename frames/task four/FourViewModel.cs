using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PraktikaCourse3.frames.task_four
{
    class FourViewModel : ModelFour
    {
        private int[,] array4_1;
        private int[,] array4_2;
        private int[,] array4_3;
        private int[,] array4_4;

        

        private void OnErrorInput()
        {
            NqtyEl = "5";
            MqtyEl = "5";
            RaisePropertyChanged("NqtyEl");
            RaisePropertyChanged("MqtyEl");
        }

        //логика
        public FourViewModel()
        {
            UpdateArrays();
        }

        public ICommand Update
        {
            get
            {
                return new RelayCommand(() => UpdateArrays());
            }
        }

        private int[] twoStroke = new int[7];
        private int[] LastStroke = new int[7];

        private int[] threeStroke = new int[7];
        private int[] fourStroke = new int[7];
        private int[] FiveStroke = new int[7];
        private int[] SixStroke = new int[7];
        private int[] SevenStroke = new int[7];
        private int[] EighStroke = new int[7];

        private int[,] ExecuteTask4_4(int[,] e)
        {
            var height = e.GetLength(0);
            var width = e.GetLength(1);
            List<int> arr = new List<int> { };
            var result = e;

            //тут вставляются абсолютные значения в первые 3 колонки массива
            for (int i = 0; i < width; i++)
            {
                arr.Clear();
                for (int j = 0; j < height; j++)
                {
                    arr.Add(e[j, i]);
                }
                int summ = arr.Sum();
                for (int j = 0; j < height; j++)
                {
                    if(i < 3)
                    {
                        result[j, i] = summ;
                    }
                }
            }


            //тут меняются местами 2 и последняя строка
            arr.Clear();
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (i > 6)
                    {
                        LastStroke[j] = result[i, j];
                    }
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if(i == 1)
                    {
                        twoStroke[j] = result[i, j];
                    }
                    else
                    {
                        if (i == 2)
                        {
                            threeStroke[j] = result[i, j];
                        }
                        else
                        {
                            if (i == 3)
                            {
                                fourStroke[j] = result[i, j];
                            }
                            else
                            {
                                if (i == 4)
                                {
                                    FiveStroke[j] = result[i, j];
                                }
                                else
                                {
                                    if (i == 5)
                                    {
                                        SixStroke[j] = result[i, j];
                                    }
                                    else
                                    {
                                        if (i == 6)
                                        {
                                            SevenStroke[j] = result[i, j];
                                        }
                                        else
                                        {
                                            if (i == 7)
                                            {
                                                EighStroke[j] = result[i, j];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (i > 6)
                    {
                        result[i, j] = twoStroke[j];
                    }
                }

                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (i == 1)
                    {
                        result[i, j] = LastStroke[j];
                    }
                }
            }

            int[,] _newArray = new int[9, 7];
            var newArray = CreateMultipleArray(_newArray, 0);

            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    if(i < 4)
                    {
                        newArray[i, j] = result[i, j];
                    }
                    else
                    {
                        if(i == 4)
                        {
                            newArray[i, j] = twoStroke[j];
                        }
                        else
                        {
                            if(i == 5)
                            {
                                newArray[i, j] = FiveStroke[j];
                            }
                            else
                            {
                                if (i == 6)
                                {
                                    newArray[i, j] = SixStroke[j];
                                }
                                else
                                {
                                    if(i == 7)
                                    {
                                        newArray[i, j] = SevenStroke[j];
                                    }
                                    else
                                    {
                                        if(i == 8)
                                        {
                                            newArray[i, j] = EighStroke[j];
                                        }
                                        else
                                        {
                                            if(i == 9)
                                            {
                                                newArray[i, j] = LastStroke[j];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
            return newArray;
        }

        private int[,] ExecuteTask4_3(int[,] a)
        {
            var n = N_4_3;
            var e = a;
            e[0, 0] = 1;
            e[0, 1] = 0;
            e[0, 2] = 0;
            e[0, 3] = 0;
            e[0, 4] = 0;
            e[0, 5] = 0;
            e[0, 6] = 1;

            e[1, 0] = 1;
            e[1, 1] = 1;
            e[1, 2] = 0;
            e[1, 3] = 0;
            e[1, 4] = 0;
            e[1, 5] = 1;
            e[1, 6] = 1;

            e[2, 0] = 1;
            e[2, 1] = 1;
            e[2, 2] = 1;
            e[2, 3] = 0;
            e[2, 4] = 1;
            e[2, 5] = 1;
            e[2, 6] = 1;

            e[3, 0] = 1;
            e[3, 1] = 1;
            e[3, 2] = 1;
            e[3, 3] = 1;
            e[3, 4] = 1;
            e[3, 5] = 1;
            e[3, 6] = 1;

            e[4, 0] = n - 1;
            e[4, 1] = n;
            e[4, 2] = 0;
            e[4, 3] = 0;
            e[4, 4] = 0;
            e[4, 5] = 0;
            e[4, 6] = 0;

            e[5, 0] = n;
            e[5, 1] = 0;
            e[5, 2] = 0;
            e[5, 3] = 0;
            e[5, 4] = 0;
            e[5, 5] = 0;
            e[5, 6] = 0;

            e[6, 0] = 1;
            e[6, 1] = 0;
            e[6, 2] = 0;
            e[6, 3] = 0;
            e[6, 4] = 0;
            e[6, 5] = 0;
            e[6, 6] = 1;
            return e;
        }

        private string ExecuteTask4_2(int[,] e)
        {
            var height = e.GetLength(0);
            var width = e.GetLength(1);
            List<int> arr = new List<int> { };
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    arr.Add(e[j, i]);
                }
                for (int j = 0; j < height; j++)
                {
                    var query = arr.Where(ar => ar == e[j, i]);
                    if (query.Count() == 3)
                    {
                        var kek = arr.ToArray();
                        return $"\n\t{GetStringFromVector(kek)}" + "\n\tПоследовательность, где удовлетворяется условие";
                    }
                }
                arr.Clear();
            }
            return "\n\tНе существует";
        }

        private string ExecuteTask4_1(int[,] e)
        {
            var vector = "";
            if (N_4_1 > 0 && N_4_1 <= e.GetLength(1))
            {
                var array = e;
                List<int> list = new List<int> { };
                for (int i = 0; i < e.GetLength(0); i++)
                {
                    for (int j = 0; j < N_4_1; j++)
                    {
                        list.Add(e[i, j]);
                    }
                    var query = list.Sum();
                    vector += $" {query}";
                    list.Clear();
                }
            }
            else
            {
                vector = "Введите корректный номер элемента строки";
            }
            return vector;
        }




        //сервис
        private void UpdateArrays()
        {
            array4_1 = CreateMultipleArray(new int[4, 6]);
            array4_2 = CreateMultipleArray(new int[5, 5]);
            array4_3 = CreateMultipleArray(new int[7, 7], 0);
            array4_4 = CreateMultipleArray(new int[8, 7]);
            UpdateDataInUI();
        }

        private void UpdateDataInUI()
        {
            Array_4_1 = GetStringFromArray(array4_1) + $"\n\v\v\tстрок = {array4_1.GetLength(0)}\t колонок = {array4_1.GetLength(1)}";
            Array_4_2 = GetStringFromArray(array4_2) + $"\n\v\v\tстрок = {array4_2.GetLength(0)}\t колонок = {array4_2.GetLength(1)}";
            Array_4_3 = GetStringFromArray(array4_3) + $"\n\v\v\tстрок = {array4_3.GetLength(0)}\t колонок = {array4_3.GetLength(1)}";
            Array_4_4 = GetStringFromArray(array4_4) + $"\n\v\v\tстрок = {array4_4.GetLength(0)}\t колонок = {array4_4.GetLength(1)}";
            UpdateRefArrays();
        }
        private void UpdateRefArrays()
        {
            ArrayRef_4_1 = ExecuteTask4_1(array4_1);
            ArrayRef_4_2 = ExecuteTask4_2(array4_2);
            ArrayRef_4_3 = GetStringFromArray(ExecuteTask4_3(array4_3));
            ArrayRef_4_4 = GetStringFromArray(ExecuteTask4_4(array4_4));
            //ArrayRef_4_4 = GetStringFromArray(array4_4) + $"\n\v\v\tстрок = {array4_4.GetLength(0)}\t колонок = {array4_4.GetLength(1)}";
        }

        private void Update_4_2()
        {
            var n = string.IsNullOrEmpty(NqtyEl) ? 5 : _n;
            var m = string.IsNullOrEmpty(MqtyEl) ? 5 : _m;
            array4_2 = CreateMultipleArray(new int[n, m]);
            ArrayRef_4_2 = ExecuteTask4_2(array4_2);
            Array_4_2 = GetStringFromArray(array4_2) + $"\n\v\v\tстрок = {array4_2.GetLength(0)}\t колонок = {array4_2.GetLength(1)}";
        }

        //сервис задания 4_1
        private string _inputN_4_1;
        private int N_4_1;
        public string InputN_4_1
        {
            get
            {
                return _inputN_4_1;
            }
            set
            {
                try
                {
                    var val = Convert.ToInt32(value);
                    if(val > 0 && val <= array4_1.GetLength(1))
                    {
                        N_4_1 = val;
                        UpdateRefArrays();
                        _inputN_4_1 = value;
                    }
                    else
                    {
                        _inputN_4_1 = "";
                    }

                }
                catch (Exception e)
                {
                    _inputN_4_1 = "";
                }
                finally
                {
                    RaisePropertyChanged("InputN_4_1");
                }
            }
        }

        //сервис задания 4_3
        private string _inputN_4_3;
        private int N_4_3;
        public string InputN_4_3
        {
            get
            {
                return _inputN_4_3;
            }
            set
            {
                try
                {
                    var val = Convert.ToInt32(value);
                    if (val > 0 && val <= 7)
                    {
                        N_4_3 = val;
                        UpdateRefArrays();
                        _inputN_4_3 = value;
                    }
                    else
                    {
                        _inputN_4_3 = "";
                    }

                }
                catch (Exception e)
                {
                    _inputN_4_3 = "";
                }
                finally
                {
                    RaisePropertyChanged("InputN_4_3");
                }
            }
        }

        //мои добавки к UI (для удобства администрирования и понтов (работает через жопу)) </> UPD: НО РАБОТАЕТ))))
        private int _n;
        private int _m;
        private string _NqtyEl;
        private string _MqtyEl;
        public string NqtyEl
        {
            get
            {
                return _NqtyEl;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        _n = Convert.ToInt32(value);
                        if (_n > 10)
                        {
                            _n = 5;
                            OnErrorInput();
                        }
                        _NqtyEl = _n.ToString();
                        RaisePropertyChanged("NqtyEl");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"{e.Message}");
                        OnErrorInput();
                    }
                }
                else
                {
                    _n = 5;
                }
                Update_4_2();
            }
        }
        public string MqtyEl
        {
            get
            {
                return _MqtyEl;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        _m = Convert.ToInt32(value);
                        if (_m > 10)
                        {
                            _m = 5;
                            OnErrorInput();
                        }
                        _MqtyEl = _m.ToString();
                        RaisePropertyChanged("MqtyEl");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"{e.Message}");
                        OnErrorInput();
                    }
                }
                else
                {
                    _m = 5;
                }
                Update_4_2();
            }
        }
    }
}