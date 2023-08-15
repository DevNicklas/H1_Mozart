using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mozart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Starts playing the beautiful music
            PlayMusic();
        }

        #region Model
        /// <summary>
        /// Files which is used to play Mozart waltz
        /// </summary>
        /// <returns>An array of file paths</returns>
        static string[] GetFiles()
        {
            #region Menuets Music Elements
            int[,] menuets =
{
                { 96, 22, 141, 41, 105, 122, 11, 30, 70, 121, 26, 9, 112, 49, 109, 14 },
                { 32, 6, 128, 63, 146, 46, 134, 81, 117, 39, 126, 56, 174, 18, 116, 83 },
                { 69, 95, 158, 13, 153, 55, 110, 24, 66, 139, 15, 132, 73, 58, 145, 79 },
                { 40, 17, 113, 85, 161, 2, 159, 100, 90, 176, 7, 34, 67, 160, 52, 170 },
                { 148, 74, 163, 45, 80, 97, 36, 107, 25, 143, 64, 125, 76, 136, 1, 93 },
                { 104, 157, 27, 167, 154, 68, 118, 91, 138, 71, 150, 29, 101, 162, 23, 151 },
                { 152, 60, 171, 53, 99, 133, 21, 127, 16, 155, 57, 175, 43, 168, 89, 172 },
                { 119, 84, 114, 50, 140, 86, 169, 94, 120, 88, 48, 166, 51, 115, 72, 111 },
                { 98, 142, 42, 156, 75, 129, 62, 123, 65, 77, 19, 82, 137, 38, 149, 8 },
                { 3, 87, 165, 61, 135, 47, 147, 33, 102, 4, 31, 164, 144, 59, 173, 78 },
                { 54, 130, 10, 103, 28, 37, 106, 5, 35, 20, 108, 92, 12, 124, 44, 131 }
            };
            #endregion

            #region Trios Music Elements
            int[,] trios =
            {
                { 72, 6, 59, 25, 81, 41, 89, 13, 36, 5, 46, 79, 30, 95, 19, 66 },
                { 56, 82, 42, 74, 14, 7, 26, 71, 76, 20, 64, 84, 8, 35, 47, 88 },
                { 75, 39, 54, 1, 65, 43, 15, 80, 9, 34, 93, 48, 69, 58, 90, 21 },
                { 40, 73, 16, 68, 29, 55, 2, 61, 22, 67, 49, 77, 57, 87, 33, 10 },
                { 83, 3, 28, 53, 37, 17, 44, 70, 63, 85, 32, 96, 12, 23, 50, 91 },
                { 18, 45, 62, 38, 4, 27, 52, 94, 11, 92, 24, 86, 51, 60, 78, 31 }
            };
            #endregion

            // Instance of the Random class
            Random rand = new Random();

            // Array of files
            string[] files = new string[16];

            for (int i = 0; i < 16; i++)
            {
                // Rolls two dices since a minuet needs two dices with 6 sides
                // Which means that the highest number is 12, which is the amount of music elements in one part
                int menuetsDice = rand.Next(2, 12);

                // Rolls one dice since a trios only needs one with 6 sides
                // Highest number is 6, which is the amount of music elements in one part
                int triosDice = rand.Next(1, 6);

                // Adds the correct menuet file to an array of files
                files[i] = @"Wave\M" + menuets[menuetsDice - 2, i] + ".wav";
                // Adds the correct trios file to an array of files
                files[i] = @"Wave\T" + trios[triosDice - 1, i] + ".wav";
            }

            // Returns array of files
            return files;
        }
        #endregion

        #region Controller
        /// <summary>
        /// Plays the beautiful Mozart waltz
        /// </summary>
        static void PlayMusic()
        {
            // Array of files paths
            string[] files = GetFiles();

            // Instance of the System.Media.SoundPlayer class
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

            // Loops thru the array, and plays every file
            foreach (string music in files)
            {
                // Location of a sound file
                sp.SoundLocation = music;

                // Loads a sound file
                sp.Load();

                // Plays the .wav file and loads the .wav file first if it hasn't been loaded
                sp.PlaySync();
            }
        }
        #endregion
    }
}
