using RecentlyPlayedSongsStore;
using System;
using System.Collections.Generic;

namespace SongStore
{
    internal class Program
    {
        private static List<string> listOfUsers;
        static void Main(string[] args)
        {
            listOfUsers = new List<string>();
            Console.Write("How many user's data you want to add: ");
            var numberOfUsers = Utilities.ToInt(Console.ReadLine());
            Console.Write("How many songs per user you want to add: ");
            var numberOfSongs = Utilities.ToInt(Console.ReadLine());

            if (!IsValidInputPassed(numberOfUsers) || !IsValidInputPassed(numberOfSongs))
            {
                Console.WriteLine("Invalid input passed by the user !!!");
                WaitBeforeExit();
                return;
            }


            var songsUserPair = GetListOfUserSongPair(numberOfUsers, numberOfSongs);

            int userIndex = 0;

            


            foreach (var songsUser in songsUserPair)
            {
                Console.WriteLine($"{listOfUsers[userIndex]}'s recently played songs:");
                var songs = songsUser.GetRecentlyPlayedSongs(new User() { Name = listOfUsers[userIndex++] });
                foreach(var song in songs)
                {
                    Console.WriteLine("• "+song.Name);
                }

            }
            WaitBeforeExit();
        }

        private static List<RecentlyPlayedSongs> GetListOfUserSongPair(int numberOfUsers, int numberOfSongsToAdd)
        {
            var recentlyPlayedSongsList = new List<RecentlyPlayedSongs>();

            for (int index = 0; index < numberOfUsers; index++)
            {
                RecentlyPlayedSongs recentlyPlayedSongs = new RecentlyPlayedSongs(numberOfSongsToAdd);
                Console.Write("Enter username: ");
                var user = new User() { Name = Console.ReadLine().Trim() };
                listOfUsers.Add(user.Name);
                for (int songIndex = 0; songIndex < numberOfSongsToAdd; songIndex++)
                {
                    Console.Write($"Enter song number {songIndex+1} for user '{user.Name}': ");
                    recentlyPlayedSongs.AddSongToPlaylist(user, new Song() { Name = Console.ReadLine().Trim() });
                }
                recentlyPlayedSongsList.Add(recentlyPlayedSongs);
            }

            return recentlyPlayedSongsList;
        }

        private static bool IsValidInputPassed(int input) => input > 0;
        
        private static void WaitBeforeExit()
        {
            Console.WriteLine("<- Press any key to Exit ->");
            Console.ReadLine();
        }
    }
}
