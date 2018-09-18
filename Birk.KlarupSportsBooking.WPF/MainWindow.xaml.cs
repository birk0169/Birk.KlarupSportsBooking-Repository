using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Birk.KlarupSportsBooking.BIZ;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ActivityHandler activityHandler = new ActivityHandler();
        private UnionHandler unionHandler = new UnionHandler();
        private BookingHandler bookingHandler = new BookingHandler();
        private ReservationHandler reservationHandler = new ReservationHandler();
        public MainWindow()
        {
            InitializeComponent();
            cbxUnionUser.ItemsSource = unionHandler.GetAllUnions();
            dgActivitiesUser.ItemsSource = activityHandler.GetAllActivities();
        }

        private void dpDatePickerUser_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(dpDatePickerUser.Text, out DateTime time))
            {
                dgBookingOverviewUser.ItemsSource = bookingHandler.GetAllBookingSpecificDate(DateTime.Parse(dpDatePickerUser.Text));
            }
            
        }

        private void btnAddNewReservationUser_Click(object sender, RoutedEventArgs e)
        {
            

            //Validation
            if (cbxUnionUser.SelectedItem == null)
            {
                tbkErrorMessageUser.Text = "Du skal vælge en forening før du kan oprette en resevation.";
            }
            else if (dgActivitiesUser.SelectedItem == null)
            {
                tbkErrorMessageUser.Text = "Du skal vælge en aktivitet før du kan oprette en resevation.";
            }
            else if (!DateTime.TryParse(dpReservationDateUser.Text, out DateTime dateTime))
            {
                tbkErrorMessageUser.Text = "Den valgte dato er ugyldig";
            }
            else if (!int.TryParse(tbxReservationDurationUser.Text, out int value))
            {
                tbkErrorMessageUser.Text = "Den reseverings tid er ugyldtig";
            }
            
            else
            {

                

                DateTime selectedTimeFrom = DateTime.Parse(dpReservationDateUser.Text).AddHours(double.Parse(tbxReservationHourUser.Text));
                //selectedTimeFrom.AddHours(double.Parse(tbxReservationHourUser.Text));

                DateTime selectedTimeTo = selectedTimeFrom.AddHours(double.Parse(tbxReservationDurationUser.Text));

                //Opening hours
                double openFrom = 8;
                double openTo = 22;
                DayOfWeek day = DateTime.Parse(dpReservationDateUser.Text).DayOfWeek;
                if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                {
                    openFrom = 9;
                    openTo = 21;
                }

                if (selectedTimeFrom.Hour >= openFrom && selectedTimeTo.Hour <= openTo)
                {
                    Activity selectedActivity = dgActivitiesUser.SelectedItem as Activity;

                    Union selectedUnion = cbxUnionUser.SelectedItem as Union;

                    Reservation newReservation = new Reservation(selectedTimeFrom, selectedTimeTo, false, selectedUnion, selectedActivity);

                    
                    
                    try
                    {
                        reservationHandler.AddReservationToDB(newReservation);
                        tbkErrorMessageUser.Text = "It worked!!";
                    }
                    catch
                    {

                        tbkErrorMessageUser.Text = "Noget gik galt";
                    }
                }
                else
                {
                    tbkErrorMessageUser.Text = "Tiden er fokert: Hallen har åbent fra 8 til 22 i hverdagene og fra 9 til 21 i weekenderne";
                }

                
            }
            
        }
    }
}
