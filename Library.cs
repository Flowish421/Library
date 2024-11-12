using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

//Här skapar jag en klass för att represntera biblioteket (Library)
public class Library
{
    //Den här koden Definierar filvägen där data sparas osv.
    private const string DataFilePath = "LibraryData.json";

    // Lista som ska innehåller alla böcker i biblioteket.
    public List<Book> Books { get; set; } = new List<Book>();
    //Lista som innehåller Författare i biblan.
    public List<Author> Authors { get; set; } = new List<Author>();
    // En konstruktor som kör fnär objektet skapas och laddar ner all data från filen.
    public Library() => LoadData();

    public void AddBook(Book book)
    {
        book.Id = Books.Count + 1;
        Books.Add(book);
        SaveData();
    }

    public void AddAuthor(Author author)
    {
        author.Id = Authors.Count + 1;
        Authors.Add(author);
        SaveData();
    }

    public void UpdateBook(int bookId, string newTitle, string newGenre, int newPublicationYear)
    {
        var book = Books.FirstOrDefault(b => b.Id == bookId);
        if (book != null)
        {
            book.Title = newTitle;
            book.Genre = newGenre;
            book.PublicationYear = newPublicationYear;
            SaveData();
        }
        else
        {
            Console.WriteLine("Boken finns inte.");
        }
    }

    public void UpdateAuthor(int authorId, string newName)
    {
        var author = Authors.FirstOrDefault(a => a.Id == authorId);
        if (author != null)
        {
            author.Name = newName;
            SaveData();
        }
        else
        {
            Console.WriteLine("Författaren finns inte.");
        }
    }

    public void RemoveBook(int bookId)
    {
        var book = Books.FirstOrDefault(b => b.Id == bookId);
        if (book != null)
        {
            Books.Remove(book);
            SaveData();
            Console.WriteLine("Boken har tagits bort.");
        }
        else
        {
            Console.WriteLine("Fel: Boken finns inte.");
        }
    }

    public void RemoveAuthor(int authorId)
    {
        var author = Authors.FirstOrDefault(a => a.Id == authorId);
        if (author != null)
        {
            Authors.Remove(author);
            SaveData();
            Console.WriteLine("Författaren har tagits bort.");
        }
        else
        {
            Console.WriteLine("Fel: Författaren finns inte.");
        }
    }

    public void ListAll()
    {
        Console.WriteLine("Böcker:");
        foreach (var book in Books)
            Console.WriteLine($"{book.Id}: {book.Title} - {book.Genre}, År: {book.PublicationYear}");
        Console.WriteLine("Författare:");
        foreach (var author in Authors)
            Console.WriteLine($"{author.Id}: {author.Name}");
    }

    private void LoadData()
    {
        if (File.Exists(DataFilePath))
        {
            try
            {
                var jsonData = File.ReadAllText(DataFilePath);
                var data = JsonConvert.DeserializeObject<Library>(jsonData);
                Books = data?.Books ?? new List<Book>();
                Authors = data?.Authors ?? new List<Author>();
            }
            catch (Exception)
            {
                Console.WriteLine("JSON-filen är korrupt. Laddar tomma data.");
                Books = new List<Book>();
                Authors = new List<Author>();
            }
        }
        else
        {
            Console.WriteLine("JSON-filen saknas. Skapar tomma data.");
        }
    }

    public void SaveData()
    {
        var jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(DataFilePath, jsonData);
    }
}
