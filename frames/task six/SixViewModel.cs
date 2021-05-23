using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PraktikaCourse3.frames.task_six
{
    class SixViewModel : SixViewModelBase
    {
        public SixViewModel()
        {
        }

        public ICommand Create6_2
        {
            get
            {
                return new RelayCommand(() => ExecuteTask6_2());
            }
        }

        public ICommand Create6_3
        {
            get
            {
                return new RelayCommand(() => ExecuteTask6_3());
            }
        }

        public ICommand Create6_4
        {
            get
            {
                return new RelayCommand(() => ExecuteTask6_4());
            }
        }

        public ICommand Create6_5
        {
            get
            {
                return new RelayCommand(() => ExecuteTask6_5());
            }
        }
        public ICommand Create6_1
        {
            get
            {
                return new RelayCommand(() => ExecuteTask6_1());
            }
        }
    }
}
