using Cursova123.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;

namespace Cursova123.ViewModels
{
    public class InfoClientsViewModel : ViewModelBase
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
        

        public InfoClientsViewModel()
        {
            LoadReservations();
            
        }

        private void LoadReservations()
        {
            try
            {
                string jsonData = File.ReadAllText("History.json");
                List<Reservation> reservations = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);

                Reservations = new ObservableCollection<ReservationViewModel>(
                    reservations.Select(reservation => new ReservationViewModel(reservation))
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при загрузці  даних: {ex.Message}");
            }
        }
           
        
    }

}

