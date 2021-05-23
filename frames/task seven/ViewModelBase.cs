using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PraktikaCourse3.frames.task_seven
{
    class ViewModelBase : INotifyPropertyChanged
    {
        private ICollection<Homes> _homes;
        public ICollection<Homes> HomesList
        {
            get { return _homes; }
            set { _homes = value; RaisePropertyChanged("HomesList"); }
        }

        protected void UpdateData()
        {
            Homes[] homes = new Homes[] {
                new Homes{ Number = 0, Color = "White", QtyRoom = 5, QtyPeople = 14 },
                new Homes{ Number = 1, Color = "Blue", QtyRoom = 6, QtyPeople = 8 },
                new Homes { Number = 2, Color = "Red", QtyRoom = 4, QtyPeople = 10 },
                new Homes{ Number = 3, Color = "Gray", QtyRoom = 8, QtyPeople = 20 },
            };
            HomesList = (ICollection<Homes>)homes;
            CreateFile();
        }

        protected void AddData(string id, string color, string qtyR, string qtyP)
        {
            try
            {
                var newHome = new Homes { Number = int.Parse(id), Color = color, QtyRoom = int.Parse(qtyR), QtyPeople = int.Parse(qtyP) };
                HomesList = HomesList.Append(newHome).ToList();
                CreateFile();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CreateFile()
        {
            using (FileStream fs = new FileStream(PATCH_FILE_7, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in HomesList)
                    {
                        sw.WriteLine(item.getData());
                    }
                }
            }
        }

        //сервис
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        const string PATCH_FILE_7 = @"files\task7\Homes.txt";

    }


    public class Homes
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public int QtyPeople { get; set; }
        public int QtyRoom { get; set; }

        public string getData()
        {
            return "Номер дома -> " + this.Number.ToString() + " Цвет -> " + this.Color.ToString() + " Количество комнат -> " + this.QtyRoom.ToString() + " Количество жильцов -> " + this.QtyPeople.ToString();
        }

    }
}
