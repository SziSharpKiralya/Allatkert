using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Madar : Allat
    {
        private int repulesiMagassag;

        public Madar(string nev, int kor, int testsuly, int egeszseg, int repulesiMagassag) : base(nev, kor, testsuly, egeszseg)
        {
            RepulesiMagassag = repulesiMagassag;
        }

        public int RepulesiMagassag { get => repulesiMagassag; 
            set 
            {
                repulesiMagassag = Math.Clamp(value, 5, 500);
            }
        }

        public override void InformaciotAd()
        {
            Console.WriteLine($"[{Nev}] - [{Kor}] éves madár, [{Testsuly}] kg testsúllyal, maximális repülési magasság: [{RepulesiMagassag}] méter");
        }

        public override void Gondoz(int ido)
        {
            base.Gondoz(ido);
            RepulesiMagassag += 100;
        }
    }
}
