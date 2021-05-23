using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PraktikaCourse3.frames.task_seven
{
    class SevenViewModel : ViewModelBase
    {
        public SevenViewModel()
        {
            UpdateData();
        }

        public ICommand ClickAdd
        {
            get
            {
                return new RelayCommand(() => AddNewHome());
            }
        }

        public ICommand CreateHomes
        {
            get
            {
                return new RelayCommand(() => UpdateData());
            }
        }

        private void AddNewHome()
        {
            if(string.IsNullOrEmpty(NumberHome) && string.IsNullOrEmpty(ColorHome) && string.IsNullOrEmpty(QtyRoomHome) && string.IsNullOrEmpty(QtyPeopleHome))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
            else
            {
                try
                {
                    AddData(id: NumberHome, color: ColorHome, qtyR: QtyRoomHome, qtyP: QtyPeopleHome);
                }
                catch (Exception)
                {
                    MessageBox.Show("Повторите попытку с корретным вводом.");
                }
            }
        }

        // сервис viewmodel

        private string _numberHome;
        public string NumberHome
        {
            get { return _numberHome; }
            set { _numberHome = value; RaisePropertyChanged("NumberHome"); }
        }

        private string _ColorHome;
        public string ColorHome
        {
            get { return _ColorHome; }
            set { _ColorHome = value; RaisePropertyChanged("ColorHome"); }
        }

        private string _QtyRoomHome;
        public string QtyRoomHome
        {
            get { return _QtyRoomHome; }
            set { _QtyRoomHome = value; RaisePropertyChanged("QtyRoomHome"); }
        }

        private string _QtyPeopleHome;
        public string QtyPeopleHome
        {
            get { return _QtyPeopleHome; }
            set { _QtyPeopleHome = value; RaisePropertyChanged("QtyPeopleHome"); }
        }
    }
}
