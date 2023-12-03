using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursova123.Models
{
    public class Room
    {
        public string RoomNumber { get; set; }
        public string RoomClass { get; set; }
        public bool IsOccupied { get; set; }
        public int BedsCount { get; set; }
        public double Price { get; set; }

        public Room(string roomNumber, string roomClass,bool isOccupied, int bedsCount, double price)
        {
            RoomNumber = roomNumber;
            RoomClass = roomClass;
            IsOccupied = isOccupied;
            BedsCount = bedsCount;
            Price = price;
        }


    }
}
