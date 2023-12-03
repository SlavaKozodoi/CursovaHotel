using Cursova123.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Cursova123.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private const string RoomsFilePath = "rooms.json";
        private FileSystemWatcher _fileWatcher;

        private int _freeLuxuryRoomsCount;
        private int _freepolulux;
        private int _freestandart;
        private int _freeEconom;
        private int _freeallrooms;
        public int FreeLuxuryRoomsCount
        {
            get { return _freeLuxuryRoomsCount; }
            set
            {
                
                    _freeLuxuryRoomsCount = value;
                    OnPropertyChanged(nameof(FreeLuxuryRoomsCount));  
            }
        }

        public int Freepolux
        {
            get { return _freepolulux; }
            set { _freepolulux = value;OnPropertyChanged(nameof(Freepolux)); }
        }
        public int Freestandart
        {
            get { return _freestandart; }
            set
            {
                _freestandart = value; OnPropertyChanged(nameof(Freestandart));
            }
        }
        public int FreeEconom
        {
            get {return _freeEconom; }
            set { _freeEconom = value;OnPropertyChanged(nameof(FreeEconom)); }
        }

        public int FreeAllrooms
        {
            get { return _freeallrooms; }
            set
            {
                _freeallrooms = value; OnPropertyChanged(nameof(FreeAllrooms));     
            }
        }

        public MainViewModel()
        {
            string directoryPath = Path.GetDirectoryName(Path.GetFullPath(RoomsFilePath));
            _fileWatcher = new FileSystemWatcher(directoryPath)
            {
                Filter = Path.GetFileName(RoomsFilePath),
                NotifyFilter = NotifyFilters.LastWrite
            };
            _fileWatcher.Changed += OnFileChanged;
            _fileWatcher.EnableRaisingEvents = true;
            UpdateRoomCounts();
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            UpdateRoomCounts();
        }

        private void UpdateRoomCounts()
        {
            try
            {
                List<Room> rooms = LoadRoomsFromFile();
                FreeLuxuryRoomsCount = rooms.Count(room => room.RoomClass == "Люкс" && !room.IsOccupied);
                Freepolux = rooms.Count(room => room.RoomClass == "Полулюкс" && !room.IsOccupied);
                Freestandart = rooms.Count(room => room.RoomClass == "Стандарт" && !room.IsOccupied);
                FreeEconom = rooms.Count(room => room.RoomClass == "Економ" && !room.IsOccupied);
                FreeAllrooms = FreeLuxuryRoomsCount+Freepolux+Freestandart+ FreeEconom;


            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Помилка в оновлені кількості кімнат: {ex.Message}");
            }
        }

        private List<Room> LoadRoomsFromFile()
        {
            string roomsJsonData = File.ReadAllText(RoomsFilePath);
            return JsonConvert.DeserializeObject<List<Room>>(roomsJsonData);
        }
        
    }

}
