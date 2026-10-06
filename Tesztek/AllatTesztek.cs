using NUnit.Framework;
using System;
using Program;

namespace Tesztek
{
    public class AllatTesztek
    {
        // -----------------------------
        // Allat - alapadatok
        // -----------------------------

        [Test]
        public void Allat_NevHianyaban_NEVTELEN()
        {
            Allat allat = new Allat("", 10, 100, 80);

            Assert.That(allat.Nev, Is.EqualTo("NÉVTELEN"));
        }

        [Test]
        public void Allat_NegativKor_EgyenloNulla()
        {
            Allat allat = new Allat("Buksi", -5, 100, 80);

            Assert.That(allat.Kor, Is.EqualTo(0));
        }

        [Test]
        public void Allat_TulNagyKor_80Lesz()
        {
            Allat allat = new Allat("Buksi", 100, 100, 80);

            Assert.That(allat.Kor, Is.EqualTo(80));
        }

        [Test]
        public void Allat_NegativTestsuly_EgyenloNulla()
        {
            Allat allat = new Allat("Buksi", 10, -20, 80);

            Assert.That(allat.Testsuly, Is.EqualTo(0));
        }

        [Test]
        public void Allat_NegativEgeszseg_EgyenloNulla()
        {
            Allat allat = new Allat("Buksi", 10, 100, -10);

            Assert.That(allat.Egeszseg, Is.EqualTo(0));
        }

        [Test]
        public void Allat_TulNagyEgeszseg_100Lesz()
        {
            Allat allat = new Allat("Buksi", 10, 100, 150);

            Assert.That(allat.Egeszseg, Is.EqualTo(100));
        }


        // -----------------------------
        // GondozasSzukseges
        // -----------------------------

        [Test]
        public void Allat_50Szazaleknal_GondozasSzukseges()
        {
            Allat allat = new Allat("Buksi", 10, 100, 50);

            Assert.That(allat.GondozasSzukseges, Is.True);
        }

        [Test]
        public void Allat_51Szazaleknal_NemSzuksegesGondozas()
        {
            Allat allat = new Allat("Buksi", 10, 100, 51);

            Assert.That(allat.GondozasSzukseges, Is.False);
        }


        // -----------------------------
        // Allat - Gondoz
        // -----------------------------

        [Test]
        public void Allat_Gondozas_15TelNoveliAzEgeszseget()
        {
            Allat allat = new Allat("Buksi", 10, 100, 50);

            allat.Gondoz(20);

            Assert.That(allat.Egeszseg, Is.EqualTo(65));
        }

        [Test]
        public void Allat_Gondozas_30PercFelett_NoveliATestsulyt()
        {
            Allat allat = new Allat("Buksi", 10, 100, 50);

            allat.Gondoz(31);

            Assert.That(allat.Testsuly, Is.EqualTo(102));
        }

        [Test]
        public void Allat_Gondozas_30Percnel_NemNoveliATestsulyt()
        {
            Allat allat = new Allat("Buksi", 10, 100, 50);

            allat.Gondoz(30);

            Assert.That(allat.Testsuly, Is.EqualTo(100));
        }

        [Test]
        public void Allat_Gondozas_AlacsonyEgeszseg_ElerLegalabb50Szazalekot()
        {
            Allat allat = new Allat("Buksi", 10, 100, 20);

            allat.Gondoz(30);

            Assert.That(allat.Egeszseg, Is.EqualTo(50));
        }


        // -----------------------------
        // Madar
        // -----------------------------

        [Test]
        public void Madar_RepulesiMagassag_AlsoHatar()
        {
            Madar madar = new Madar("Csőrike", 5, 2, 80, 1);

            Assert.That(madar.RepulesiMagassag, Is.EqualTo(5));
        }

        [Test]
        public void Madar_RepulesiMagassag_FelsoHatar()
        {
            Madar madar = new Madar("Csőrike", 5, 2, 80, 600);

            Assert.That(madar.RepulesiMagassag, Is.EqualTo(500));
        }

        [Test]
        public void Madar_Gondozas_NoveliARepulesiMagassagot()
        {
            Madar madar = new Madar("Csőrike", 5, 2, 80, 200);

            madar.Gondoz(30);

            Assert.That(madar.RepulesiMagassag, Is.EqualTo(300));
        }

        [Test]
        public void Madar_Gondozas_MeghivjaAzOsosztalyMetodusat()
        {
            Madar madar = new Madar("Csőrike", 5, 2, 50, 200);

            madar.Gondoz(31);

            Assert.That(madar.Testsuly, Is.EqualTo(4));
            Assert.That(madar.Egeszseg, Is.EqualTo(65));
        }


        //// -----------------------------
        //// Ragadozo
        //// -----------------------------

