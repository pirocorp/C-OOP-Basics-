using System;
using System.Linq;

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string ArtistName
    {
        get => this.artistName;
        set
        {
            ValidateName(value, nameof(artistName));
            this.artistName = value.Trim();
        }
    }

    public string SongName
    {
        get => this.songName;
        set
        {
            ValidateName(value, nameof(songName));
            this.songName = value.Trim();
        }
    }

    public int Minutes
    {
        get => this.minutes;
        set
        {
            ValidateTime(value, nameof(minutes));
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get => this.seconds;
        set
        {
            ValidateTime(value, nameof(seconds));
            this.seconds = value;
        }
    }

    private static void ValidateName(string value, string nameOfField)
    {
        var minNameLenght = 3;
        var maxNameLenght = 20;

        if (nameOfField == "songName")
        {
            maxNameLenght = 30;
        }

        if (value == null || value.Length < minNameLenght || value.Length > maxNameLenght)
        {
            if (nameOfField == "songName")
            {
                throw new InvalidSongNameException();
            }
            else
            {
                throw new InvalidArtistNameException();
            }
        }
    }

    private static void ValidateTime(int value, string nameOfField)
    {
        var minTimeLenght = 0;
        var maxTimeLenght = 59;

        if (nameOfField == "minutes")
        {
            maxTimeLenght = 14;
        }

        if (value < minTimeLenght || value > maxTimeLenght)
        {
            if (nameOfField == "minutes")
            {
                throw new InvalidSongMinutesException();
            }
            else
            {
                throw new InvalidSongSecondsException();
            }
        }
    }

    public static Song Parse(string input)
    {
        var tokens = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        ValidateArgs(tokens);

        var artistName = tokens[0];
        var songName = tokens[1];

        var length = ParseLength(tokens[2]);
        var minutes = length[0];
        var seconds = length[1];

        return new Song(artistName, songName, minutes, seconds);
    }

    private static void ValidateArgs(string[] tokens)
    {
        if (tokens.Length != 3)
        {
            throw new InvalidSongException();
        }
    }

    private static int[] ParseLength(string length)
    {
        var tokens = length.Split(new []{ ':' }, StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length != 2 || tokens.Any(t => !t.All(c => char.IsDigit(c))))
        {
            throw new InvalidSongLengthException();
        }

        return tokens.Select(int.Parse).ToArray();
    }

    public long SongLength()
    {
        return this.Minutes * 60 + this.Seconds;
    }
}