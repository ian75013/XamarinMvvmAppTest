using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using my_mvvm_light.Model;
using GalaSoft.MvvmLight.Command;
using my_mvvm_light.Helpers;

namespace my_mvvm_light.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        List<Cards> FootballCards;
        RelayCommand buttonClicked;

        public MainViewModel()
        {
            // propogate the Football cards List
            FootballCards = Helpers.Helpers.GenerateCards;
            // give the number of shuffles a default
            NumberOfShuffles = 0;
            // fill the UI properties
            var firstTeam = FootballCards.First();
            var TeamName = firstTeam.TeamName;
            var StadiumName = firstTeam.StadiumName;
            var Capacity = firstTeam.Capacity;
            var Longitude = firstTeam.Longitude;
            var Latitude = firstTeam.Latitude;
        }

        // number of shuffles
        int numberShuffles;

        public int NumberOfShuffles
        {
            get { return numberShuffles; }
            set
            {
                Set(() => NumberOfShuffles, ref numberShuffles, value, true);
                // the final true means to broadcast the event

                if (numberShuffles > 0)
                    buttonClicked.RaiseCanExecuteChanged();
                // enables the click
            }
        }

        string teamName;

        public string TeamName
        {
            get { return teamName; }
            set { Set(() => TeamName, ref teamName, value, true); }
        }
        string stadiumName;

        public string StadiumName
        {
            get { return stadiumName; }
            set { Set(() => StadiumName, ref stadiumName, value, true); }
        }
        int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { Set(() => Capacity, ref capacity, value, true); }
        }
        double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { Set(() => Longitude, ref longitude, value, true); }
        }
        double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { Set(() => Latitude, ref latitude, value, true); }
        }

        public RelayCommand ButtonClicked
        {
            get
            {
                return buttonClicked ??
                       (buttonClicked = new RelayCommand(
                           () =>
                           {
                               // Shuffle the cards NumberOfShuffles times
                               FootballCards = Helpers.CardShuffle.Shuffle(FootballCards,
                                   NumberOfShuffles);
                               // get the first card
                               var topCard = FootballCards.First();
                               // propogate the properties
                               TeamName = topCard.TeamName;
                               StadiumName = topCard.StadiumName;
                               Capacity = topCard.Capacity;
                               Longitude = topCard.Longitude;
                               Latitude = topCard.Latitude;
                           }));
            }
        }
    }
}