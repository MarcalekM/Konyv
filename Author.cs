using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Konyv
{
    internal class Author
    {
        private string keresztnév;
        private string vezetéknév;

        public Guid Id { get; set; }
        public string Keresztnév
        {
            get => keresztnév;
            set
            {
                if(value == null) throw new Exception("Nem adott meg értéket");
                if (value.Length < 3 || value.Length > 32) throw new Exception("A keresztnév nem lehet rövidebb 3 karakternél és hosszabb sem 32 karakternél");
                keresztnév = value;
            }
        }
        public string Vezetéknév
        {
            get => vezetéknév;
            set
            {
                if(value == null) throw new Exception("Nem adott meg értéket");
                if (value.Length < 3 || value.Length > 32) throw new Exception("A vezetéknév nem lehet rövidebb 3 karakternél és hosszabb sem 32 karakternél");
                vezetéknév = value;
            }
        }

        public Author(string name)
        {
            var temp = name.Split(' ');
            Keresztnév = temp[0];   
            Vezetéknév  = temp[1];
            Id = Guid.NewGuid();
        }
        public override string ToString() => $"{Keresztnév} {Vezetéknév}: {Id}";
    }
}
