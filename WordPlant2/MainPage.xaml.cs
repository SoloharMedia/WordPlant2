using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WordPlant2;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WordPlant2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Word dict = new Word();
        DispatcherTimer beltTimer = new DispatcherTimer();
        DispatcherTimer letterTimer = new DispatcherTimer();

        List<Image> letters = new List<Image>();
        List<Letter> theLetters = new List<Letter>();
        List<Image> lettersGuessed = new List<Image>();
        List<bool> tappedLetter = new List<bool>();

        //array for figuring out answer is in dict or not
        char[] answer = new char[14];

        Image letterImg = new Image();
        int leftSide = 0;
        int letterCount = 0;
        bool letterReady = false;
        int screenWidth = 0;

        //for checking left answer bar word
        string theWord1 = "";

        //for checking right answer bar word
        string theWord2 = "";

        static int pointsUntilNextRound = 500;
        static int wasteCollect = 0;
        static int maxCountBar2 = 0;
        static int maxCountBar1 = 0;
        public static int score = 0;
        public static int level = 1;
        static int lastLevelYouWereOn = 0;



        public MainPage()
        {
            this.InitializeComponent();
        }

        public void FinishSetup()
        {
            if (level == 0)
                level = 1;
            // These are to reset your score based on what level you lost at (Continue Purposes)
            if (level == 1)
                score = 0;
            if (level == 2)
                score = 500;
            if (level == 3)
                score = 1000;
            if (level == 4)
                score = 2000;
            if (level == 5)
                score = 4000;
            if (level == 6)
                score = 8000;
            if (level == 7)
                score = 16000;
            if (level == 8)
                score = 32000;
            if (level == 9)
                score = 64000;

            //Sets text of current level to appropiate level you Continue from
            txtCurrentLevel.Text = "Current Level " + level;
            txtScore.Text = score.ToString();

            Size size = GetScreenResolutionInfo();
            screenWidth = Convert.ToInt16(size.Width);

            beltTimer.Interval = new TimeSpan(0, 0, 0, 0, 13);
            beltTimer.Start();
            beltTimer.Tick += BeltTimer_Tick;
            letterTimer.Interval = new TimeSpan(0, 0, 0, 0, 1500);
            letterTimer.Start();
            letterTimer.Tick += LetterTimer_Tick;
            txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
            dict.ReadFile();
            sbMachineRunning.Begin();
            sbConvayor.Begin();
            musicBackground.Volume = 1;
        }
        //Method for scaling the users Resolution
        public static Size GetScreenResolutionInfo()
        {
            var applicationView = ApplicationView.GetForCurrentView();
            var displayInformation = DisplayInformation.GetForCurrentView();
            var bounds = applicationView.VisibleBounds;
            var scale = displayInformation.RawPixelsPerViewPixel;
            var size = new Size(bounds.Width * scale, bounds.Height * scale);
            return size;
        }
        private void LetterTimer_Tick(object sender, object e)
        {
            letterReady = true;
        }

        private void BeltTimer_Tick(object sender, object e)
        {
            if (letterReady)
            {
                Letter aLetter = new Letter(screenWidth);
                Image letterPic = new Image();

                letterPic.Name = "img" + letterCount + aLetter.GetChar();
                letterPic.Tapped += LetterPic_Tapped;
                theLetters.Add(aLetter);
                letterPic.Height = 50;
                letterPic.Width = 50;
                leftSide = screenWidth;
                letterPic.Margin = new Thickness(screenWidth, 0, 0, 0);
                letterPic.Source = new BitmapImage(new Uri(
                   this.BaseUri, aLetter.GetImageSource()));
                theSpot.Children.Add(letterPic);
                letters.Add(letterPic);
                tappedLetter.Add(false);
                this.letterCount++;
                letterReady = false;
            }

            // move letters in list along the belt
            leftSide--;
            int count = 0;
            foreach (Image image in letters)
            {
                //moves letters across belt (speed depends on level)
                double curMargin = image.Margin.Left;

                image.Margin = new Thickness(theLetters[count].GetLPos(), 0, 0, 0);
                //moves belt normal
                if (level == 1)
                    theLetters[count].SetLPos(1.3);
                //moves belt faster
                if (level == 2)
                    theLetters[count].SetLPos(1.5);
                //moves belt faster
                if (level == 3)
                    theLetters[count].SetLPos(1.7);
                //moves belt faster
                if (level == 4)
                    theLetters[count].SetLPos(2.0);
                //moves belt fastest
                if (level == 5)
                    theLetters[count].SetLPos(2.4);

                if (level == 6)
                    theLetters[count].SetLPos(2.8);

                if (level == 7)
                    theLetters[count].SetLPos(3.0);

                if (level == 8)
                    theLetters[count].SetLPos(3.4);

                if (level == 9)
                    theLetters[count].SetLPos(4.0);

                if (theLetters[count].GetLPos() <= -100)
                {
                    //Removes letter once at a certain spot
                    theSpot.Children.RemoveAt(count);
                    theLetters.RemoveAt(count);
                    letters.RemoveAt(count);


                    if (tappedLetter[count] == true)
                    {
                        //not waste
                    }
                    else
                    {
                        //Removed letter counts to waste (if wasnt clicked)
                        wasteCollect++;
                        txtWasteCounter.Text = wasteCollect.ToString() + " / 100";
                        sbSmoke.Begin();
                        //If waste gets to 100, Game over
                        if (wasteCollect >= 100)
                        {
                            musicBackground.Stop();
                            gameover.Play();
                            wasteCollect = 0;
                            txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
                            beltTimer.Stop();
                            letterTimer.Stop();
                            theSpot.Children.Clear();
                            txtRoundOver.Text = "Game Over";
                            sbRoundOver.Begin();
                            sbGameOver.Begin();
                        }

                    }
                    tappedLetter.RemoveAt(count);
                    break;
                }
                count++;

            }
        }//end belttimer tick

        private void LetterPic_Tapped(object sender, TappedRoutedEventArgs e)
        {

            if (toggleSwitch.IsOn) //Refering to Left answer bar
            {
                if (maxCountBar2 < 11)
                {
                    action.Play();
                    Image tappedImage = sender as Image;
                    string tappedName = tappedImage.Name;
                    char tappedChar = Convert.ToChar(tappedName.Substring(tappedName.Length - 1, 1));
                    theWord2 += tappedChar; // adds letter to word to check
                    Image guess = new Image();
                    guess.Name = tappedImage.Name;
                    guess.Source = tappedImage.Source;
                    lettersGuessed.Add(guess);
                    guess.Height = 50;
                    guess.Width = 50;
                    guess.Margin = new Thickness(1);
                    tappedImage.Source = new BitmapImage(new Uri(
                       this.BaseUri, "Assets/ImagesWP/Blank.png"));
                    tappedImage.IsHitTestVisible = false;
                    answerBar2.Children.Add(guess); // adds letter to answer bar visually
                    maxCountBar2++;
                    int indexTapped = letters.IndexOf(tappedImage);
                    tappedLetter[indexTapped] = true;
                }
                else
                {
                    //if answer bar has max letters (11) then do nothing
                }

            }
            else
            {
                //refers to the 2nd action bar
                if (maxCountBar1 < 11)
                {
                    action.Play();
                    Image tappedImage = sender as Image;
                    string tappedName = tappedImage.Name;
                    char tappedChar = Convert.ToChar(tappedName.Substring(tappedName.Length - 1, 1));
                    theWord1 += tappedChar;
                    Image guess = new Image();
                    guess.Name = tappedImage.Name;
                    guess.Source = tappedImage.Source;
                    lettersGuessed.Add(guess);
                    guess.Height = 50;
                    guess.Width = 50;
                    guess.Margin = new Thickness(1);
                    tappedImage.Source = new BitmapImage(new Uri(
                       this.BaseUri, "Assets/ImagesWP/Blank.png"));
                    tappedImage.IsHitTestVisible = false;
                    answerBar1.Children.Add(guess);
                    maxCountBar1++;

                    int indexTapped = letters.IndexOf(tappedImage);
                    tappedLetter[indexTapped] = true;
                }
                else { }

            }


        }

        private void WordCheck(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //checks word on left answer bar
            string wordToCheck = theWord1;
            sbBuildPress.Begin();


            if (dict.WordCheck(wordToCheck))
            {

                if (wordToCheck.Length > 10)
                {
                    score += 1000;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 9)
                {
                    score += 700;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 8)
                {
                    score += 450;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 7)
                {
                    score += 300;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 6)
                {
                    score += 200;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 5)
                {
                    score += 150;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 4)
                {
                    score += 100;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 3)
                {
                    score += 75;

                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 2)
                {
                    score += 25;

                    txtScore.Text = score.ToString();
                }
                //Plays right answer sound and storyboard
                rightAnswer.Play();
                sbRightAnswer.Begin();
                answerBar1.Children.Clear();
                maxCountBar1 = 0;

                if (score >= pointsUntilNextRound)
                {
                    //moves player to next level if points reach target(doubles level increase)
                    level++;
                    txtCurrentLevel.Text = "Current Level " + level;
                    txtRoundOver.Text = "Level " + level;
                    pointsUntilNextRound *= 2;
                    sbRoundOver.Begin();
                    lastLevelYouWereOn = level;
                    wasteCollect = 0;
                    txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
                }
            }
            else
            {
                //if letter isn't in dict then each letter in fail words counts to waste
                sbSmoke.Begin();
                sbWrongAnswer.Begin();
                wrongAnswer.Play();
                int wordWaste = answerBar1.Children.Count();
                wasteCollect += wordWaste;
                txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
                answerBar1.Children.Clear();
                maxCountBar1 = 0;
            }

            theWord1 = "";  // clears word to check
            if (wasteCollect >= 100)
            {
                //Plays game over screen if waste hits target(100)
                musicBackground.Stop();
                gameover.Play();
                wasteCollect = 0;
                txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
                beltTimer.Stop();
                letterTimer.Stop();
                theSpot.Children.Clear();
                txtRoundOver.Text = "Game Over";
                sbRoundOver.Begin();
                sbGameOver.Begin();

            }


        }
        //Refers to Second Word to check and answer bar (Code replicates code for answer bar 1)
        private void WordTwoCheck(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            string wordToCheck = theWord2;
            sbBuildPressTwo.Begin();


            if (dict.WordCheck(wordToCheck))
            {
                if (wordToCheck.Length > 10)
                {
                    score += 1000;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 9)
                {
                    score += 700;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 8)
                {
                    score += 450;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 7)
                {
                    score += 300;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 6)
                {
                    score += 200;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 5)
                {
                    score += 150;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 4)
                {
                    score += 100;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 3)
                {
                    score += 75;
                    txtScore.Text = score.ToString();
                }
                else if (wordToCheck.Length > 2)
                {
                    score += 25;
                    txtScore.Text = score.ToString();
                }
                sbRightAnswer.Begin();
                rightAnswer.Play();
                answerBar2.Children.Clear();
                maxCountBar2 = 0;

                if (score >= pointsUntilNextRound)
                {
                    lastLevelYouWereOn = level;
                    level++;
                    txtCurrentLevel.Text = "Current Level " + level;
                    txtRoundOver.Text = "Level " + level;
                    pointsUntilNextRound *= 2;
                    sbRoundOver.Begin();
                    wasteCollect = 0;
                    txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
                }
            }
            else
            {
                sbSmoke.Begin();
                sbWrongAnswer.Begin();
                wrongAnswer.Play();
                int wordWaste = answerBar2.Children.Count();
                wasteCollect += wordWaste;
                txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
                answerBar2.Children.Clear();
                maxCountBar2 = 0;
            }

            theWord2 = "";
            if (wasteCollect >= 100)
            {
                musicBackground.Stop();
                gameover.Play();
                wasteCollect = 0;
                txtWasteCounter.Text = Convert.ToString(wasteCollect) + " / 100";
                beltTimer.Stop();
                letterTimer.Stop();
                theSpot.Children.Clear();
                txtRoundOver.Text = "Game Over";
                sbRoundOver.Begin();
                sbGameOver.Begin();


            }


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int recordedScore = Convert.ToInt16(e.Parameter);
            level = recordedScore;
            lastLevelYouWereOn = level;
            FinishSetup();


        }



           private void sbGameOver_Completed(object sender, object e)
         {
            btnGameoverNewGame.IsTapEnabled = true;
            btnGameoverContinue.IsTapEnabled = true;
         }

        private void GameOverNewGame(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void GameOverContinue(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), lastLevelYouWereOn);
        }
    }  // end MainPage
} // end namespace
