using Cursova123.Models;
using Cursova123.View;
using CursovaFinal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cursova123.ViewModels
{
    public class RoomsInfoViewModel : ViewModelBase
    {
        private ObservableCollection<Room> _rooms;
        private Room _selectedRoom;
        

        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }
        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }
        public ICommand ShowRoomInfoCommand { get; }
        public RoomsInfoViewModel()
        {
            ShowRoomInfoCommand = new RelayCommand(ExecuteShowRoomInfoCommand);
            LoadInfoRooms();
        }

        public void LoadInfoRooms()
        {
            try
            {

                string jsonData = File.ReadAllText("rooms.json");
                List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(jsonData);
                Rooms = new ObservableCollection<Room>(rooms);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні : {ex.Message}");
            }
        }
        private void ExecuteShowRoomInfoCommand()
        {
            if (SelectedRoom != null)
            {
                AllRoomInfoView roomInfoWindow = new AllRoomInfoView(SelectedRoom);
                roomInfoWindow.Show();
            }
        }


    }
}
