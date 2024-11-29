using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08
{
    
    internal class Boss
    {
        public delegate void UpgradeDelegate(int years);
        public delegate void TurnonDelegate(string message);
        public event UpgradeDelegate Upgrade;
        public event TurnonDelegate Turnon;
        public int _years {get;set;}
        public bool _turnedOn { get;set;}
        public Boss(int age = 0, bool bipki = false)
        {
            _years = age;
            _turnedOn = bipki;
        }
        public void countYears(int years)
        {
            if (years > 25) 
            {
                Console.WriteLine("С повышением, Ваш стаж работы равен: ");
                Upgrade?.Invoke(years);
            }
            else
            {
                Console.WriteLine("пооешёл нахцуй ска еблан гандон вооооооооооооооооооооооооооооооооооооот так игрок");
                Upgrade?.Invoke(years);
            }
        }
        public void TurnOn()
        {
            _turnedOn = !_turnedOn;
            Turnon?.Invoke("The boss has been rizzed up");
        }
    }
}
