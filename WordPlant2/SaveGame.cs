using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WordPlant2
{
    class SaveGame
    {

        public async Task SaveScore(string level)
        {
            //Creates folder - Opens if exsists
            var localFolder = ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync(
                "gameSave.txt", CreationCollisionOption.OpenIfExists);

            string curLevel = "";
            curLevel = level.ToString();

            file = await localFolder.CreateFileAsync(
                "gameSave.txt", CreationCollisionOption.ReplaceExisting);
            //writes level to text file
            await FileIO.WriteTextAsync(file, curLevel);
            return;
        }



    }
}
