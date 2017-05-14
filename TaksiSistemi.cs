using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaksiSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            var op = new Operator();
            Console.WriteLine("Bos taksilerin siyahisi: ");
            op.TaxiGenerator();
            op.CustomerInfo();
            op.TaxiSelector();


        }
    }
    public class Customer
    {
        public string name;
        public double startX;
        public double startY;
        public double finishX;
        public double finishY;
        public double distance;
        public Customer(string name, double startX, double startY, double finishX, double finishY,double distance)
        {
            this.name = name;
            this.startX = startX;
            this.startY = startY;
            this.finishX = finishX;
            this.finishY = finishY;
            this.distance = distance;
        }
    }

    public class Operator
    {
        public List<Taxi> taxiList = new List<Taxi>();
        public List<Customer> customerList = new List<Customer>();

        public void CustomerInfo()
        {
            Console.WriteLine("Adinizi daxil edin");
            string name = Console.ReadLine();
            Console.WriteLine("Oluqunuz mekanin X koordinatini daxil edin: ");
            double stX = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Oluqunuz mekanin Y koordinatini daxil edin: ");
            double stY = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Gedilecek mekanin X koordinatini daxil edin: ");
            double finX = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Gedilecek mekanin Y koordinatini daxil edin: ");
            double finY = Convert.ToDouble(Console.ReadLine());
            double distance = Math.Round(Math.Sqrt((Math.Pow((finX - stX), 2) + Math.Pow((finY - stY), 2))));
            Console.WriteLine("Gedeceyiniz mesafe {0}km",distance);
            customerList.Add(new Customer(name, stX, stY, finX, finY,distance));
           
        }





        public void TaxiGenerator()
        {
            taxiList.Add(new Taxi(101, 41, 49));
            taxiList.Add(new Taxi(102, 35, 53));
            taxiList.Add(new Taxi(103, 40, 55));
            taxiList.Add(new Taxi(104, 43, 52));
            taxiList.Add(new Taxi(104, 37, 50));
            foreach (var taxi in taxiList)
            {
                Console.WriteLine("Masin nomresi: " + taxi.carNumber + " Hal-hazirki koordinatlari : " + taxi.pointX + " , " + taxi.pointY);
            }

        }

        public void TaxiSelector()
        {
            
            
           
            List<double> distList = new List<double>();
            
            
            foreach (var taxi in taxiList)
            {
                double taxi2Customer = Math.Pow((taxi.pointX - customerList[0].startX), 2) + Math.Pow((taxi.pointY - customerList[0].startY), 2);
                taxi.taxi2customer = taxi2Customer;
                distList.Add(taxi.taxi2customer);
                taxi.time2customer = taxi.velocity * taxi.taxi2customer;

                
                
            }
            distList.Sort();
            
            for (int i = 0; i < taxiList.Count; i++)
            {
                if (taxiList[i].taxi2customer == distList[0])
                {
                    Console.WriteLine(customerList[0].name+", size en yaxin taksinin masin nomresi: " + taxiList[i].carNumber + " Mesafe: " + taxiList[i].taxi2customer + " km " + taxiList[i].time2customer +" deqiqeye catacaq " + customerList[0].distance * 3 + " deqiqeye sizi mekana catdiracaq ");
                    Console.WriteLine("Gedis haqqi {0} AZN", customerList[0].distance*2);
                }
            }
            
        }



        public class Taxi
        {
            public int carNumber;
            public double pointX;
            public double pointY;
            public double taxi2customer;
            public double velocity = 3;
            public double time2customer;
            public double time4customer;
            public Taxi(int carNumber, double pointX, double pointY)
            {
                this.carNumber = carNumber;
                this.pointX = pointX;
                this.pointY = pointY;
            }
        }

    }

}
