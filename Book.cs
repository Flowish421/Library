using Newtonsoft.Json;

public class Book
{
    // En public int för book id för varje gång du skapar en book så får den en unik id alltså book 1 id 1.
    public int Id { get; set; }
    // public string för Book Titel som gör så att man lägge till en Title.
    public string Title { get; set; }
    // en till string för genre så att man väljer vad för genre en book har.
    public string Genre { get; set; }
    // och en Public int flr publiserings år för booken när den kom ut osv.
    public int PublicationYear { get; set; }
}
