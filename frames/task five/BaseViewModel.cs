using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktikaCourse3.frames.task_five
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }

        private string _charSequencesRef;
        public string CharSequencesRef
        {
            get
            {
                return _charSequencesRef;
            }
            set
            {
                _charSequencesRef = value;
                RaisePropertyChanged("CharSequencesRef");
            }
        }


        private string _stringSequencesRef;
        public string StringSequencesRef
        {
            get
            {
                return _stringSequencesRef;
            }
            set
            {
                _stringSequencesRef = value;
                RaisePropertyChanged("StringSequencesRef");
            }
        }


        //сервис
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
