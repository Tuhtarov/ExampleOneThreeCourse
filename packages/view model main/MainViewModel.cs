using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PraktikaCourse3.frames;
using PraktikaCourse3.frames.main;
using PraktikaCourse3.frames.task_one;
using PraktikaCourse3.frames.task_three;
using PraktikaCourse3.frames.task_three_number_two;
using PraktikaCourse3.frames.task_two;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PraktikaCourse3.packages.view_model_main
{
    class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public double GridWidth
        {
            get { return _gridWidth; }
            set
            {
                _gridWidth = value;
                RaisePropertyChanged("GridWidth");
            }
        }



        public MainViewModel()
        {
            InitAnimation();
            InitFrames();
        }

        public ICommand ToolBarClick
        {
            get
            {
                return new RelayCommand(() => StartAnimation());
            }
        }

        public ICommand OpenTwoPage
        {
            get
            {
                return new RelayCommand(() => CurrentPage = TwoP);
            }
        }
        public ICommand OpenThreePage
        {
            get
            {
                return new RelayCommand(() => CurrentPage = ThreeP);
            }
        }

        public ICommand OpenOnePage
        {
            get
            {
                return new RelayCommand(() => CurrentPage = OneP);
            }
        }
        
        public ICommand OpenThreeNumberTwoPage
        {
            get
            {
                return new RelayCommand(() => CurrentPage = ThreeNumberTwoP);
            }
        }

        public ICommand OpenWelcomePage
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Welcome);
            }
        }


        /* ---------------------- Pages ----------------------- */
        private Page Welcome;
        private Page OneP;
        private Page TwoP;
        private Page ThreeP;
        private Page ThreeNumberTwoP;
        private Page FourP;
        private Page FiveP;
        private Page SixP;
        private Page SevenP;

        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                RaisePropertyChanged("CurrentPage");
            }
        }

        private void InitFrames()
        {
            Welcome =  new MainFrame();
            TwoP = new Two();
            OneP = new One();
            ThreeP = new Three();
            ThreeNumberTwoP = new ThreeNumberTwo();
        }



        /* ---------------------- ANIMATION ToolBar ----------------------- */

        private double _gridWidth;

        private bool GridHidden;
        private DispatcherTimer timer;

        public void StartAnimation()
        {
            timer.Start();
        }

        public void InitAnimation()
        {
            GridWidth = DEFAULT_WIDTH_200;
            GridHidden = false;
            timer = new DispatcherTimer();
            timer.Tick += OnTick_Timer;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
        }

        private void OnTick_Timer(object sender, EventArgs e)
        {
            if (GridHidden)
            {
                GridWidth += 10;
                if (GridWidth >= DEFAULT_WIDTH_200)
                {
                    GridHidden = false;
                    timer.Stop();
                }
            }
            else
            {
                GridWidth -= 10;
                if (GridWidth <= 45)
                {
                    GridWidth = 45;
                    GridHidden = true;
                    timer.Stop();
                }
            }
        }

        private const double DEFAULT_WIDTH_200 = 300;
    }
}
