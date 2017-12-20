using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using WordPlant2;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WordPlant2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
    {

        string savedLevel = "";

        public StartPage()
        {
            this.InitializeComponent();
            sbConvayor.Begin();
            sbIntro.Begin();
            BackgroundMusicStartMenu.Volume = 1;



        }

        private void StartGame(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Image clickedImage = sender as Image;
            string userClicked = clickedImage.Name;

            if (userClicked == "btnNewGame")
            {
                action.Play();
                sbButtonPress.Begin(); // starts game at round 1
            }
            if (userClicked == "btnContinueGame")
            {
                action.Play();
                sbButtonPressContinue.Begin(); // Continues from either closing of app or gameover
            }
            if (userClicked == "btnHowToPlay")
            {
                action.Play();
                sbButtonPressTut.Begin(); // Starts Tutorial Storyboard
            }

        }

        private void sbButtonPress_Completed(object sender, object e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void sbButtonPressContinue_Completed(object sender, object e)
        {
            var localFolder =
                ApplicationData.Current.LocalFolder;
            //Opens file
            var file = await localFolder.CreateFileAsync(
                "gameSave.txt", CreationCollisionOption.OpenIfExists);
            //writes data from file to a variable
            string data = await FileIO.ReadTextAsync(file);
            savedLevel = data;

            Frame.Navigate(typeof(MainPage), savedLevel);  // navigates to mainpage with saved level
        }

        private void sbButtonPressTut_Completed(object sender, object e)
        {
            Frame.Navigate(typeof(Tutorial));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            savedLevel = Convert.ToString(e.Parameter);
        }
    }
}

