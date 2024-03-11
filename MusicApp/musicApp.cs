using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    internal class musicApp
    {
        string[] playlist = new string[0];

    public void CreatePlaylist()
    {
        Console.WriteLine("Playlist created.");
    }

    public void AddMusic()
    {
        DisplayPlaylist();
        Console.WriteLine("Enter the name of the music:");
        string musicName = Console.ReadLine();
        Array.Resize(ref playlist, playlist.Length + 1);
        playlist[playlist.Length - 1] = musicName;
        Console.WriteLine("{musicName} has successfully been added to playlist.");
    }

    public void EditMusic()
    {
            DisplayPlaylist();

            while (true)
            {
                Console.WriteLine("Enter the index of the music to edit:");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index >= 0 && index < playlist.Length)
                {
                    Console.WriteLine("Enter the new name of the music:");
                    string newName = Console.ReadLine();
                    Console.WriteLine($"{playlist[index]} has successfully been changed to {newName}");
                    playlist[index] = newName;
                    DisplayPlaylist();

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
    }

    public void PlayMusic()
    {
            DisplayPlaylist();
            Console.WriteLine("Enter the index of the music to play:");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index >= 0 && index < playlist.Length)
        {
            Console.WriteLine($"Playing {playlist[index]}...");

        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
        }

    public void DeleteMusic()
    {
            DisplayPlaylist();
            Console.WriteLine("Enter the index of the music to delete:");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index >= 0 && index < playlist.Length)
            {
                for (int i = index; i < playlist.Length - 1; i++)
                {
                    playlist[i] = playlist[i + 1];
                }
                
                Console.WriteLine($"{playlist[index]} has succesfully been deleted from playlist.");
                Array.Resize(ref playlist, playlist.Length - 1);
                DisplayPlaylist();
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

    public void ShufflePlaylist()
    {
        Random rnd = new Random();
        playlist = playlist.OrderBy(x => rnd.Next()).ToArray();
        DisplayPlaylist();
        Console.WriteLine("Playlist shuffled.");
        DisplayPlaylist();
    }

    public void SortPlaylist()
    {
        Array.Sort(playlist);
            DisplayPlaylist();
            Console.WriteLine("Playlist sorted.");

    }

    public void DisplayPlaylist()
    {
            if (playlist != null && playlist.Length > 0)
            {
                for (int i = 0; i < playlist.Length; i++)
                {
                    Console.WriteLine($"index {i} : {playlist[i]}");
                }
            }
            else
            {
                Console.WriteLine("Playlist is Empty");
            }

    }
    public void DisplayMenu()
    {
        Console.WriteLine("Menu options:");
        Console.WriteLine("1. Create Playlist");
        Console.WriteLine("2. Add Music to Playlist");
        Console.WriteLine("3. Edit Music");
        Console.WriteLine("4. Play Music");
        Console.WriteLine("5. Delete Music from Playlist");
        Console.WriteLine("6. Shuffle Playlist");
        Console.WriteLine("7. Sort Playlist");
        Console.WriteLine("8. Exit");
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            DisplayMenu();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreatePlaylist();
                    break;
                case "2":
                    AddMusic();
                    break;
                case "3":
                    EditMusic();
                    break;
                case "4":
                    PlayMusic();
                    break;
                case "5":
                    DeleteMusic();
                    break;
                case "6":
                    ShufflePlaylist();
                    break;
                case "7":
                    SortPlaylist();
                    break;
                case "8":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    }
}
