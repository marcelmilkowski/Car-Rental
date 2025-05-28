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

namespace Wypoyczalnia2
{
    /// <summary>
    /// Logika interakcji dla klasy ReservationView.xaml
    /// </summary>
    public partial class ReservationView : UserControl
    {
        decimal totalPrice;
        int days;

        private Car _car;
        private MainWindow _mainwindow;
        public ReservationView(Car car, MainWindow mainwindow)
        {
            _car = car;
            InitializeComponent();
            ShowCarDetail();
            _mainwindow = mainwindow;
        }


       
        //wklejanie danych auta
        private void ShowCarDetail()
        {
            Brand.Text = _car.Brand;
            Model.Text = _car.Model;
            Price.Text = _car.PriceForDay.ToString() + "zł";
            TypeOfFuel.Text = _car.TypeOfFuel;
            Class.Text = _car.Class.ToString();
            Year.Text = _car.Year.ToString();
            Gearbox.Text = _car.GearboxType;

        }

        //zliczanie ceny końcowej
        private void DaysTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Decimal price = _car.PriceForDay;

            if (int.TryParse(DaysTextBox.Text, out days))
            {
                totalPrice = price * days;
                PriceTextBlock.Text = totalPrice + "zł";
            } else
            {
                PriceTextBlock.Text = "Podaj właściwą liczbę dni";
            }
        }

        //sprawdzanie czy wszystkie rubryki są wpisane i przekierowanie do reservationView
        private void ReservationButton_Clicked(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string lastName = LastNameBox.Text;
            string number = NumberBox.Text;
            string email = EmailBox.Text;
 
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(number) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(DaysTextBox.Text))
            {
                if (int.TryParse(DaysTextBox.Text, out int Days) && Days > 0){

                    Customer customer = new Customer(name, lastName, number, email);
                    customer.Price = totalPrice;
                    customer.Days = Days;
                    DataStore.Reservations.Add(new Reservation(customer, _car));
                    _mainwindow.ShowPageReservationView(_car ,customer);
                } else {
                    MessageBox.Show("Podaj jeszcze raz liczbę dni");
                }
             } else {
                MessageBox.Show("Nie podałeś wszystkich informacji");
             }

       

        
        
        }
    }

}
