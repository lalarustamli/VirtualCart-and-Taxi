using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKardSistemi
{
     class Program
    {
        enum Dates
        {
            halfyear = 6,
            year = 12,
            yearhalf = 18,
            twoyears = 24
        }


        static void Main(string[] args)
        {
           
            Console.WriteLine("YarimKiloluqBanka xosh gelmisiniz!");
            Console.WriteLine("Virtual kart acmaq ucun oz kartiniz olmalidir. Lutfen adinizi daxil edin:");
            string ad = Console.ReadLine();
            Console.WriteLine("Soyadinizi unutmayin :");           
            string soyad = Console.ReadLine();           
            Console.WriteLine("Kartiniza pul qoyun. Mebleqi daxil edin :");           
            int pul = Convert.ToInt32(Console.ReadLine());          
            Console.WriteLine("Kartdan neche ay istifade edeceksiniz?"); 
            int ay = Convert.ToInt32(Console.ReadLine());
            var card = new Card(ad, soyad, pul, ay); 
            Console.WriteLine("Kartiniz hazirdir!");
            Console.WriteLine("Istifadeçi adı : " + card.Name + "\n" + "İstifadeçi soyadı : " + card.Surname + "\nKart nomresi : "+card.CardNum + "\nCVC kodu: " + card.Cvc +"\nYararlidir : " + card.DeadlineInput+"\nKartdaki mebleq : " + card.Money ); 
            Console.WriteLine("Virtual kart yaradacaqiniz shexsin adini daxil edin: ");     
            string vAd = Console.ReadLine();
            Console.WriteLine("Gondermek istediyiniz meqleqi daxil edin");
            int vMebleq = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine("Virtual kart ucun yararliliq muddeti neche ay olsun?");
            int vAy = Convert.ToInt32(Console.ReadLine());
            card.AddVirtualCard(vAd, vMebleq, vAy);
            Console.WriteLine("Kartinizda qaliq mebleq : " + card.Money);
            var vCard = card.GetVirtualCard(vAd);
            Console.WriteLine("Virtual Kart hazirdir!");
            Console.WriteLine("Virtual kart sahibinin adi :" + vCard.Login + "\nKart nomresi :" + vCard.Vcardnumber +"\nKartdaki mebleq : "+vCard.Money);
        }
    }

    
    public class Card
    {

        
        private static string _name;
        private static string _surname;
        private static string _cardnumber;
        private static string _deadlineInput;
        private static string _cvc;
        private static double _money;
        private static DateTime _deadlineOutput;
        private static List<Virtualcard> _vcards = new List<Virtualcard>();
        public static Random rand = new Random();
        


        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public string CardNum { get { return _cardnumber; } }
        public string DeadlineInput { get { return _deadlineInput; } }
        public string Cvc { get {return _cvc; } }
        public double Money { get { return _money; } }

       


        private static string DeadlineDefiner(int arg)
        {
            DateTime deadline = DateTime.Now.AddMonths(arg);
            _deadlineOutput = deadline;
            return deadline.Month + " / " + deadline.Year.ToString().Substring(2); 
        }

        private static string GenerateCardNumber(int num)
        {
            string result = " ";
            for (int i  = 0; i < num; i++)
            {
                result += rand.Next(1, 9);
            }
            return result;
        }

        public void AddVirtualCard(string login, double money, int month)
        {
            if (DateTime.Now.AddMonths(month) > _deadlineOutput || _money < money)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : Qaydalari pozdunuz./nQayda 1 : Virtual kartin yayarliliq muddeti real kartdan boyuk ola bilmez.\nQayda 2 : Virtual karta oturduyunuz mebleq real kartdan artiq ola bilmez. ");
                Console.ResetColor();
                
            }
            _money -= money;
            _vcards.Add(new Virtualcard(login, money, month));
        }
        public Virtualcard GetVirtualCard(string login)
        {
            for (int i = 0; i < _vcards.Count; i++)
            {
                if (_vcards[i].Login == login)
                {
                    return _vcards[i];
                }
            }
            return null;
            
        }


        public Card(string name, string surname, double money, int date)
        {
            _name = name;
            _surname = surname;
            _money = money;
            _cardnumber = GenerateCardNumber(16);
            _cvc = GenerateCardNumber(3);
            _deadlineInput = DeadlineDefiner(date);
        }

    }



    //VirtualCard
    public class Virtualcard
    {
        
        private string _login;
        private string __vCardNumber;
        private DateTime _deadlineInput;
        private double _money;
        public static Random rand = new Random();


        public string Login { get { return _login; } }
        public string Vcardnumber { get { return __vCardNumber; } }
        public double Money { get { return _money; } }
        public string DeadlineInput { get { return _deadlineInput.Month + " / " + _deadlineInput.Year; } }


        private string Getvirtualcardnumber(int num)
        {
            string result = "";
            for (int i = 0; i < num; i++)
            {
                result += rand.Next(0, 9);
            }
            return result;
        }

        public Virtualcard(string login,double money, int month)
        {
            _login = login;
           
            _money = money;
            _deadlineInput = DateTime.Now.AddMonths(month);
            __vCardNumber = Getvirtualcardnumber(16);

        }

    }

}
