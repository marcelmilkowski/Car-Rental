using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wypoyczalnia2;

namespace Wypoyczalnia2
{
    /// <summary>
    /// Logika interakcji dla klasy PageReservationView.xaml
    /// </summary>
    public partial class PageReservationView : UserControl
    {

        private Car _selectedCar;
        private Customer _customer;
        
        public PageReservationView(Car selectedCar, Customer customer)
        {
            
            InitializeComponent();
            //_selectedCar = selectedCar;
            //_customer = customer;
            //zeby xaml brał informacje stąd \/
            this.DataContext = DataStore.Reservations;
            

           

        }
        public PageReservationView()
        {
            InitializeComponent();
            this.DataContext = DataStore.Reservations;
        }

      



    }
}
