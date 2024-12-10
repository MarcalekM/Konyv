using Konyv;

List<Book> konyvek = new();

List<string> MagyarSzerzok = new()
{
    "Petőfi Sándor",
    "Arany János",
    "Móricz Zsigmond",
    "Jókai Mór",
    "Ady Endre",
    "Babits Mihály",
    "Kosztolányi Dezső",
    "Tóth Árpád",
    "Illyés Gyula",
    "Szabó Lőrinc",
    "Karinthy Frigyes",
    "Márai Sándor",
    "Weöres Sándor",
    "Pilinszky János",
    "Németh László",
    "Kassák Lajos",
    "Gárdonyi Géza",
    "Tamási Áron",
    "Krúdy Gyula",
    "Csáth Géza"
};
List<string> MagyarKonyvek = new()
{
            "Egri csillagok",
            "A Pál utcai fiúk",
            "Légy jó mindhalálig",
            "Az arany ember",
            "Tüskevár",
            "Kőszívű ember fiai",
            "Ábel a rengetegben",
            "Egy magyar nábob",
            "A kőszívű ember fiai",
            "Ida regénye",
            "Eszter hagyatéka",
            "Iskola a határon",
            "Utazás a koponyám körül",
            "Emberszag",
            "Szindbád ifjúsága",
            "Két félidő a pokolban",
            "Az ötödik pecsét",
            "Pacsirta",
            "Csodálatos mandarin",
            "Az édes Anna"
};
List<string> AngolSzerzok = new()
{
            "Jane Austen",
            "Harper Lee",
            "George Orwell",
            "F. Scott Fitzgerald",
            "Herman Melville",
            "Charlotte Brontë",
            "J.D. Salinger",
            "Emily Brontë",
            "J.R.R. Tolkien",
            "Aldous Huxley",
            "John Steinbeck",
            "Oscar Wilde",
            "Mary Shelley",
            "Bram Stoker",
            "Arthur Conan Doyle",
            "Louisa May Alcott",
            "J.K. Rowling",
            "Mark Twain",
            "Charles Dickens",
            "Virginia Woolf"
};
List<string> AngolKonyvek = new()
{
            "Pride and Prejudice",
            "To Kill a Mockingbird",
            "1984",
            "The Great Gatsby",
            "Moby Dick",
            "Jane Eyre",
            "The Catcher in the Rye",
            "Wuthering Heights",
            "The Lord of the Rings",
            "Animal Farm",
            "Of Mice and Men",
            "The Picture of Dorian Gray",
            "Brave New World",
            "The Hobbit",
            "Frankenstein",
            "Dracula",
            "Sense and Sensibility",
            "The Adventures of Sherlock Holmes",
            "Little Women",
            "Harry Potter and the Philosopher's Stone"
};

for (int i = 0; i < 15; i++)
{
    string isbn = Random.Shared.NextInt64(1000000000, 10000000000).ToString();
    //while(konyvek.Any(k => k.ISBN.Equals(isbn))) isbn = Random.Shared.NextInt64(1000000000, 10000000000).ToString();

    int keszleten = Random.Shared.Next(5, 11);
    if (Random.Shared.Next(0, 10) < 3) keszleten = 0;

    int ev = Random.Shared.Next(2007, DateTime.Now.Year + 1);

    int ar = Random.Shared.Next(1000, 10001);
    while(ar % 100 != 0) ar = Random.Shared.Next(1000, 10001);

    string nyelv = "magyar";
    if (Random.Shared.Next(0, 10) < 2) nyelv = "angol";

    List<string> szerzok = new();
    string cim = string.Empty;
    if (nyelv.Equals("magyar"))
    {
        if (Random.Shared.Next(0, 10) < 7)
        {
            szerzok.Add(MagyarSzerzok[Random.Shared.Next(0, MagyarSzerzok.Count)]);
        } 
        else
        {
            for (int x = 0; x < Random.Shared.Next(2, 4); x++) szerzok.Append(MagyarSzerzok[Random.Shared.Next(0, MagyarSzerzok.Count)]);
        }

        cim = MagyarKonyvek[Random.Shared.Next(0, MagyarKonyvek.Count)];
    }
    else
    {
        if (Random.Shared.Next(0, 10) < 7)
        { 
            szerzok.Add(AngolSzerzok[Random.Shared.Next(0, AngolSzerzok.Count)]);
        }
        else
        {
            for (int x = 0; x < Random.Shared.Next(2, 4); x++) szerzok.Append(AngolSzerzok[Random.Shared.Next(0, MagyarSzerzok.Count)]);
        }

        cim = AngolKonyvek[Random.Shared.Next(0, AngolKonyvek.Count)];
    }

    konyvek.Add(new(isbn, cim, ev, nyelv, keszleten, ar, szerzok));
}

int bevetel = 0;
int keszlet = konyvek.Sum(k => k.Keszlet);
int kifogyott = 0;

for (int i = 0; i < 100; i++)
{
    var konyv = konyvek[Random.Shared.Next(0, konyvek.Count)];
    if (konyv.Keszlet != 0)
    {
        konyv.Keszlet--;
        bevetel += konyv.Ar;
    }
    else
    {
        if (Random.Shared.Next(0, 2) == 0)
        {
            konyv.Keszlet += Random.Shared.Next(1, 10);
        }
        else
        {
            konyvek.Remove(konyv);
            kifogyott++;
        }
    }
}

Console.WriteLine($"Az eladásokból származó bevétel: {bevetel}");
Console.WriteLine($"A készletünkből {keszlet - konyvek.Sum(k => k.Keszlet)} darab köny fogyott");
Console.WriteLine($"A nagykerből elfogyott címek száma: {kifogyott}");
