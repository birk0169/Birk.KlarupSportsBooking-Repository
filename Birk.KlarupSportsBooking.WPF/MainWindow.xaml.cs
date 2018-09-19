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
        private AdminHandler adminHandler = new AdminHandler();
        private BookingHandler bookingHandler = new BookingHandler();
        private ReservationHandler reservationHandler = new ReservationHandler();
        public MainWindow()
        {
            InitializeComponent();
            cbxUnionUser.ItemsSource = unionHandler.GetAllUnions();
            dgActivitiesUser.ItemsSource = activityHandler.GetAllActivities();

            cbxAdmin.ItemsSource = adminHandler.GetAllAdmins();
            dgReservationsAdmin.ItemsSource = reservationHandler.GetAlllReservation();
            dgBookingOverviewAdmin.ItemsSource = bookingHandler.GetAllBookings();

            dgReservationsUser.ItemsSource = reservationHandler.GetAlllReservation();
        }

        //private void dpDatePickerUser_CalendarClosed(object sender, RoutedEventArgs e)
        //{
        //    if (DateTime.TryParse(dpDatePickerUser.Text, out DateTime time))
        //    {
        //        dgBookingOverviewUser.ItemsSource = bookingHandler.GetAllBookingSpecificDate(DateTime.Parse(dpDatePickerUser.Text));
        //    }
            
        //}

        public void ResetReservationUser()
        {
            dpReservationDateUser.Text = "";
            tbxReservationHourUser.Text = "";
            tbxReservationDurationUser.Text = "";
            dgActivitiesUser.SelectedItem = null;
        }

        //Buttons
        private void btnAddNewReservationUser_Click(object sender, RoutedEventArgs e)
        {
            bool isFixed = false;
            if (ckxFixed.IsChecked == true)
            {
                isFixed = true;
            }

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
            else if (isFixed && !DateTime.TryParse(dpFixedReservationStartUser.Text, out dateTime))
            {
                tbkErrorMessageUser.Text = "Den faste resevations perioden er ugyldigt";
            }
            else if (isFixed && !DateTime.TryParse(dpFixedReservationEndUser.Text, out dateTime))
            {
                tbkErrorMessageUser.Text = "Den faste resevations perioden er ugyldigt";
            }
            else if (isFixed && !(DateTime.Parse(dpFixedReservationStartUser.Text) < DateTime.Parse(dpFixedReservationEndUser.Text)))
            {
                tbkErrorMessageUser.Text = "Den faste resevations perioden er ugyldigt: En periode kan ikke starte før den skal slutte...";
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

                    Reservation newReservation = new Reservation(selectedTimeFrom, selectedTimeTo, isFixed, selectedUnion, selectedActivity);
                    if (isFixed)
                    {
                        Fixed fixedReservation = new Fixed()
                        {
                            PeriodStart = DateTime.Parse(dpFixedReservationStartUser.Text),
                            PeriodEnd = DateTime.Parse(dpFixedReservationEndUser.Text)
                        };
                        newReservation.Fixeds.Add(fixedReservation);
                    }
                    
                    try
                    {
                        //Adds reservation to the database
                        reservationHandler.AddReservationToDB(newReservation);
                        ResetReservationUser();
                        CheckAndSetBoxesForReservationOverview();


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

        private void btnCheckUserPassword_Click(object sender, RoutedEventArgs e)
        {
            if ((cbxUnionUser.SelectedItem as Union).Password == tbxUnionPasswordUser.Text)
            {
                tbkUnionPasswordResultUser.Text = "Godkendt";
            }
            else
            {
                tbkUnionPasswordResultUser.Text = "Ikke Godkendt";
            }
        }

        private void ckxSeeAllReservationsUser_Click(object sender, RoutedEventArgs e)
        {
            CheckAndSetBoxesForReservationOverview();
        }

        private void ckxSpecificDayUser_Click(object sender, RoutedEventArgs e)
        {
            CheckAndSetBoxesForReservationOverview();
        }

        //Method
        public void CheckAndSetBoxesForReservationOverview()
        {
            if (ckxSeeAllReservationsUser.IsChecked == true)
            {
                dgReservationsUser.ItemsSource = reservationHandler.GetAlllReservation();
            }
            else if (ckxSpecificDayUser.IsChecked == true)
            {
                if (DateTime.TryParse(dpReservationFromUser.Text, out DateTime dateTime))
                {
                    dgReservationsUser.ItemsSource = reservationHandler.GetReservationsOfDay(DateTime.Parse(dpReservationFromUser.Text));
                }
            }
            else
            {
                if (DateTime.TryParse(dpReservationFromUser.Text, out DateTime dateTime) && DateTime.TryParse(dpReservationToUser.Text, out dateTime))
                {
                    dgReservationsUser.ItemsSource = reservationHandler.GetReservationsWithinTimeFrame(DateTime.Parse(dpReservationFromUser.Text), DateTime.Parse(dpReservationToUser.Text));
                }
            }
        }

        private void btnConfirmReservationsToBookings_Click(object sender, RoutedEventArgs e)
        {
            if (cbxAdmin.SelectedItem == null)
            {

            }
            else if (dgReservationsAdmin.SelectedItem == null)
            {

            }
            else
            {
                bookingHandler.AddBookingsToDB(dgReservationsAdmin.SelectedItem as Reservation, cbxAdmin.SelectedItem as Admin);
                dgBookingOverviewAdmin.ItemsSource = bookingHandler.GetAllBookings();
            }
            
        }

        //End
    }
}
