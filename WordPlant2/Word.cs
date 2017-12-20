using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WordPlant2
{
    class Word
    {
        bool inDictionary = false;
        List<string> dictionary = new List<string>();

        public Word()
        { }

        public async void ReadFile()
        {
            // settings
            var path = @"Assets\wordDict.txt"; // sets the file location for our dict
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            // acquire file
            var file = await folder.GetFileAsync(path);
            var readFile = await FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                if (line.Length >= 3)
                    dictionary.Add(line);
            }
            string[] usableDictionary = dictionary.ToArray();
        }

        public bool WordCheck(string tentativeWord)
        {
            inDictionary = false; // sets to false by default

            foreach (var line in dictionary)
            {
                if (tentativeWord.ToLower().Equals(line.ToLower()))
                {
                    //if word is in dict, sets to true
                    inDictionary = true;
                }
            }
            return inDictionary;
        }
    }
}
