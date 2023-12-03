using Cursova123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cursova123.ViewModels
{
    public class GuestViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        private string _phoneNumber ;
        private string _passportNumber;

        public string FirstName
        {
            get
            {
                
                return _firstName; }
            set {

                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));

            }
        }

      

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {

                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string PassportNumber
        {
            get { return _passportNumber; }
            set
            {
                _passportNumber = value;
                OnPropertyChanged(nameof(PassportNumber));
            }
        }


    }
}
