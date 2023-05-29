using System;

// Target interface
interface IAudioPlayer
{
    void Play(string filename);
}

// Adaptee (Incompatible class)
class NewAudioLibrary
{
    public void PlayMp3(string filename)
    {
        Console.WriteLine($"Playing MP3 file: {filename}");
    }
}

// Adapter
class AudioPlayerAdapter : IAudioPlayer
{
    private NewAudioLibrary newAudioLibrary;

    public AudioPlayerAdapter(NewAudioLibrary newAudioLibrary)
    {
        this.newAudioLibrary = newAudioLibrary;
    }

    public void Play(string filename)
    {
        // Convert the audio file format to MP3 if necessary
        string mp3Filename = ConvertToMp3(filename);

        // Call the new audio library's method
        newAudioLibrary.PlayMp3(mp3Filename);
    }

    private string ConvertToMp3(string filename)
    {
        // Convert the audio file to MP3 format
        // This is a simplified implementation for demonstration purposes
        return $"Converted_{filename}.mp3";
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create an instance of the NewAudioLibrary
        NewAudioLibrary newAudioLibrary = new NewAudioLibrary();

        // Create an instance of the AudioPlayerAdapter and pass the NewAudioLibrary to its constructor
        IAudioPlayer audioPlayer = new AudioPlayerAdapter(newAudioLibrary);

        // Call the Play method on the audio player
        audioPlayer.Play("song.flac");
    }
}
