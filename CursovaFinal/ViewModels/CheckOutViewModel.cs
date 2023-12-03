using Cursova123.Models;
using CursovaFinal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Cursova123.ViewModels
{
    public class CheckOutViewModel : ViewModelBase
    {

        
        private ObservableCollection<ReservationViewModel> _reservations;
        private ReservationViewModel _selectedReservation;

        public ObservableCollection<ReservationViewModel> Reservations
        {
            get { return _reservations; }
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }
        public ReservationViewModel SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;
                OnPropertyChanged(nameof(SelectedReservation));
            }
        }
        public ICommand RemoveGuestCommand { get; }

        public CheckOutViewModel()
        {
            LoadReservations();
            RemoveGuestCommand = new RelayCommand(ExecuteRemoveGuestCommand);
        }

        

        private void LoadReservations()
        {
            try
            {
                string jsonData = File.ReadAllText("data.json");
                List<Reservation> reservations = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);

                Reservations = new ObservableCollection<ReservationViewModel>(
                    reservations.Select(reservation => new ReservationViewModel(reservation)));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при загрузці : {ex.Message}");
            }
        }
        private void ExecuteRemoveGuestCommand()
        {
           
            if (SelectedReservation != null)
            {
                
                MessageBoxResult result = MessageBox.Show($"Ви дійсно хочете висилити {SelectedReservation.GuestFullName} з кімнати {SelectedReservation.RoomNumber}?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question); ;

                 if (result == MessageBoxResult.No)
                {
                    return;
                 }
                try
                {

                   Reservation removedReservation = SelectedReservation.ToReservation();
                    Reservations.Remove(SelectedReservation);
                    UpdateJsonFile(removedReservation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при видалені гомтя: {ex.Message}");
                }
                
            }
        }

        private void UpdateJsonFile(Reservation removedReservation)
        {
            try
            {

                string roomsJsonData = File.ReadAllText("rooms.json");
                List<Reservation> updatedReservations = Reservations.Select(vm => vm.ToReservation()).ToList();
                List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(roomsJsonData);

                Reservation originalReservation = updatedReservations.FirstOrDefault(r => r.Equals(removedReservation));
                if (originalReservation != null)
                {
                    updatedReservations.Remove(originalReservation);
                }
                Room occupiedRoom = rooms.FirstOrDefault(r => r.RoomNumber == removedReservation.SelectedRoom.RoomNumber);
                
                if (occupiedRoom != null)
                {
                    
                    occupiedRoom.IsOccupied = false;

                   
                    string updatedJsonData = JsonConvert.SerializeObject(updatedReservations, Formatting.Indented);
                    File.WriteAllText("data.json", updatedJsonData);
                    string updatedRoomsJsonData = JsonConvert.SerializeObject(rooms, Formatting.Indented);
                          File.WriteAllText("rooms.json", updatedRoomsJsonData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновлені файла: {ex.Message}");
            }
        }
       
    }

}
