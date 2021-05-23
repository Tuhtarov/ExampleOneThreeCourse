using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PraktikaCourse3.frames.task_six
{
    class SixViewModelBase : INotifyPropertyChanged
    {
        Random rnd = new Random();

        protected void ExecuteTask6_2()
        {
            NewFile_6_2 = ReadAllFromFile(CreateNewFile6_2());
            RefFile_6_2 = ReadAllFromFile(CreateRefFile6_2());
        }

        protected void ExecuteTask6_3()
        {
            NewFile_6_3 = ReadAllFromFile(CreateNewFile6_3());
            RefFile_6_3 = ReadAllFromFile(CreateRefFile6_3());
        }

        protected void ExecuteTask6_4()
        {
            NewFile_6_4 = ReadAllFromFile(CreateNewFile6_4_ONE());
            RefFile_6_4 = ReadAllFromFile(CreateNewFile6_4_TWO());
            SummOutput_6_4 = ComputationSumm_6_4(NewFile_6_4, RefFile_6_4);
        }

        protected void ExecuteTask6_5()
        {
            if (string.IsNullOrEmpty(InputTextFor_6_5) != true)
            {
                NewFile_6_5 = ReadAllFromFile(CreateNewFile6_5());
                RefFile_6_5 = ReadAllFromFile(CreateRefFile6_5());
            }
            else
            {
                MessageBox.Show("Поле пустое");
                NewFile_6_5 = "";
                RefFile_6_5 = "";
            }
        }

        protected void ExecuteTask6_1()
        {
            NewFile_6_1 = ReadAllFromFile(CreateNewFile6_1());
            if (string.IsNullOrEmpty(InputTextFor_6_1))
            {
                InputTextFor_6_1 = "";
                RefFile_6_1 = ReadAllFromFile(CreateRefFile6_1());
            }
            else
            {
                RefFile_6_1 = ReadAllFromFile(CreateRefFile6_1());
            }
        }




        private string CreateNewFile6_2()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_2, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                    for (int i = 7; i < 19; i++)
                    {
                        sw.Write(i.ToString());
                    }
            }
            return PATCH_FILE_6_2;
        }

        private string CreateRefFile6_2()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_2, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var content = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(PATCH_FILE_6_2_TWO))
                    {
                        content = content.Remove(2, 1);
                        content = content.Insert(2, "63");
                        sw.Write(content);
                    }
                }
            }
            return PATCH_FILE_6_2_TWO;
        }



        private string CreateNewFile6_3()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_3_ONE, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write("");
                    for (int i = 0; i < rnd.Next(5, 15); i++)
                    {
                        sw.Write($" {rnd.Next(50, 150)}");
                    }
                }
            }
            return PATCH_FILE_6_3_ONE;
        }

        private string CreateRefFile6_3()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_3_TWO, FileMode.Create))
            {
                var content = "";
                var contentNew = "";
                using (StreamReader sr = new StreamReader(PATCH_FILE_6_3_ONE))
                {
                    content = sr.ReadToEnd();
                    content = content.Remove(0, 1);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        try
                        {
                            int[] result = content.Split(' ').Select(n => Int32.Parse(n)).ToArray();
                            for (int i = 0; i < result.Length; i++)
                            {
                                if (result[i] < 100)
                                {
                                    contentNew += " " + result[i];
                                }
                            }
                            sw.Write(contentNew);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
            }
            return PATCH_FILE_6_3_TWO;
        }

        private string CreateNewFile6_4_ONE()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_4_ONE, FileMode.Create))
            {
                using (StreamWriter sw1 = new StreamWriter(fs))
                {
                    for (int i = 0; i < rnd.Next(5, 10); i++)
                    {
                        sw1.Write(" " + rnd.Next(20, 60));
                    }
                }
            }
            return PATCH_FILE_6_4_ONE;
        }

        private string CreateNewFile6_4_TWO()
        {

            using (FileStream fs2 = new FileStream(PATCH_FILE_6_4_TWO, FileMode.Create))
            {

                using (StreamWriter sw2 = new StreamWriter(fs2))
                {
                    for (int i = 0; i < rnd.Next(5, 10); i++)
                    {
                        sw2.Write(" " + rnd.Next(5, 15));
                    }
                }
            }
            return PATCH_FILE_6_4_TWO;
        }

        private string ComputationSumm_6_4(string f1, string f2)
        {
            var result = "";
            f1 = f1.Remove(0, 1);
            f2 = f2.Remove(0, 1);

            try
            {
                Int32[] f1Array = (Int32[])f1.Split(' ').Select(n => Int32.Parse(n)).ToArray();
                Int32[] f2Array = (Int32[])f2.Split(' ').Select(n => Int32.Parse(n)).ToArray();

                var summf1 = 0;
                var summf2 = 0;

                for (Int32 i = 0; i < f1Array.Length; i++)
                {
                    if (f1Array[i] >= 45)
                    {
                        summf1 += f1Array[i];
                    }
                }
                for (Int32 i = 0; i < f2Array.Length; i++)
                {
                    if (f2Array[i] >= 9)
                    {
                        summf2 += f2Array[i];
                    }
                }
                result = (summf1 + summf2).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }



        private string _SummOutput_6_4;
        public string SummOutput_6_4
        {
            get
            {
                return _SummOutput_6_4;
            }
            set
            {
                _SummOutput_6_4 = value;
                RaisePropertyChanged("SummOutput_6_4");
            }
        }

        private string CreateNewFile6_5()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_5_ONE, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(InputTextFor_6_5);
                }
            }
            return PATCH_FILE_6_5_ONE;
        }

        private string CreateRefFile6_5()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_5_TWO, FileMode.Create))
            {
                var content = "";
                var contentNew = "";
                using (StreamReader sr = new StreamReader(PATCH_FILE_6_5_ONE))
                {
                    content = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < content.Length; i++)
                        {
                            contentNew += content[i] + "!";
                        }
                        sw.Write(contentNew);
                    }
                }
            }
            return PATCH_FILE_6_5_TWO;
        }

        private string _InputTextFor_6_5;
        public string InputTextFor_6_5
        {
            get
            {
                return _InputTextFor_6_5;
            }
            set
            {
                _InputTextFor_6_5 = value;
                RaisePropertyChanged("InputTextFor_6_5");
            }
        }


        private string CreateNewFile6_1()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_1_ONE, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write("Ели мясо мужики, газировкой запивааалиии");
                }
            }
            return PATCH_FILE_6_1_ONE;
        }

        private string CreateRefFile6_1()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_6_1_TWO, FileMode.Create))
            {
                using (StreamReader sr = new StreamReader(PATCH_FILE_6_1_ONE))
                {
                    var content = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        var insert = string.IsNullOrEmpty(InputTextFor_6_1) ? "" : InputTextFor_6_1;
                        if(insert == "")
                        {
                            MessageBox.Show("Вы не ввели текст, который нужно исключить");
                            sw.Write(content);
                        }
                        else
                        {
                            try
                            {
                                string[] text = content.Split(' ');
                                var result = "";
                                for (int i = 0; i < text.Length; i++)
                                {
                                    if (text[i].Contains(insert))
                                    {
                                        text[i] = " ";
                                    }
                                    else
                                    {
                                        result += " " + text[i];
                                    }
                                }
                                sw.Write(result);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }
            }
            return PATCH_FILE_6_1_TWO;
        }

        private string _InputTextFor_6_1;
        public string InputTextFor_6_1
        {
            get
            {
                return _InputTextFor_6_1;
            }
            set
            {
                _InputTextFor_6_1 = value;
                RaisePropertyChanged("InputTextFor_6_1");
            }
        }

        // сервис
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private string ReadAllFromFile(string way)
        {
            var response = "";
            var contains = "";
            using (FileStream fs = new FileStream(way, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    contains = sr.ReadToEnd();
                    for (int i = 0; i < contains.Length; i++)
                    {
                        response += contains[i];
                    }
                }
            }
            return response;
        }



        protected void CreateFiles()
        {
            CreateNewFile6_2();
        }





        // связывание с элементами UI
        private string _NewFile_6_2;
        public string NewFile_6_2
        {
            get
            {
                return _NewFile_6_2;
            }
            set
            {
                _NewFile_6_2 = value;
                RaisePropertyChanged("NewFile_6_2");
            }
        }

        private string _RefFile_6_2;
        public string RefFile_6_2
        {
            get
            {
                return _RefFile_6_2;
            }
            set
            {
                _RefFile_6_2 = value;
                RaisePropertyChanged("RefFile_6_2");
            }
        }

        //
        private string _NewFile_6_3;
        public string NewFile_6_3
        {
            get
            {
                return _NewFile_6_3;
            }
            set
            {
                _NewFile_6_3 = value;
                RaisePropertyChanged("NewFile_6_3");
            }
        }

        private string _RefFile_6_3;
        public string RefFile_6_3
        {
            get
            {
                return _RefFile_6_3;
            }
            set
            {
                _RefFile_6_3 = value;
                RaisePropertyChanged("RefFile_6_3");
            }
        }

        //
        private string _NewFile_6_4;
        public string NewFile_6_4
        {
            get
            {
                return _NewFile_6_4;
            }
            set
            {
                _NewFile_6_4 = value;
                RaisePropertyChanged("NewFile_6_4");
            }
        }

        private string _RefFile_6_4;
        public string RefFile_6_4
        {
            get
            {
                return _RefFile_6_4;
            }
            set
            {
                _RefFile_6_4 = value;
                RaisePropertyChanged("RefFile_6_4");
            }
        }

        //
        private string _NewFile_6_5;
        public string NewFile_6_5
        {
            get
            {
                return _NewFile_6_5;
            }
            set
            {
                _NewFile_6_5 = value;
                RaisePropertyChanged("NewFile_6_5");
            }
        }

        private string _RefFile_6_5;
        public string RefFile_6_5
        {
            get
            {
                return _RefFile_6_5;
            }
            set
            {
                _RefFile_6_5 = value;
                RaisePropertyChanged("RefFile_6_5");
            }
        }

        //
        private string _NewFile_6_1;
        public string NewFile_6_1
        {
            get
            {
                return _NewFile_6_1;
            }
            set
            {
                _NewFile_6_1 = value;
                RaisePropertyChanged("NewFile_6_1");
            }
        }

        private string _RefFile_6_1;
        public string RefFile_6_1
        {
            get
            {
                return _RefFile_6_1;
            }
            set
            {
                _RefFile_6_1 = value;
                RaisePropertyChanged("RefFile_6_1");
            }
        }


        // пути, лежащие в bin/debug
        const string PATCH_FILE_6_2 = @"files\task6_2\file.txt";
        const string PATCH_FILE_6_2_TWO = @"files\task6_2\secondFile.txt";

        const string PATCH_FILE_6_3_ONE = @"files\task6_3\file.txt";
        const string PATCH_FILE_6_3_TWO = @"files\task6_3\secondFile.txt";

        const string PATCH_FILE_6_4_ONE = @"files\task6_4\file.txt";
        const string PATCH_FILE_6_4_TWO = @"files\task6_4\secondFile.txt";

        const string PATCH_FILE_6_5_ONE = @"files\task6_5\file.txt";
        const string PATCH_FILE_6_5_TWO = @"files\task6_5\secondFile.txt";

        const string PATCH_FILE_6_1_ONE = @"files\task6_1\file.txt";
        const string PATCH_FILE_6_1_TWO = @"files\task6_1\secondFile.txt";
    }
}
