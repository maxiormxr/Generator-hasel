using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1
{
    public class GeneratorHasla
    {
        Random losowaCyfraGenerator = new Random();
        private int _dlugoscHasla;
        private bool _polskieZnaki;
        private string[] _znakiDoGenerowaniaHasla = 
        {
            "A","a",
            "B","b",
            "C","c",
            "D","d",
            "E","e",
            "F","f",
            "G","g",
            "H","h",
            //"I",
            "i",
            "J","j",
            "K","k",
            "L",//"l",
            "M","m",
            "N","n",
            //"O",
            "o",
            "P","p",
            "Q","q",
            "R","r",
            "S","s",
            "T","t",
            "U","u",
            "V","v",
            "W","w",
            "X","x",
            "Y","y",
            "Z","z",
            "1","2","3","4","5","6","7","8","9",//"0", // od 0 do 61 index w tablicy (z zakomentowanymi index 57)
            "Ą","ą",
            "Ć","ć",
            "Ę","ę",
            "Ł","ł",
            "Ń","ń",
            "Ó","ó",
            "Ś","ś",
            "Ź","ź",
            "Ż","ż" // do 79 index w tablicy (z zakomentowanymi index 75)
        };

        private string[] _pierwszaGrupaZnakow = { "Q", "q", "W", "w", "E", "e", "A", "a", "S", "s", "D", "d", "Z", "z", "X", "x", "C", "c" };
        private string[] _drugaGrupaZnakow = { "1", "2", "3", "Q", "q", "W", "w", "E", "e", "A", "a", "S", "s", "D", "d" };
        private string[] _trzeciaGrupaZnakow = { "R", "r", "W", "w", "E", "e", "F", "f", "S", "s", "D", "d", "V", "v", "X", "x", "C", "c" };
        private string[] _czwartaGrupaZnakow = { "4", "2", "3", "R", "r", "W", "w", "E", "e", "F", "f", "S", "s", "D", "d" };
        private string[] _piataGrupaZnakow = { "R", "r", "T", "t", "E", "e", "F", "f", "G", "g", "D", "d", "V", "v", "B", "b", "C", "c" };
        private string[] _szostaGrupaZnakow = { "4", "5", "3", "R", "r", "T", "t", "E", "e", "F", "f", "G", "g", "D", "d" };
        private string[] _siodmaGrupaZnakow = { "R", "r", "T", "t", "Y", "y", "F", "f", "G", "g", "H", "h", "V", "v", "B", "b", "N", "n" };
        private string[] _osmaGrupaZnakow = { "4", "5", "6", "R", "r", "T", "t", "Y", "y", "F", "f", "G", "g", "H", "h" };
        private string[] _dziewiataGrupaZnakow = { "U", "u", "T", "t", "Y", "y", "J", "j", "G", "g", "H", "h", "M", "m", "B", "b", "N", "n" };
        private string[] _dziesiataGrupaZnakow = { "7", "5", "6", "U", "u", "T", "t", "Y", "y", "J", "j", "G", "g", "H", "h" };
        private string[] _jedenastaGrupaZnakow = { "U", "u", "i", "Y", "y", "J", "j", "K", "k", "H", "h", "M", "m", "B", "b", "N", "n" };
        private string[] _dwunastaGrupaZnakow = { "7", "8", "6", "U", "u", "i", "Y", "y", "J", "j", "K", "k", "H", "h" };
        private string[] _trzynastaGrupaZnakow = { "U", "u", "i", "o", "J", "j", "K", "k", "L", "M", "m", "N", "n" };
        private string[] _czternastaGrupaZnakow = { "7", "8", "9", "U", "u", "i", "o", "J", "j", "K", "k", "L"};
        //private string[] _pietnastaGrupaZnakow = { "P", "p", "i", "o", "J", "j", "K", "k", "L", "M", "m", "N", "n" };
        private string[] _pietnastaGrupaZnakow = { "P", "p", "i", "o", "K", "k", "L", "M", "m" };
        private string[] _szesnastaGrupaZnakow = { "8", "9", "P", "p", "i", "o", "K", "k", "L" };

        public GeneratorHasla(int dlugosc, bool polskieZnaki)
        {
            _dlugoscHasla = dlugosc;
            _polskieZnaki = polskieZnaki;
        }
        public string GenerujHaslo(bool haslaPrzyjazneUzytkownikowi)
        {
            int wylosowanaCyfra;
            string haslo = "";
            if (_polskieZnaki==false)
            {
                if (!haslaPrzyjazneUzytkownikowi)
                {
                    for (int i = 0; i < _dlugoscHasla; i++)
                    {
                        wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % 57;//mod 57 zeby uwzglednic zakomentowane znaki w tablicy
                        haslo += _znakiDoGenerowaniaHasla[wylosowanaCyfra];
                        string ostatniZnakHasla = haslo.Substring(haslo.Count() - 1);
                    }
                }
                else if (haslaPrzyjazneUzytkownikowi)
                {
                    wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % 57;//mod 57 zeby uwzglednic zakomentowane znaki w tablicy
                    haslo += _znakiDoGenerowaniaHasla[wylosowanaCyfra];
                    string ostatniZnakHasla = haslo.Substring(haslo.Count() - 1);

                    if (ostatniZnakHasla == "A" || ostatniZnakHasla == "a" || ostatniZnakHasla == "Z" || ostatniZnakHasla == "z" || ostatniZnakHasla == "Q" || ostatniZnakHasla == "q")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _pierwszaGrupaZnakow.Count();
                            haslo += _pierwszaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "1" || ostatniZnakHasla == "Q" || ostatniZnakHasla == "q" || ostatniZnakHasla == "A" || ostatniZnakHasla == "a")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _drugaGrupaZnakow.Count();
                            haslo += _drugaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "S" || ostatniZnakHasla == "s" || ostatniZnakHasla == "X" || ostatniZnakHasla == "x" || ostatniZnakHasla == "W" || ostatniZnakHasla == "w")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _trzeciaGrupaZnakow.Count();
                            haslo += _trzeciaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "2" || ostatniZnakHasla == "W" || ostatniZnakHasla == "w" || ostatniZnakHasla == "S" || ostatniZnakHasla == "s")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _czwartaGrupaZnakow.Count();
                            haslo += _czwartaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "D" || ostatniZnakHasla == "d" || ostatniZnakHasla == "C" || ostatniZnakHasla == "c" || ostatniZnakHasla == "E" || ostatniZnakHasla == "e")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _piataGrupaZnakow.Count();
                            haslo += _piataGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "3" || ostatniZnakHasla == "E" || ostatniZnakHasla == "e" || ostatniZnakHasla == "D" || ostatniZnakHasla == "d")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _szostaGrupaZnakow.Count();
                            haslo += _szostaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "F" || ostatniZnakHasla == "f" || ostatniZnakHasla == "R" || ostatniZnakHasla == "r" || ostatniZnakHasla == "V" || ostatniZnakHasla == "v")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _siodmaGrupaZnakow.Count();
                            haslo += _siodmaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "4" || ostatniZnakHasla == "R" || ostatniZnakHasla == "r" || ostatniZnakHasla == "F" || ostatniZnakHasla == "f")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _osmaGrupaZnakow.Count();
                            haslo += _osmaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "G" || ostatniZnakHasla == "g" || ostatniZnakHasla == "T" || ostatniZnakHasla == "t" || ostatniZnakHasla == "B" || ostatniZnakHasla == "b")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _dziewiataGrupaZnakow.Count();
                            haslo += _dziewiataGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "5" || ostatniZnakHasla == "T" || ostatniZnakHasla == "t" || ostatniZnakHasla == "G" || ostatniZnakHasla == "g")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _dziesiataGrupaZnakow.Count();
                            haslo += _dziesiataGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "H" || ostatniZnakHasla == "h" || ostatniZnakHasla == "Y" || ostatniZnakHasla == "y" || ostatniZnakHasla == "N" || ostatniZnakHasla == "n")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _jedenastaGrupaZnakow.Count();
                            haslo += _jedenastaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "6" || ostatniZnakHasla == "Y" || ostatniZnakHasla == "y" || ostatniZnakHasla == "H" || ostatniZnakHasla == "h")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _dwunastaGrupaZnakow.Count();
                            haslo += _dwunastaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "J" || ostatniZnakHasla == "j" || ostatniZnakHasla == "U" || ostatniZnakHasla == "u" || ostatniZnakHasla == "M" || ostatniZnakHasla == "m")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _trzynastaGrupaZnakow.Count();
                            haslo += _trzynastaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "7" || ostatniZnakHasla == "U" || ostatniZnakHasla == "u" || ostatniZnakHasla == "J" || ostatniZnakHasla == "j")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _czternastaGrupaZnakow.Count();
                            haslo += _czternastaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "K" || ostatniZnakHasla == "k" || ostatniZnakHasla == "i" || ostatniZnakHasla == "M" || ostatniZnakHasla == "m" || ostatniZnakHasla == "P" || ostatniZnakHasla == "p" || ostatniZnakHasla == "o" || ostatniZnakHasla == "L")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _pietnastaGrupaZnakow.Count();
                            haslo += _pietnastaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                    else if (ostatniZnakHasla == "8" || ostatniZnakHasla == "9" || ostatniZnakHasla == "P" || ostatniZnakHasla == "p" || ostatniZnakHasla == "i" || ostatniZnakHasla == "o" || ostatniZnakHasla == "K" || ostatniZnakHasla == "k" || ostatniZnakHasla == "L")
                    {
                        for (int i = 1; i < _dlugoscHasla; i++)
                        {
                            wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % _szesnastaGrupaZnakow.Count();
                            haslo += _szesnastaGrupaZnakow[wylosowanaCyfra];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < _dlugoscHasla; i++)
                {
                    wylosowanaCyfra = losowaCyfraGenerator.Next(0, 100000) % 75;//mod 75 zeby uwzglednic zakomentowane znaki w tablicy
                    haslo += _znakiDoGenerowaniaHasla[wylosowanaCyfra];
                }
            }
            return haslo;
        }
    }
}
