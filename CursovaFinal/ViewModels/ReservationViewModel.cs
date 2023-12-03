using Cursova123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cursova123.ViewModels
{

    public class ReservationViewModel : ViewModelBase
    {
        private Reservation _reservation;

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
        public double TotalPrice
        { 
            get { return StayDuration * _reservation.SelectedRoom.Price; }
        }
        public int StayDuration
        {
            get { return (int)(CheckOutDate - CheckInDate).TotalDays+1; }
        }
        public string RoomNumber
        {
            get
            {
                return _reservation.SelectedRoom.RoomNumber;
            }
        }

        public string RoomClass
        {
            get
            {
                return _reservation.SelectedRoom.RoomClass;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return _reservation.SelectedRoom.IsOccupied;
            }
        }

        public int BedsCount
        {
            get
            {
                return _reservation.SelectedRoom.BedsCount;
            }
        }

        public string GuestFullName
        {
            get
            {
                if (_reservation.GuestInfo != null)
                {
                    return $"{_reservation.GuestInfo.FirstName} {_reservation.GuestInfo.LastName} {_reservation.GuestInfo.Patronymic}";
                }
                return "N/A";
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _reservation.GuestInfo?.PhoneNumber ?? "N/A";
            }
        }

        public string PassportNumber
        {
            get
            {
                return _reservation.GuestInfo?.PassportNumber ?? "N/A";
            }
        }

        public DateTime CheckInDate
        {
            get
            {
                return _reservation.CheckInDate;
            }
        }

        public DateTime CheckOutDate
        {
            get
            {
                return _reservation.CheckOutDate;
            }
        }

        public Reservation ToReservation()
        {
            return _reservation;
        }
    }

}
