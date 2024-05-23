using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Nyaralas
    {
        public int id;
        public string nev;
        public string hotel;
        public int emberek;
        public int napok;
        public int ar;
        public string kedvezmeny;

        public Nyaralas(string id, string nev, string hotel, string emberek, string napok, string ar, string kedvezmeny)
        {
            this.id = int.Parse(id);
            this.nev = nev;
            this.hotel = hotel;
            this.emberek = int.Parse(emberek);
            this.napok = int.Parse(napok);
            this.ar = int.Parse(ar);
            this.kedvezmeny = kedvezmeny;
        }

    }
}
