using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Program
{
    public class Allat
    {
        private string nev;
        private int kor;
        private int testsuly;
        private int egeszseg;
        private bool gondozasSzukseges;

        public Allat(string nev, int kor, int testsuly, int egeszseg)
        {
            Nev = nev;
            Kor = kor;
            Testsuly = testsuly;
            Egeszseg = egeszseg;
        }

        public string Nev { get => nev; 
            set {
                if (value == null || value == "")
                {
                    nev = "NÉVTELEN";
                }
                else
                {
                    nev = value;
                }
            } 
        }
        public int Kor { get => kor; 
            set
            {
                kor = Math.Clamp(value, 0, 80);
            } 
        }
        public int Testsuly { get => testsuly; 
            set
            {
                if (0 > value)
                {
                    testsuly = 0;
                }
                else
                {
                    testsuly = value;
                }
                
            }
        }
        public int Egeszseg { get => egeszseg; 
            set 
            {
                egeszseg = Math.Clamp(value, 0, 100);
                if (51 > egeszseg)
                {
                    gondozasSzukseges = true;
                }
            } 
        }
        public bool GondozasSzukseges { get => gondozasSzukseges; set => gondozasSzukseges = value; }

        public void InformaciotAd()
        {
            Console.WriteLine($"[{Nev}] - [{Kor}] éves állat, [{Testsuly}] kg súllyal");
        }

        public void Gondoz(int ido)
        {
            if (ido > 30)
            {
                testsuly += 2;
            }
            egeszseg += 15;
            if (50 > egeszseg)
            {
                egeszseg = 50;
            }
        }
    }
}
