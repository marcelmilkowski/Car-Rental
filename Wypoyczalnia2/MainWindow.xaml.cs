using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wypoyczalnia2;

public enum CarClass
{
    Sedan,
    SUV,
    Jeep,
    Hatchback,
    Coupe,
    Van,

}
public partial class MainWindow : Window
{

    public List<Car> Cars { get; set; } = new List<Car>();
    public MainWindow()
    {
        InitializeComponent();

        
        
        Cars.Add(new Car("Toyota", "RAV4", CarClass.SUV, "Benzyna", 250m, 2021, "Automatyczna"));
        Cars.Add(new Car("Jeep", "Wrangler", CarClass.Jeep, "Diesel", 400m, 2020, "Manualna"));
        Cars.Add(new Car("BMW", "320i", CarClass.Sedan, "Benzyna", 300m, 2019, "Automatyczna"));
        Cars.Add(new Car("Ford", "Mustang", CarClass.Coupe, "Benzyna", 500m, 2022, "Manualna"));
        Cars.Add(new Car("Mercedes", "Sprinter", CarClass.Van, "Diesel", 350m, 2017, "Automatyczna"));
        Cars.Add(new Car("Audi", "Q5", CarClass.SUV, "Benzyna", 320m, 2023, "Automatyczna"));
        Cars.Add(new Car("Hyundai", "Tucson", CarClass.SUV, "Benzyna", 240m, 2020, "Automatyczna"));
        Cars.Add(new Car("Nissan", "Juke", CarClass.Hatchback, "Benzyna", 180m, 2019, "Manualna"));
        Cars.Add(new Car("Chevrolet", "Camaro", CarClass.Coupe, "Benzyna", 450m, 2021, "Automatyczna"));
        Cars.Add(new Car("BMW", "X5", CarClass.SUV, "Diesel", 420, 2021, "Automatyczna"));
        Cars.Add(new Car("Audi", "A4", CarClass.Sedan, "Benzyna", 350, 2020, "Manualna"));
        Cars.Add(new Car("Toyota", "Corolla", CarClass.Sedan, "Hybryda", 300, 2019, "Automatyczna"));
        Cars.Add(new Car("Ford", "Mustang", CarClass.Coupe, "Benzyna", 600, 2022, "Automatyczna"));
        Cars.Add(new Car("Mazda", "CX-5", CarClass.SUV, "Benzyna", 400, 2022, "Automatyczna"));
        Cars.Add(new Car("Toyota", "Camry", CarClass.Sedan, "Hybryda", 390, 2021, "Automatyczna"));

        DataContext = this; //zeby ladowalo sie w xaml i aktualizowalo
    }

  

    private void CarsViewButton_Clicked(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new CarsView(this);
        
    }

    private void QuitButton_Clicked(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void MainMenu_Clicked(object sender, RoutedEventArgs e)
    {
        MainContent.Content = null;
    }

    public void ShowReservationView(Car selectedCar)
    {
        MainContent.Content = new ReservationView(selectedCar, this);
    }

    public void ShowPageReservationView(Car selectedcar, Customer customer)
    {
        MainContent.Content = new PageReservationView(selectedcar, customer);
    }
    private void ReservationButton_Clicked(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new PageReservationView();
    }
}
public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public CarClass Class { get; set; }
    public string TypeOfFuel { get; set; }
    public int Year { get; set; }
    public string GearboxType { get; set; }
    public decimal PriceForDay { get; set; }


    public Car(string brand, string model, CarClass carClass, string typeOfFuel, decimal priceForDay, int year, string gearboxType)
    {
        Brand = brand;
        Model = model;
        TypeOfFuel = typeOfFuel;
        PriceForDay = priceForDay;
        Year = year;
        GearboxType = gearboxType;
        Class = carClass;
    }
}

public class Customer
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string Email { get; set; }
    
    public decimal Price { get; set; }
    public int Days { get; set; }

    public Customer(string name, string lastName, string number, string email)
    {
        Name = name;
        LastName = lastName;
        Number = number;
        Email = email;
    }
}

public class Reservation
{
    public Customer Customer { get; set; }
    public Car Car { get; set; }

    public Reservation(Customer customer, Car car)
    {
        Customer = customer;
        Car = car;
    }

}

//Jakas inna lista, lepsza testuje
public static class DataStore
{
    public static ObservableCollection<Reservation> Reservations { get; set; } = new ObservableCollection<Reservation>();
}