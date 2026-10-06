using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Program
{
    public class Ragadozo : Allat
    {
        private int taplalekMennyiseg;

        public Ragadozo(string nev, int kor, int testsuly, int egeszseg, int taplalekMennyiseg) : base(nev, kor, testsuly, egeszseg)
        {
            TaplalekMennyiseg = taplalekMennyiseg;
        }

        public int TaplalekMennyiseg { get => taplalekMennyiseg; 
            set 
            {
                taplalekMennyiseg = Math.Clamp(value, 0, 10);
            }
        }

        public override void InformaciotAd()
        {
            Console.WriteLine($"[{Nev}] - [{Kor}] éves ragadozó, [{Testsuly}] kg testsúllyal, táplálék: [{TaplalekMennyiseg}] kg");
        }

        public override void Gondoz(int ido)
        {
            TaplalekMennyiseg -= 5;
            base.Gondoz(ido);
        }
    }
}
