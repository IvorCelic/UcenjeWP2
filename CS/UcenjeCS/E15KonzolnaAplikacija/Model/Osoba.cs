﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal abstract class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Oib { get; set; }
        public string Email { get; set; }

    }
}