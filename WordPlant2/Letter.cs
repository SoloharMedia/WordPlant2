using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace WordPlant2
{

    class Letter
    {

        //Images for Letters coming out of machine
        string[] imgSource =
        {
            "Assets/ImagesWP/A.png",
            "Assets/ImagesWP/B.png",
            "Assets/ImagesWP/C.png",
            "Assets/ImagesWP/D.png",
            "Assets/ImagesWP/E.png",
            "Assets/ImagesWP/F.png",
            "Assets/ImagesWP/G.png",
            "Assets/ImagesWP/H.png",
            "Assets/ImagesWP/I.png",
            "Assets/ImagesWP/J.png",
            "Assets/ImagesWP/K.png",
            "Assets/ImagesWP/L.png",
            "Assets/ImagesWP/M.png",
            "Assets/ImagesWP/N.png",
            "Assets/ImagesWP/O.png",
            "Assets/ImagesWP/P.png",
            "Assets/ImagesWP/Q.png",
            "Assets/ImagesWP/R.png",
            "Assets/ImagesWP/S.png",
            "Assets/ImagesWP/T.png",
            "Assets/ImagesWP/U.png",
            "Assets/ImagesWP/V.png",
            "Assets/ImagesWP/W.png",
            "Assets/ImagesWP/X.png",
            "Assets/ImagesWP/Y.png",
            "Assets/ImagesWP/Z.png"
        };
        //vowels only, to help with spawning more vowels
        string[] imgSourceVowel =
        {
            "Assets/ImagesWP/A.png",
            "Assets/ImagesWP/E.png",
            "Assets/ImagesWP/I.png",
            "Assets/ImagesWP/O.png",
            "Assets/ImagesWP/U.png"
        };
        //chars assigned to images name so we can pull it later for word checks
        char[] letterVal =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z'
        };
        //chars assigned to the vowels
        char[] letterVowelVal =
        {
            'A', 'E', 'I', 'O', 'U'
        };
        Random randNum = new Random();

        char value;
        string imageSource;
        int screenWidth = 0;
        double lPos = 0;
        bool activated = false;
        public static int vowelCounter = 0;



        public Letter(int width)
        {
            //Vowel Count
            if (vowelCounter < 6)
            {
                //If under 7 consonants spawn, keep spawning consonants
                int randomNumber = randNum.Next(letterVal.Length);
                value = letterVal[randomNumber];
                imageSource = imgSource[randomNumber];
                screenWidth = width;
                lPos = Convert.ToDouble(screenWidth - 170);
                vowelCounter++;
            }
            else
            {
                //Every 7th Image spawned is a vowel no matter what
                int randomNumber = randNum.Next(letterVowelVal.Length);
                value = letterVowelVal[randomNumber];
                imageSource = imgSourceVowel[randomNumber];
                screenWidth = width;
                lPos = Convert.ToDouble(screenWidth - 170);
                vowelCounter = 0;
            }
        }

        public bool GetActive()
        {
            return activated;
        }

        public void SetActive()
        {
            activated = true;
        }
        public void SetLPos(double lPos)
        {
            this.lPos -= lPos;
        }

        public double GetLPos()
        {
            return lPos;
        }

        public char GetChar()
        {
            return value;
        }

        public string GetImageSource()
        {
            return imageSource;
        }


    }
}
