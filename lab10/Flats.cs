using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Flats 
    {
        public int rooms {  get; set; }
        public string adress { get; set; }
        public int adressNum { get; set; }
        public int floor { get; set; }

        public Flats(int rooms, string adress, int adressNum, int floor)
        {
            this.rooms = rooms;
            this.adress = adress;
            this.adressNum = adressNum;
            this.floor = floor;
        }
        public override string ToString()
        {
            return $"Улица {adress}, дом {adressNum}, этаж {floor}, количество комнат - {rooms}";
        }
    }
}
