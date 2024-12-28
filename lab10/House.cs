using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    internal class House
    {
        public int adressNumber { get; set; }
        public int floor { get; set; }
        public string adress { get; set; }
        public int year { get; set; }
        public House(int adressNumber, int floor, string adress, int year)
        {
            this.adressNumber = adressNumber;
            this.floor = floor;
            this.adress = adress;
            this.year = year;
        }
        public override string ToString()
        {
            return $"Номер дома - {adressNumber}, этаж - {floor}, улица - {adress}, год постройки - {year}";
        }

    }
}
