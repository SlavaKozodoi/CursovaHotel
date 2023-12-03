using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursova123.Models
{
    public class Reservation
    {
        public Room SelectedRoom { get; set; }
        public Guest GuestInfo { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Reservation(Room selectedRoom,Guest guestInfo,DateTime checkInDate,DateTime checkOutDate ) 
        {
        SelectedRoom = selectedRoom;
            GuestInfo = guestInfo;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

       
    }
}
