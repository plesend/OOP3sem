using lab02;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace lab02
{
    public partial class House
    {
        private readonly Guid _id; 
        private int _number;
        private int _площадь;
        private int _floor;
        private int _rooms;
        private const string _street = "Бипковая";
        private string _type;
        private int _year;

        private static int _objectCount = 0;// статическое поле

        
        public House(int id, int number, int площадь, int floor, int rooms, string street, string type, int year)
        {
            _id = Guid.NewGuid();
            _number = number;
            _площадь = площадь;
            _floor = floor;
            _rooms = rooms;
            _type = type;
            _year = year;
            _objectCount++;
        }
        public House()
        {
            _number = 0;
            _floor = 0;
            _rooms = 0;
            _площадь = 0;
            _objectCount++;
        }

        private House(int id)
        {
            _objectCount++;
        }
        public static House PrivateConstr(int id)
        {
            if (_objectCount > 0)
            {
                return new House(id);
            } 
            else
            {
                return new House(2132121);
            }

        }
        public int number { set { _number = value; } }
        public int square { get { return _площадь; } set { _площадь = value; } }
        public int floor { get { return _floor; } set { _floor = value; } }
        public int rooms { get { return _rooms; } set { _rooms = value; } }
        public string type { get { return _type; } set { _type = value; } }
        public int year { get { return _year; } set { _year = value; } }

        public void changeHouseInfo(ref int number, ref int floor)
        {
            number += 10;  
            floor += 1;    
            Console.WriteLine($"Новый номер дома: {number}, новый этаж: {floor}");
        }
        public void GetHouseYear(out int year)
        {
            year = _year;  
            Console.WriteLine($"Год постройки дома: {year}");
        }
        public static void countConstructors()
        {
            Console.WriteLine($"Было {_objectCount} конструкторов");
        }

        public override string ToString()
        {
            return $"Дом №{_number}, площадь: {_площадь} м2, этаж: {_floor}, комнаты: {_rooms}, тип: {_type}, год постройки: {_year}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is House))
                return false;

            House other = (House)obj;
            return _number == other._number && _площадь == other._площадь &&
                   _floor == other._floor && _rooms == other._rooms &&
                   _type == other._type && _year == other._year;
        }

        public override int GetHashCode()
        {
            return _number.GetHashCode() ^ _площадь.GetHashCode() ^ _floor.GetHashCode() ^ _rooms.GetHashCode() ^
                   _type.GetHashCode() ^ _year.GetHashCode();
        }

        private int daySnosa;

        public int dSnosa { get { return daySnosa; } set { daySnosa = value; }  }

        //public void proverka()
        //{
        //    if(daySnosa == 0)
        //    {
        //        Console.WriteLine("Сносим сегодня");
        //    }
        //    if(daySnosa > 0)
        //    {
        //        Console.WriteLine("повезло");
        //    }
        //}

    }
}

class Program { 

    static void Main(string[] args)
    {
        House house1 = new House(1, 2, 50, 3, 4, "Бипковая", "Кирпичный", 2005);
        House house2 = new House(2, 10, 75, 5, 6, "Бипковая", "Панельный", 2010);
        House house3 = new House(); 

        house1.number = 100; 
        Console.WriteLine($"Обновленный дом 1: {house1}");

        int number = 5;
        int floor = 2;
        house2.changeHouseInfo(ref number, ref floor);
        Console.WriteLine($"После изменения в house2: номер дома = {number}, этаж = {floor}");

        
        int year;
        house3.GetHouseYear(out year); 
        Console.WriteLine($"Год постройки house3: {year}");

        bool areEqual = house1.Equals(house2);
        Console.WriteLine($"Дом house1 и house2 равны: {areEqual}");

        if (house1 is House)
        {
            Console.WriteLine("house1 является объектом типа House");
        }

        House[] houses = new House[]
        {
                new House(3, 5, 60, 4, 3, "Бипковая", "Деревянный", 2000),
                new House(4, 12, 80, 6, 5, "Центральная", "Кирпичный", 1995),
                new House(5, 20, 90, 8, 7, "Лесная", "Панельный", 2015)
        };

        Console.WriteLine("\nМассив домов:");
        foreach (var house in houses)
        {
            Console.WriteLine(house);
        }

        House.PrivateConstr(3);
        House.countConstructors();

        //house1.otmenaToday();
        //house1.proverkasnosa();



        House hs = new House();
        hs.dSnosa = 23;
        Console.WriteLine(hs.dSnosa);

        var anonhouse = new {number = 2,floor = 4, type = "хрущевка"};
        
    }
}
