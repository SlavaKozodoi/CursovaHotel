using Cursova123.Models;
using CursovaFinal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;


namespace Cursova123.ViewModels
{
    

    public class CheckInViewModel :  ViewModelBase
    {
        private ObservableCollection<Room> _rooms;
        private ObservableCollection<Room> _allRooms;
        private Guest _guestInfo;
        private DateTime _selectedCheckInDate;
        private DateTime _selectedCheckOutDate;
        private Room _selectedRoom;
        private ObservableCollection<string> _roomClasses;
        private string _selectedRoomClass;
        private const string DataFilePath = "data.json";
        private const string HistoryFilePath = "History.json";
        private const string RoomsFilePath = "rooms.json";
       

        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
                
            }
        }
        public ObservableCollection<Room> AllRooms
        {
            get { return _allRooms; }
            set
            {
                _allRooms = value;
                OnPropertyChanged(nameof(AllRooms));
            }
        }

        public Guest GuestInfo
        {
            get { return _guestInfo; }
            set
            {
                
                
                
                _guestInfo = value;
                OnPropertyChanged(nameof(GuestInfo));
            }
        }

        public DateTime SelectedCheckInDate
        {
            get { return _selectedCheckInDate; }
            set
            {
                _selectedCheckInDate = value;
                OnPropertyChanged(nameof(SelectedCheckInDate));
            }
        }

        public DateTime SelectedCheckOutDate
        {
            get { return _selectedCheckOutDate; }
            set
            {
                _selectedCheckOutDate = value;
                OnPropertyChanged(nameof(SelectedCheckOutDate));
            }
        }

        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }
        public ObservableCollection<string> RoomClasses
        {
            get { return _roomClasses; }
            set
            {
                _roomClasses = value;
                OnPropertyChanged(nameof(RoomClasses));
            }
        }

        public string SelectedRoomClass
        {
            get { return _selectedRoomClass; }
            set
            {
                _selectedRoomClass = value;
                OnPropertyChanged(nameof(SelectedRoomClass));
                UpdateRoomsByClass();
            }
        }
        

        public ICommand SaveCheckInCommand { get; }

        public CheckInViewModel()
        {
            SaveCheckInCommand = new RelayCommand(ExecuteSaveCheckInCommand);

            RoomClasses = new ObservableCollection<string>
        {
            "Люкс",
            "Стандарт",
            "Полулюкс",
            "Економ"
        };
            SelectedRoomClass = "Люкс";

            GuestInfo = new Guest();
            SelectedCheckInDate = DateTime.Now;
            SelectedCheckOutDate = DateTime.Now.AddDays(1);



        }
        
        public void ExecuteSaveCheckInCommand()
        {

            try
            {
                if (string.IsNullOrEmpty(GuestInfo.FirstName)|| string.IsNullOrEmpty(GuestInfo.LastName)|| string.IsNullOrEmpty(GuestInfo.Patronymic))
                {
                    MessageBox.Show("Не заповнене ФІО");
                    return;
                }
                if (!Regex.IsMatch(GuestInfo.PhoneNumber, @"^(\+\d{12}|\d{10})$"))
                {
                    MessageBox.Show("Не правильно введений номер телефону!");
                    return;
                }
                if (!Regex.IsMatch($"{GuestInfo.PassportNumber}", @"^\d{9}$"))
                {
                    MessageBox.Show("Не правильно введений номер паспорту!");
                    return;
                }
                if (SelectedCheckInDate > SelectedCheckOutDate)
                {
                    MessageBox.Show("Дата заселення повинна бути раніше дати виселення.");
                    return;
                }
                if (SelectedRoom==null)
                {
                    MessageBox.Show("Виберіть кімнату для гостя.");
                    return;
                }
                if (SelectedRoom.IsOccupied)
                {
                    MessageBox.Show("Обрана кімната вже зайнята.Оберіть іншу.");
                    return;
                }

                Reservation reservation = new Reservation(SelectedRoom, GuestInfo, SelectedCheckInDate, SelectedCheckOutDate)
                {
                    GuestInfo = GuestInfo,
                    CheckInDate = SelectedCheckInDate,
                    CheckOutDate = SelectedCheckOutDate,
                    SelectedRoom = SelectedRoom
                };
                SelectedRoom.IsOccupied = true;

                SaveDataToFile(reservation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збережені даних: {ex.Message}");
            }
        }

        private void SaveDataToFile(Reservation reservation)
        {
            try
            {
                List<Reservation> history;
                if (File.Exists(HistoryFilePath))
                {
                    string historyJsonData = File.ReadAllText(HistoryFilePath);
                    history = JsonConvert.DeserializeObject<List<Reservation>>(historyJsonData);
                }
                else
                {
                    history = new List<Reservation>();
                }

                
                history.Add(reservation);

                string updatedHistoryJsonData = JsonConvert.SerializeObject(history, Formatting.Indented);
                File.WriteAllText(HistoryFilePath, updatedHistoryJsonData);
                UpdateDataFile(reservation);
                UpdateRoomsFile();

                MessageBox.Show("Гість успішно заселенний!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збережені даних в History.json: {ex.Message}");
            }
        }

        private void UpdateDataFile(Reservation reservation)
        {
            try
            {
                List<Reservation> reservations;
                if (File.Exists(DataFilePath))
                {
                    string jsonData = File.ReadAllText(DataFilePath);
                    reservations = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
                    
                }
                else
                {
                    reservations = new List<Reservation>();
                }

                reservations.Add(reservation);

                string updatedJsonData = JsonConvert.SerializeObject(reservations, Formatting.Indented);
                File.WriteAllText(DataFilePath, updatedJsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновлені файла data.json: {ex.Message}");
            }
        }
        private void UpdateRoomsByClass()
        {
            try
            {
                
                string roomsJsonData = File.ReadAllText(RoomsFilePath);
                List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(roomsJsonData);

                var filteredRooms = rooms.Where(room => room.RoomClass == SelectedRoomClass);

                Rooms = new ObservableCollection<Room>(filteredRooms);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновлені списка кімнат: {ex.Message}");
            }
        }
        private void UpdateRoomsFile()
        {
            try
            {

                List<Room> rooms;
                if (File.Exists(RoomsFilePath))
                {
                    string roomsJsonData = File.ReadAllText(RoomsFilePath);
                    rooms = JsonConvert.DeserializeObject<List<Room>>(roomsJsonData);
                }
                else
                {
                    rooms = new List<Room>();
                }

                var selectedRoom = rooms.FirstOrDefault(r => r.RoomNumber == SelectedRoom.RoomNumber);
                if (selectedRoom != null)
                {
                    selectedRoom.IsOccupied = true; 
                }
                

                
                string updatedRoomsJsonData = JsonConvert.SerializeObject(rooms, Formatting.Indented);
                File.WriteAllText(RoomsFilePath, updatedRoomsJsonData);
                UpdateRoomsByClass();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновлені файлу rooms.json: {ex.Message}");
            }
        }
        


    }

}

