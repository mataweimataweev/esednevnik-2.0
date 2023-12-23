using System;
using System.Collections.Generic;

class Program
{
    static List<Note> notes = new List<Note>
    {
        new Note("Заметка 1", "Описание 1", new DateTime(2023, 6, 6)),
        new Note("Заметка 2", "Описание 2", new DateTime(2023, 6, 8)),
        new Note("Заметка 3", "Описание 3", new DateTime(2023, 6, 13)),
        new Note("Заметка 4", "Описание 4", new DateTime(2023, 6, 15)),
        new Note("Заметка 5", "Описание 5", new DateTime(2023, 6, 20))
    };

    static int currentNoteIndex = 0;

    static void Main()
    {
        Console.WriteLine("Добро пожаловать в ежедневник!");

        while (true)
        {
            Console.Clear();
            DisplayMenu();
            HandleUserInput();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Меню:");
        for (int i = 0; i < notes.Count; i++)
        {
            string title = notes[i].Title;
            if (i == currentNoteIndex)
                title = ">> " + title;
            Console.WriteLine(title);
        }
    }

    static void HandleUserInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                currentNoteIndex = Math.Max(0, currentNoteIndex - 1);
                break;
            case ConsoleKey.DownArrow:
                currentNoteIndex = Math.Min(notes.Count - 1, currentNoteIndex + 1);
                break;
            case ConsoleKey.Enter:
                ShowNoteDetails(notes[currentNoteIndex]);
                break;
        }
    }

    static void ShowNoteDetails(Note note)
    {
        Console.Clear();
        Console.WriteLine("Подробная информация о заметке:");
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
}

class Note
{
    public string Title { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
}