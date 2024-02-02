﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Predavac : Osoba
    {
        public string Iban { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

    }


}
