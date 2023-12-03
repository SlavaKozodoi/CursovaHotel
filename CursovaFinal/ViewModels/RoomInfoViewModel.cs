using Cursova123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursova123.ViewModels
{
    public class RoomInfoViewModel : ViewModelBase
    {
        private Room _room;
        
        public Room Room
        {
            get { return _room; }
            set
            {
                _room = value;
                OnPropertyChanged(nameof(Room));
            }
        }
        

        public RoomInfoViewModel(Room room)
        {
            Room = room;
            
        }
    }
}
