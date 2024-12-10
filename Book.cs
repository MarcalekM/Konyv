using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyv
{
    internal class Book
    {
        public List<Author> Szerzők = new();
        private string cim;
        private int keszlet;
        private string nyelv;
        private string isbn;
        private int ar;
        private int kiadasEve;

        public string ISBN
        {
            get => isbn;
            set
            {
                if (value == null) throw new Exception("Nem adott meg értéket");
                if(value.Length != 10) throw new Exception("Az ISBN-nek 10 karakter hosszúnak kell lennie");
                isbn = value;
            }
        }
        public string Cim
        {
            get => cim;
            set
            {
                if (value.Length < 3 || value.Length > 64) throw new Exception("A cím nem lehet rövidebb 3 karakternél és hosszabb sem mint 64 karakter");
                cim = value;
            }
        }
        public int KiadasEve
        {
            get => kiadasEve;
            set
            {
                if (!(value >= 2007 && value <= DateTime.Now.Year)) throw new Exception("A legkorábbi könyv 2007-es lehet");
                kiadasEve = value;
            }
        }
        public string Nyelv
        {
            get => nyelv;
            set
            {
                if (!(value == "magyar" || value == "angol" || value == "német")) throw new Exception($"A nyelv csak magyar, angol vagy német lehet. Ön {value}-t akart megadni");
                nyelv = value;
            }
        }
        public int Keszlet
        {
            get => keszlet;
            set
            {
                if (value < 0) throw new Exception("A készlet értéke nem lehet kisebb szám mint nulla");
                keszlet = value;
            }
        }
        public int Ar
        {
            get => ar;
            set
            {
                if(value < 1000 || value > 10000) throw new Exception("Az ár értéke nem lehet kisebb 1000-nél és nagyobb sem lehet 10000-nél");
                if(value % 100 != 0) throw new Exception("Az ár értékének 100-ra kereknek kell lenne");
                ar = value;
            }
        }

        public Book(string isbn, string cim, int kiadasEve, string nyelv, int keszlet, int ar, List<string> szerzok)
        {
            ISBN = isbn;
            Cim = cim;
            KiadasEve = kiadasEve;
            Nyelv = nyelv;
            Keszlet = keszlet;
            Ar = ar;
            foreach (string s in szerzok) Szerzők.Add(new Author(s));
        }

        public Book(string cim, List<string> szerzok) : this(Random.Shared.NextInt64(1000000000, 10000000000).ToString(), cim, 2024, "magyar", 0, 4500, szerzok)
        {
            
        }

        public override string ToString()
        {
            string adatok = $"ISBN: {ISBN}\nCim: {Cim}\n" +
            $"Nyelv: {Nyelv}\n" +
            $"Készlet: {(Keszlet != 0 ? Keszlet : "Beszerzés alatt")}\n" +
            $"Ár: {Ar}\n" +
            $"{(Szerzők.Count() > 1 ? "Szerzők:\n" : "Szerző: ")}";
            foreach (var sz in Szerzők) adatok += $"{sz.Keresztnév} {sz.Vezetéknév}\n";
            return adatok;
        }
    }
}
