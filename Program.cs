using System;

public class Program
{
    private static Library library = new Library();

    public static void Main(string[] args)
    {
        while (true)
        {
            //Gör så att Menyn är i Standard (Mode) Med andra ord gör så att Backgrunds Färgen stannar Vit,
            //Och att inte den uppdaterad färger efter användarens.
            
            Console.ForegroundColor = ConsoleColor.White;
            //--------------------------------------------

            // Menyn Listan
            Console.WriteLine("Lägg till Menyn");
            Console.WriteLine("1. Bok");
            Console.WriteLine("2. Författare");
            Console.WriteLine();
            Console.WriteLine("Uppdatera Menyn");
            Console.WriteLine("3. Bokdetaljer");
            Console.WriteLine("4. Författardetaljer");
            Console.WriteLine();
            Console.WriteLine("5. Ta bort bok");
            Console.WriteLine("6. Ta bort författare");
            Console.WriteLine();
            Console.WriteLine("7. Lista över alla böcker och författare");
            Console.WriteLine("8. Avsluta & spara");


            //BackGrunds Färg till Inmatningen User använder.
            Console.ForegroundColor = ConsoleColor.Green;
            //-----------------------------------------
            //Titel För Konsolen Att den ska Vissa blir Enklare för användare vet vad för app dom avänder (Med andra ord) Konsol
            Console.Title = "Bibliotek";
            //--------------------------------


            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
                continue;
            }
            //Hantera valet med en switch case / Case för case valen
            switch (choice)
            {
                //Det är case 1 och är för att Lägga till en book. så som du ser library.AddBook Det säger sig själv.
                case 1:
                    Console.Write("Titel: ");
                    var title = Console.ReadLine();
                    Console.Write("Genre: ");
                    var genre = Console.ReadLine();
                    Console.Write("Publiceringsår: ");
                    int publicationYear = int.TryParse(Console.ReadLine(), out int year) ? year : 0;
                    library.AddBook(new Book { Title = title, Genre = genre, PublicationYear = publicationYear });
                    break;
                //Det är case 2 och är för att Lägga till en Author. så som du ser library.AddAuthor Det säger sig själv.
                case 2:
                    Console.Write("Författarens namn: ");
                    var name = Console.ReadLine();
                    library.AddAuthor(new Author { Name = name });
                    break;
                //Det är case 3 och är för att Uppdatera book historia osv. så som du ser library.Uppdatebook Det säger sig själv.
                case 3:
                    Console.Write("Bokens ID att uppdatera: ");
                    if (int.TryParse(Console.ReadLine(), out int bookId))
                    {
                        Console.Write("Ny titel: ");
                        var newTitle = Console.ReadLine();
                        Console.Write("Ny genre: ");
                        var newGenre = Console.ReadLine();
                        Console.Write("Nytt publiceringsår: ");
                        int newPubYear = int.TryParse(Console.ReadLine(), out int newYear) ? newYear : 0;
                        library.UpdateBook(bookId, newTitle, newGenre, newPubYear);
                    }
                    break;
                //Det är case 4 och är för att Uppdatera Author. så som du ser library.UppdateAthor Det säger sig själv.
                case 4:
                    Console.Write("Författarens ID att uppdatera: ");
                    if (int.TryParse(Console.ReadLine(), out int authorId))
                    {
                        Console.Write("Nytt namn: ");
                        var newName = Console.ReadLine();
                        library.UpdateAuthor(authorId, newName);
                    }
                    break;
                case 5:
                    Console.Write("Bokens id [För att ta bort] ");
                    if (int.TryParse(Console.ReadLine(), out int bookToRemove))
                        library.RemoveBook(bookToRemove);
                    break;
                case 6:
                    Console.Write("Författarens id [Om du vill ta bort FörFattare] ");
                    if (int.TryParse(Console.ReadLine(), out int authorToRemove))
                        library.RemoveAuthor(authorToRemove);
                    break;
                    // Biblioteks lista som listar över alla LIST ALL samt en CW för vad som ska visas upp i consolen
                case 7:
                    library.ListAll();
                    break;
                    // Library.SaveData den säger sig själv den spara alla data från biblan. samt en CW för vad de ska visas upp i consol
                case 8:
                    library.SaveData();
                    Console.WriteLine("Sparad & Avsluta.");
                    return;
                default:
                    Console.WriteLine("välj ett alternativ.");
                    break;


            }
            {

                Console.WriteLine("Vänta om 15 sekunder återvänder du till val menyn på nytt!!");
                //Den koden Gör så att efter 15 sekunder kommer Texten Försvinna
                Thread.Sleep(15000);
                //-------------------

                // Console Clear gör så att de städar all text efter sig och gör så att det är rent i consolen.
                Console.Clear();
                //--------------
                Console.WriteLine("Nu är du Redo igen");
            }
        }
    }
}
