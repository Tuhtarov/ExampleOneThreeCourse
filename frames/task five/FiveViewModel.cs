using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktikaCourse3.frames.task_five
{
    class FiveViewModel : BaseViewModel
    {
        public FiveViewModel()
        {
            UpdateUIX();
        }

        private void UpdateUIX()
        {
            CharSequencesRef = ExecuteTask5_1(CharSequences);
            StringSequencesRef = ExecuteTask5_2(StringSequences);
        }

        //Binding UIX for task 5.1
        private string _charSequences;
        public string CharSequences
        {
            set
            {
                try
                {
                    _charSequences = value;
                }
                catch (Exception e)
                {
                    _charSequences = $"{e.Message}";
                }
                finally
                {
                    UpdateUIX();
                    RaisePropertyChanged("CharSequences");
                }
            }
            get
            {
                return _charSequences;
            }
        }

        //Binding UIX for task 5.2
        private string _stringSequences;
        public string StringSequences
        {
            set
            {
                try
                {
                    _stringSequences = value;
                }
                catch (Exception e)
                {
                    _stringSequences = $"{e.Message}";
                }
                finally
                {
                    UpdateUIX();
                    RaisePropertyChanged("StringSequences");
                }
            }
            get
            {
                return _stringSequences;
            }
        }


        //логика
        private string ExecuteTask5_1(string sequences)
        {
            var result = "";
            if (string.IsNullOrEmpty(sequences))
            {
                result = "требуется ввод";
            }
            else
            {
                var seq = sequences.ToCharArray();
                for (int i = 1; i < seq.Length - 1; i += 2)
                {
                    char t = seq[i - 1];
                    seq[i - 1] = seq[i];
                    seq[i] = t;
                }

                for (int j = 0; j < seq.Length; j++)
                {
                    result += seq[j];
                }
            }
            return result;
        }

        private string ExecuteTask5_2(string sequences)
        {
            var result = "";
            if (string.IsNullOrEmpty(sequences))
            {
                result = "введите предложение";
            }
            else
            {
                var seq = sequences.Trim(' ');
                seq = seq.ToLower();
                string[] wordsArray = seq.Split(' ');
                for (int i = 0; i < wordsArray.Length; i++)
                {
                    var start = wordsArray[i].StartsWith(wordsArray[i].Last().ToString());
                    if (start)
                    {
                        result += $"\n{wordsArray[i]}";
                    }
                }
            }
            return result;
        }


    }
}
