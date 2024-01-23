﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt.Edunova
{
    // POCO  klasa - Plain Old C# Object
    internal class Smjer
    {
        public int Sifra { get; set; } 
        public string Naziv { get; set; } // Ovo se zove učahurivanje
        public int BrojSati { get; set; }
        public float Cijena { get; set; }
        public float Upisnina { get; set; }
        public bool Verificiran { get; set; }

    }
}
