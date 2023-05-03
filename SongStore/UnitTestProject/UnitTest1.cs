using RecentlyPlayedSongsStore;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace UnitTestProject
{

    public class UnitTest1
    {
        [Fact]
        public void InitialSongCapacityMentionedIsRetained_Test()
        {
            int initialCapacity = 4;
            RecentlyPlayedSongs recentlyPlayedSongs = new RecentlyPlayedSongs(4);
            User user = new User() { Name = Helpers.GetUserName() };

            for (int index = 0; index <= initialCapacity; index++)
            {
                recentlyPlayedSongs.AddSongToPlaylist(user, new Song() { Name = Helpers.GetSongName() });
            }

            Assert.Equal(initialCapacity, recentlyPlayedSongs.GetRecentlyPlayedSongs(user).Count);
        }

        [Fact]
        public void SongUserPairListMaintained_Test()
        {
            var _songs = new Dictionary<string, List<Song>>();
            var user1 = new User() { Name = "User_1" };
            var user1SongList = new List<Song>()
            {
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()}
            };
            var user2 = new User() { Name = "User_2" };
            var user2SongList = new List<Song>()
            {
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()}
            };
            RecentlyPlayedSongs recentlyPlayedSongs = new RecentlyPlayedSongs(user1SongList.Count);
            foreach (Song song in user1SongList)
            {
                recentlyPlayedSongs.AddSongToPlaylist(user1, song);
            }
            Assert.True(DoBothListsContainSameData(user1SongList, recentlyPlayedSongs.GetRecentlyPlayedSongs(user1)));

            recentlyPlayedSongs = new RecentlyPlayedSongs(user2SongList.Count);
            foreach (Song song in user2SongList)
            {
                recentlyPlayedSongs.AddSongToPlaylist(user2, song);
            }
            Assert.True(DoBothListsContainSameData(user2SongList, recentlyPlayedSongs.GetRecentlyPlayedSongs(user2)));
        }

        [Fact]
        public void RecentlyPlayedSongsMaintainedBasedOnInsertion_Test()
        {
            int initialCapacity = 3;
            var userList = new List<User>()
            {
                new User() { Name = Helpers.GetUserName()},
                new User() { Name = Helpers.GetUserName()}
            };

            var user1SongList = new List<Song>()
            {
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()}
            };
            var user2SongList = new List<Song>()
            {
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()},
                new Song() { Name = Helpers.GetSongName()}
            };

            var recentlyPlayedSongsList = new List<RecentlyPlayedSongs>();
            RecentlyPlayedSongs recentlyPlayedSongs = new RecentlyPlayedSongs(initialCapacity);

            foreach (Song song in user1SongList)
            {
                recentlyPlayedSongs.AddSongToPlaylist(userList[0], song);
            }
            recentlyPlayedSongsList.Add(recentlyPlayedSongs);
            recentlyPlayedSongs = new RecentlyPlayedSongs(initialCapacity);
            foreach (Song song in user2SongList)
            {
                recentlyPlayedSongs.AddSongToPlaylist(userList[1], song);
            }
            recentlyPlayedSongsList.Add(recentlyPlayedSongs);

            Assert.True(IsDataInBothListInSameOrder(user1SongList, recentlyPlayedSongsList[0].GetRecentlyPlayedSongs(userList[0])), $"Data is not in same order for user {userList[0].Name}");
            Assert.True(IsDataInBothListInSameOrder(user2SongList, recentlyPlayedSongsList[1].GetRecentlyPlayedSongs(userList[1])), $"Data is not in same order for user {userList[1].Name}");
        }

        private bool DoBothListsContainSameData(List<Song> expected, List<Song> actual)
        {
            bool isListDataSame = true;
            if (expected.Count != actual.Count)
            {
                System.Console.WriteLine($"Total songs in Expected list is {expected.Count} but in actual it is {actual.Count}");
                return false;
            }

            for (int index = 0; index < expected.Count; index++)
            {
                if (!actual.Contains(expected[index]))
                {
                    System.Console.WriteLine($"'{expected[index].Name}' song is not present in the actual list.");
                    isListDataSame = false;
                }
            }

            return isListDataSame;
        }
        private bool IsDataInBothListInSameOrder(List<Song> expected, List<Song> actual)
        {
            bool isOrderRetained = true;
            if (expected.Count != actual.Count)
            {
                System.Console.WriteLine($"Total songs in Expected list is {expected.Count} but in actual it is {actual.Count}");
                return false;
            }

            for (int index = 0; index < expected.Count; index++)
            {
                if (expected[index].Name != actual[index].Name)
                {
                    System.Console.WriteLine($"Expected songs at index {index + 1} is '{expected[index].Name}' but actual is {actual[index].Name}");
                    isOrderRetained = false;
                }
            }

            return isOrderRetained;
        }
    }
}
