using System.Collections.Generic;

namespace RecentlyPlayedSongsStore
{
    public class RecentlyPlayedSongs
    {
        private int _capacity;
        private Dictionary<string, LinkedListNode<SongUserPair>> _songMap;
        private LinkedList<SongUserPair> _recentlyPlayedSongsList;

        public RecentlyPlayedSongs(int initialCapacity)
        {
            _capacity = initialCapacity;
            _songMap = new Dictionary<string, LinkedListNode<SongUserPair>>();
            _recentlyPlayedSongsList = new LinkedList<SongUserPair>();
        }

        public void AddSongToPlaylist(User user, Song song)
        {
            SongUserPair pair = new SongUserPair { Song = song, User = user };

            // Remove the least recently played song if the store is full
            if (_recentlyPlayedSongsList.Count >= _capacity)
            {
                SongUserPair leastRecentlyPlayedPair = _recentlyPlayedSongsList.First.Value;
                _songMap.Remove(leastRecentlyPlayedPair.User.Name);
                _recentlyPlayedSongsList.RemoveFirst();
            }

            // Add the new song-user pair to the end of the list
            LinkedListNode<SongUserPair> node = _recentlyPlayedSongsList.AddLast(pair);

            // Update the song map with the new node
            _songMap[user.Name] = node;
        }

        public List<Song> GetRecentlyPlayedSongs(User user)
        {
            if (_songMap.ContainsKey(user.Name))
            {
                // Move the song-user pair to the end of the list to indicate that it's the most recently played
                _recentlyPlayedSongsList.Remove(_songMap[user.Name]);
                _recentlyPlayedSongsList.AddLast(_songMap[user.Name]);

                // Create a list of the user's recently played songs
                List<Song> recentlyPlayedSongs = new List<Song>();
                foreach (SongUserPair pair in _recentlyPlayedSongsList)
                {
                    if (pair.User.Name == user.Name)
                    {
                        recentlyPlayedSongs.Add(pair.Song);
                    }
                }

                return recentlyPlayedSongs;
            }
            else
            {
                return new List<Song>();
            }
        }
    }

    public class Song
    {
        public string Name { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
    }

    public class SongUserPair
    {
        public Song Song { get; set; }
        public User User { get; set; }
    }
}
