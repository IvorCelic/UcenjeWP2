using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E18Ekstenzije
{
    // CIJELA KLASA STATIČNA, ekstenzije se moraju kačiti na bilo što drugo
    internal static class Ekstenzije
    {
        public static void OdradiPosao(this ISucelje sucelje)
        {
            sucelje.Posao();
        }
    }
}
