using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursova123.Models
{
    public class Guest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }

        public Guest(string firstName, string lastName, string patronymic, string phoneNumber, string passportNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            PassportNumber = passportNumber;
        }

        public Guest()
        {
           
        }
    }
}
