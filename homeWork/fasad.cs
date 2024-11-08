using System;

class TV
{
    public void On() => Console.WriteLine("TV включен.");
    public void Off() => Console.WriteLine("TV выключен.");
    public void SetChannel(int channel) => Console.WriteLine($"TV: канал установлен на {channel}.");
}

class AudioSystem
{
    public void On() => Console.WriteLine("Аудиосистема включена.");
    public void Off() => Console.WriteLine("Аудиосистема выключена.");
    public void SetVolume(int volume) => Console.WriteLine($"Громкость установлена на {volume}.");
}

class DVDPlayer
{
    public void Play() => Console.WriteLine("DVD-проигрыватель: воспроизведение.");
    public void Pause() => Console.WriteLine("DVD-проигрыватель: пауза.");
    public void Stop() => Console.WriteLine("DVD-проигрыватель: остановка.");
}

class GameConsole
{
    public void On() => Console.WriteLine("Игровая консоль включена.");
    public void PlayGame() => Console.WriteLine("Игра запущена на игровой консоли.");
}

class HomeTheaterFacade
{
    private TV tv = new TV();
    private AudioSystem audio = new AudioSystem();
    private DVDPlayer dvd = new DVDPlayer();
    private GameConsole console = new GameConsole();

    public void WatchMovie()
    {
        Console.WriteLine("Подготовка к просмотру фильма:");
        tv.On();
        audio.On();
        dvd.Play();
    }

    public void EndMovie()
    {
        Console.WriteLine("Завершение просмотра фильма:");
        dvd.Stop();
        tv.Off();
        audio.Off();
    }

    public void PlayGame()
    {
        Console.WriteLine("Подготовка к запуску игры:");
        console.On();
        console.PlayGame();
    }

    public void ListenToMusic()
    {
        Console.WriteLine("Подготовка к прослушиванию музыки:");
        tv.On();
        audio.On();
        audio.SetVolume(50);
    }

    public void AdjustVolume(int volume)
    {
        audio.SetVolume(volume);
    }
}

class Program
{
    static void Main()
    {
        HomeTheaterFacade homeTheater = new HomeTheaterFacade();

        homeTheater.WatchMovie();
        Console.WriteLine();

        homeTheater.AdjustVolume(30);
        Console.WriteLine();

        homeTheater.EndMovie();
        Console.WriteLine();

        homeTheater.PlayGame();
        Console.WriteLine();

        homeTheater.ListenToMusic();
        Console.WriteLine();
    }
}
