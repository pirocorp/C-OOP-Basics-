using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var numberOfSongs = int.Parse(Console.ReadLine());
        var songs = new List<Song>();
        var totalSongsAdded = 0;

        for (var songIndex = 0; songIndex < numberOfSongs; songIndex++)
        {
            try
            {
                var currentSong = Song.Parse(Console.ReadLine());
                songs.Add(currentSong);
                Console.WriteLine($"Song added.");
                totalSongsAdded++;
            }
            catch (InvalidSongException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine($"Songs added: {totalSongsAdded}");

        var totalLengthInSec = songs.Sum(x => x.SongLength());

        var sec = totalLengthInSec % 60;
        var totalMin = totalLengthInSec / 60;
        var min = totalMin % 60;
        var hours = totalMin / 60;

        Console.WriteLine($"Playlist length: {hours}h {min}m {sec}s");
    }
}