        [Test]
        public void Ragadozo_TaplalekMennyiseg_AlsoHatar()
        {
            Ragadozo ragadozo = new Ragadozo("Oroszlán", 8, 150, 80, -5);

            Assert.That(ragadozo.TaplalekMennyiseg, Is.EqualTo(0));
        }

        [Test]
        public void Ragadozo_TaplalekMennyiseg_FelsoHatar()
        {
            Ragadozo ragadozo = new Ragadozo("Oroszlán", 8, 150, 80, 20);

            Assert.That(ragadozo.TaplalekMennyiseg, Is.EqualTo(10));
        }

        [Test]
        public void Ragadozo_Gondozas_CsokkentiATaplalekot()
        {
            Ragadozo ragadozo = new Ragadozo("Oroszlán", 8, 150, 50, 10);

            ragadozo.Gondoz(30);

            Assert.That(ragadozo.TaplalekMennyiseg, Is.EqualTo(5));
        }

        [Test]
        public void Ragadozo_Gondozas_TaplalekNemLehetNegativ()
        {
            Ragadozo ragadozo = new Ragadozo("Oroszlán", 8, 150, 50, 2);

            ragadozo.Gondoz(30);

            Assert.That(ragadozo.TaplalekMennyiseg, Is.EqualTo(0));
        }

        [Test]
        public void Ragadozo_Gondozas_MeghivjaAzOsosztalyMetodusat()
        {
            Ragadozo ragadozo = new Ragadozo("Oroszlán", 8, 150, 50, 10);

            ragadozo.Gondoz(31);

            Assert.That(ragadozo.Testsuly, Is.EqualTo(152));
            Assert.That(ragadozo.Egeszseg, Is.EqualTo(65));
            Assert.That(ragadozo.TaplalekMennyiseg, Is.EqualTo(5));
        }


        //// -----------------------------
        //// Polimorfizmus
        //// -----------------------------

        [Test]
        public void LeszarmazottAllat_JarmuSajatGondozasatHasznalja()
        {
            Allat allat = new Madar("Csőrike", 5, 2, 50, 200);

            allat.Gondoz(31);

            Assert.That(allat.Testsuly, Is.EqualTo(4));
            Assert.That(allat.Egeszseg, Is.EqualTo(65));
            Assert.That(((Madar)allat).RepulesiMagassag, Is.EqualTo(300));
        }


        //// -----------------------------
        //// Allatkert
        //// -----------------------------

        //[Test]
        //public void Allatkert_AllatFelvetele_NemDobHibat()
        //{
        //    Allatkert allatkert = new Allatkert();
        //    Allat allat = new Allat("Buksi", 5, 100, 80);

        //    Assert.DoesNotThrow(() => allatkert.AllatFelvetele(allat));
        //}

        //[Test]
        //public void Allatkert_InformaciokListazasa_NemDobHibat()
        //{
        //    Allatkert allatkert = new Allatkert();

        //    allatkert.AllatFelvetele(
        //        new Allat("Buksi", 5, 100, 80));

        //    allatkert.AllatFelvetele(
        //        new Madar("Csőrike", 3, 2, 70, 200));

        //    allatkert.AllatFelvetele(
        //        new Ragadozo("Oroszlán", 8, 150, 60, 10));

        //    Assert.DoesNotThrow(() => allatkert.InformaciokListazasa());
        //}

        //[Test]
        //public void Allatkert_CsoportosGondozas_CsakASzuksegesAllatokatGondozza()
        //{
        //    Allatkert allatkert = new Allatkert();

        //    Allat beteg = new Allat("Buksi", 5, 100, 50);
        //    Allat egeszseges = new Allat("Morzsi", 5, 100, 80);

        //    allatkert.AllatFelvetele(beteg);
        //    allatkert.AllatFelvetele(egeszseges);

        //    allatkert.CsoportosGondozas(31);

        //    Assert.That(beteg.Testsuly, Is.EqualTo(102));
        //    Assert.That(beteg.Egeszseg, Is.EqualTo(65));

        //    Assert.That(egeszseges.Testsuly, Is.EqualTo(100));
        //    Assert.That(egeszseges.Egeszseg, Is.EqualTo(80));
        //}

        //[Test]
        //public void Allatkert_CsoportosGondozas_LezarmazottSajatMetodusatHasznalja()
        //{
        //    Allatkert allatkert = new Allatkert();

        //    Madar madar = new Madar("Csőrike", 5, 2, 50, 200);

        //    allatkert.AllatFelvetele(madar);

        //    allatkert.CsoportosGondozas(31);

        //    Assert.That(madar.Testsuly, Is.EqualTo(4));
        //    Assert.That(madar.Egeszseg, Is.EqualTo(65));
        //    Assert.That(madar.RepulesiMagassag, Is.EqualTo(300));
        //}
    }
}
