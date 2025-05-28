using System;
using System.Collections.Generic;
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
using static Wypoyczalnia2.MainWindow;

namespace Wypoyczalnia2
{
    
    public partial class CarsView : UserControl
    {
        private MainWindow _mainWindow;
        //private Car _car;
        public CarsView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            
         
        }


        private void ReservationButton_Clicked(object sender, RoutedEventArgs e)
        {

            if (CarsListView.SelectedItem != null)
            {
                _mainWindow.ShowReservationView((Car)CarsListView.SelectedItem);
            }
            else
            {

                MessageBox.Show("Nie wybrałeś żadnego samochodu.");
            }
        }
    }
}
