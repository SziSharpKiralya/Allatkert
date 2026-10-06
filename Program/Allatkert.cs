using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Allatkert
    {
        List<Allat> allatokk = new List<Allat>();

        public void AllatFelvetele(Allat allat)
        {
            allatokk.Add(allat);
            Console.WriteLine("Az állat megérkezett az állatkertbe");
        }

        public void InformaciokListazasa()
        {
            foreach (Allat allat in allatokk)
            {
                allat.InformaciotAd();
            }
        }

        public void CsoportosGondozas(int ido)
        {
            foreach (Allat allat in allatokk)
            {
                if (allat.GondozasSzukseges)
                {
                    allat.Gondoz(ido);
                }
                else
                {
                    Console.WriteLine($"A [{allat.Nev}] gondozása jelenleg nem szükséges.");
                }
            }
        }
    }
}
