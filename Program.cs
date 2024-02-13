using system_rezerwacji;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace system_rezerwacji
{
    public class ExceptionBrakLotow : Exception
    {
        public ExceptionBrakLotow(string message) : base(message)
        {
        }
    }

    public class ExceptionBrakOsoby : Exception
    {
        public ExceptionBrakOsoby(string message) : base(message)
        {
        }
    }

    public class ExceptionBrakFirmy : Exception
    {
        public ExceptionBrakFirmy(string message) : base(message)
        {
        }
    }

    public class ExceptionBrakTrasy : Exception
    {
        public ExceptionBrakTrasy(string message) : base(message)
        {
        }
    }

    public class ExceptionBrakSamolotu : Exception
    {
        public ExceptionBrakSamolotu(string message) : base(message)
        {
        }
    }
    public class ExceptionBrakKlienta : Exception
    {
        public ExceptionBrakKlienta(string message) : base(message)
        {
        }
    }
    public class ExceptionBrakLotniska : Exception
    {
        public ExceptionBrakLotniska(string message) : base(message)
        {
        }
    }
    public class ExceptionBrakRezerwacji : Exception
    {
        public ExceptionBrakRezerwacji(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class Firma
    {
        protected List<Klient> lista_klientow = new List<Klient>();
        protected List<Samolot> lista_samolotow = new List<Samolot>();
        protected List<Trasa> lista_tras = new List<Trasa>();
        protected List<Lotnisko> lista_lotnisk = new List<Lotnisko>();
        protected List<Lot> lista_lotow = new List<Lot>();
        protected List<Rezerwacja> lista_rezerwacji = new List<Rezerwacja>();

        public void Zapisz() //Zapisz stan systemu do plików lokalnych
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "/Dane";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            else
            {
                System.IO.DirectoryInfo dir = new DirectoryInfo(directoryPath);

                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }

            try
            {
                using (var stream = new FileStream(Path.Combine(directoryPath, "klienci.txt"), FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, lista_klientow);
                }
                using (var stream = new FileStream(Path.Combine(directoryPath, "samoloty.txt"), FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, lista_samolotow);
                }
                using (var stream = new FileStream(Path.Combine(directoryPath, "trasy.txt"), FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, lista_tras);
                }
                using (var stream = new FileStream(Path.Combine(directoryPath, "lotniska.txt"), FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, lista_lotnisk);
                }
                using (var stream = new FileStream(Path.Combine(directoryPath, "loty.txt"), FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, lista_lotow);
                }
                using (var stream = new FileStream(Path.Combine(directoryPath, "rezerwacje.txt"), FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, lista_rezerwacji);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void Wczytaj() //Odczytaj stan systemu z plików lokalnych
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "/Dane";

            if (File.Exists(Path.Combine(directoryPath, "klienci.txt")))
            {
                try
                {
                    using (var stream = new FileStream(Path.Combine(directoryPath, "klienci.txt"), FileMode.Open, FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        lista_klientow = (List<system_rezerwacji.Klient>)
                            formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (File.Exists(Path.Combine(directoryPath, "samoloty.txt")))
            {
                try
                {
                    using (var stream = new FileStream(Path.Combine(directoryPath, "samoloty.txt"), FileMode.Open, FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        lista_samolotow = (List<system_rezerwacji.Samolot>)
                            formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (File.Exists(Path.Combine(directoryPath, "trasy.txt")))
            {
                try
                {
                    using (var stream = new FileStream(Path.Combine(directoryPath, "trasy.txt"), FileMode.Open, FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        lista_tras = (List<system_rezerwacji.Trasa>)
                            formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (File.Exists(Path.Combine(directoryPath, "lotniska.txt")))
            {
                try
                {
                    using (var stream = new FileStream(Path.Combine(directoryPath, "lotniska.txt"), FileMode.Open, FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        lista_lotnisk = (List<system_rezerwacji.Lotnisko>)
                            formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (File.Exists(Path.Combine(directoryPath, "loty.txt")))
            {
                try
                {
                    using (var stream = new FileStream(Path.Combine(directoryPath, "loty.txt"), FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        lista_lotow = (List<system_rezerwacji.Lot>)
                            formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (File.Exists(Path.Combine(directoryPath, "rezerwacje.txt")))
            {
                try
                {
                    using (var stream = new FileStream(Path.Combine(directoryPath, "rezerwacje.txt"), FileMode.Open, FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        lista_rezerwacji = (List<system_rezerwacji.Rezerwacja>)
                            formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void dodajKlienta(Klient x) //Dodaj obiekt klasy Klient do listy klientów
        {
            lista_klientow.Add(x);
        }

        public void usunKlienta(int index) //Usuń klienta z listy. Dostęp poprzez index w liście klientów
        {
            if (lista_klientow.Count() >= index + 1)
            {
                Klient x = lista_klientow[index];
                lista_klientow.Remove(x);
            }
            else
            {
                throw new ExceptionBrakKlienta("Nie znaleziono takiego klienta");
            }
        }

        public string getKlienci() //Zwróć listę klientów w postaci string
        {
            string kliencis = "";
            int licznik = 0;
            foreach (Klient k in lista_klientow)
            {
                licznik += 1;
                kliencis += licznik.ToString() + ". ";
                kliencis += k.ToString();
                kliencis += "\n";
            }

            return kliencis;
        }

        public int getKlienci(int x) //Zwróć liczbę elementów w liście klientów
        {
            return lista_klientow.Count;
        }

        public Osoba getOsoba(string nr_pasz) //Zwróć obiekt klasy Osoba. Dostęp poprzez numer paszportu osoby
        {
            foreach (var klient in lista_klientow)
            {
                if (klient.GetType() == typeof(Osoba) && ((Osoba)klient).getNr_Pasz().ToString() == nr_pasz)
                {
                    return (Osoba)klient;
                }
            }
            throw new ExceptionBrakOsoby("Nie znaleziono takiej osoby");

        }

        public Pośrednik getFirma(string nr_KRS) //Zwróć obiekt klasy Pośrednik. Dostęp poprzez numer KRS pośrednika

        {
            foreach (var klient in lista_klientow)
            {
                if (klient is Pośrednik && ((Pośrednik)klient).GetKRS().ToString() == nr_KRS)
                {
                    return (Pośrednik)klient;
                }
            }
            throw new ExceptionBrakFirmy("Nie znaleziono takiej firmy");

        }

        public void dodajSamolot(Samolot x) //Dodaj obiekt klasy Samolot do listy samolotów
        {
            lista_samolotow.Add(x);
        }

        public void usunSamolot(int index) //Usuń samolot z listy. Dostęp poprzez index w liście samolotów
        {
            if (lista_samolotow.Count() >= index + 1)
            {
                Samolot x = lista_samolotow[index];
                lista_samolotow.Remove(x);
            }
            else
            {
                throw new ExceptionBrakSamolotu("Nie znaleziono takiego samolotu");
            }
        }

        public string getSamoloty() //Zwróć listę samolotów w postaci string
        {
            string samolotys = "";
            int licznik = 0;
            foreach (Samolot s in lista_samolotow)
            {
                licznik += 1;
                samolotys += licznik.ToString() + ". ";
                samolotys += s.ToString();
                samolotys += "\n";
            }

            return samolotys;
        }

        public int getSamoloty(int x) //Zwróć liczbę elementów w liście samolotów
        {
            return lista_samolotow.Count;
        }

        public void dodajTrase(int l1, int l2, double odleglosc) //Stwórz i dodaj obiekt klasy Trasa do listy tras. Wymaganie podanie lotniska początkowego oraz końcowego (za pomocą indeksów) i odległości
        {
            Trasa x = new Trasa(lista_lotnisk[l1], lista_lotnisk[l2], odleglosc);

            lista_tras.Add(x);
        }

        public void usunTrase(int index) //Usuń trasę z listy. Dostęp poprzez index w liście tras
        {
            if (lista_tras.Count() >= index + 1)
            {
                Trasa x = lista_tras[index];
                lista_tras.Remove(x);
            }
            else
            {
                throw new ExceptionBrakTrasy("Nie znaleziono takiej trasy");
            }
        }

        public string getTrasy() //Zwróć listę tras w postaci string
        {
            string trasys = "";
            int licznik = 0;
            foreach (Trasa t in lista_tras)
            {
                licznik += 1;
                trasys += licznik.ToString() + ". ";
                trasys += t.ToString();
                trasys += "\n";
            }

            return trasys;
        }

        public int getTrasy(int x) //Zwróć liczbę elementów w liście tras
        {
            return lista_tras.Count;
        }

        public Trasa getTrasa(int y) //Zwróć konkretny obiekt klasy Trasa. Dostęp poprzez index w liście tras
        {
            if (lista_tras.Count() >= y + 1)
            {
                Trasa trasa = lista_tras[y];
                return trasa;
            }
            else
            {
                throw new ExceptionBrakTrasy("Nie znaleziono takiej trasy");
            }
        }

        public string getAktywneTrasy() //Zwróć w postaci string listę tras zaznaczając trasy, na których aktualnie odbywają się loty
        {
            List<Trasa> lista_aktywnych_tras = new List<Trasa>();

            foreach (Lot l in lista_lotow)
            {
                if (!lista_aktywnych_tras.Contains(l.getTrasa()))
                {
                    lista_aktywnych_tras.Add(l.getTrasa());
                }
            }

            string trasys = "";
            int licznik = 0;
            foreach (Trasa t in lista_tras)
            {
                licznik += 1;
                trasys += licznik.ToString() + ". ";
                trasys += t.ToString();
                foreach(Trasa tt in lista_aktywnych_tras)
                {
                    if (tt.ToString() == t.ToString())
                    {
                        trasys += "        ---->     [Dostępne Loty!]";
                    }
                }

                trasys += "\n";
            }

            return trasys;
        }

        public void dodajLotnisko(Lotnisko x) //Dodaj obiekt klasy Lotnisko do listy lotnisk
        {
            lista_lotnisk.Add(x);
        }

        public void usunLotnisko(int index) //Usuń lotnisko z listy. Dostęp poprzez index w liście lotnisk
        {
            if (lista_lotnisk.Count() >= index + 1)
            {
                Lotnisko x = lista_lotnisk[index];
                lista_lotnisk.Remove(x);
            }
            else
            {
                throw new ExceptionBrakLotniska("Nie znaleziono takiego lotniska");
            }
        }

        public string getLotniska() //Zwróć listę lotnisk w postaci string
        {
            string lotniskas = "";
            int licznik = 0;
            foreach (Lotnisko l in lista_lotnisk)
            {
                licznik += 1;
                lotniskas += licznik.ToString() + ". ";
                lotniskas += l.ToString();
                lotniskas += "\n";
            }

            return lotniskas;
        }

        public int getLotniska(int x) //Zwróć liczbę elementów w liście lotnisk
        {
            return lista_lotnisk.Count;
        }

        public void dodajLot(Lot x) //Dodaj obiekt klasy Lot do listy lotów
        {
            lista_lotow.Add(x);
        }

        public void usunLot(int index) //Usuń lot z listy. Dostęp poprzez index w liście lotów
        {
            Lot x = lista_lotow[index];
            lista_lotow.Remove(x);
        }

        public void UsunStareLoty(DateTime h) //Usuń z listy te loty, które są zaplanowane na termin wcześniejszy niż bieżący (Już się odbyły). Obecną datę należy przekazać w parametrze
        {
            List<Lot> lotyDoUsuniecia = new List<Lot>();
            foreach (Lot x in lista_lotow)
            {
                if (h > x.getTermin())
                {
                    lotyDoUsuniecia.Add(x);
                }
            }
            foreach (Lot x in lotyDoUsuniecia)
            {
                lista_lotow.Remove(x);
            }
        }

        public string getLoty() //Zwróć listę lotów w postaci string
        {
            string lotys = "";
            int licznik = 0;
            foreach (Lot l in lista_lotow)
            {
                licznik += 1;
                lotys += licznik.ToString() + ". ";
                lotys += l.ToString();
                lotys += "\n";
            }

            return lotys;
        }

        public string GetLoty(Trasa t) //Zwróć w postaci string listę lotów na trasie podanej w parametrze jako obiekt klasy Trasa
        {
            string lotys = "";
            int licznik = 0;
            bool Rowne;
            Trasa h;
            foreach (Lot l in lista_lotow)
            {
                h = l.getTrasa();
                Rowne = Equals(h.ToString(), t.ToString());
                if (Rowne)
                {
                    licznik += 1;
                    lotys += licznik.ToString() + ". ";
                    lotys += l.ToString();
                    lotys += "\n";
                }
            }

            if (licznik == 0)
            {
                throw new ExceptionBrakLotow("Brak lotów na tej trasie");
            }

            return lotys;
        }

        public int getLotyIlosc() //Zwróć liczbę elementów w liście lotów
        {
            return lista_lotow.Count;
        }

        public Lot WybLot(int x, Trasa t) //Zwróć obiekt klasy Lot wybrany przez użytkownika indexem "x" z trasy "t"
        {
            int licznik = 0;

            foreach (Lot l in lista_lotow)
            {
                if ((l.getTrasa()).ToString() == t.ToString())
                {
                    licznik += 1;
                }
                if (licznik == x)
                {
                    return l;
                }
            }

            throw new ExceptionBrakLotow("Nie znaleziono wybranego lotu");
        }

        public Samolot WybSamolotu(double odleglosc) //Dobierz odpowiedni samolot do długości lotu. Długość lotu przekazywana w parametrze "odleglosc". Zwróć obiekt klasy Samolot
        {
            Samolot wybrany_samolot = null;
            double zapas = double.MaxValue;
            double zapaspom = 0;

            foreach (Samolot s in lista_samolotow)
            {
                zapaspom = (s.Zasieg() - odleglosc);
                if (zapaspom > 0 && zapaspom < zapas)
                {
                    wybrany_samolot = s;
                    zapas = zapaspom;
                }
            }
            if (zapas == double.MaxValue)
            {
                throw new Exception("Nie ma w bazie odpowiedniego samolotu");
            }

            return wybrany_samolot;
        }

        public void dodajRezerwacje(Rezerwacja x) //Dodaj obiekt klasy Rezerwacja do listy rezerwacji
        {
            lista_rezerwacji.Add(x);
        }

        public void usunRezerwacje(int index) //Usuń rezerwację z listy. Dostęp poprzez index w liście rezerwacji
        {
            Rezerwacja x = lista_rezerwacji[index];
            lista_rezerwacji.Remove(x);
        }

        public string getRezerwacje() //Zwróć listę rezerwacji w postaci string
        {
            string rezerwacjes = "";
            int licznik = 0;
            foreach (Rezerwacja r in lista_rezerwacji)
            {
                licznik += 1;
                rezerwacjes += licznik.ToString() + ". ";
                rezerwacjes += r.ToString();
                rezerwacjes += "\n";
            }

            return rezerwacjes;
        }

        public void UsunRezerwacjeZeZwrotem(int rezerwacja, Klient k) //Usuń rezerwację z listy (Dostęp poprzez index w liście rezerwacji) i zwolnij miejsca w locie. W drugim parametrze należy przekazać obiekt klasy Klient, do którego należy rezerwacja
        {
            List<Rezerwacja> rezerwacje_klienta = new List<Rezerwacja>();
            
            if (k.GetType() == typeof(Osoba))
            {
                foreach (Rezerwacja r in lista_rezerwacji)
                {
                    if (r.GetKlient().ToString() == k.ToString() && r.GetKlient().GetType() == typeof(Osoba))
                    {
                        rezerwacje_klienta.Add(r);
                    }
                }
            }
            else
            {
                foreach (Rezerwacja r in lista_rezerwacji)
                {
                    if (r.GetKlient().ToString() == k.ToString() && r.GetKlient().GetType() == typeof(Pośrednik))
                    {
                        rezerwacje_klienta.Add(r);
                    }
                }
            } 

            int licznik = 0;
            Rezerwacja do_usuniecia = null;

            foreach (Rezerwacja r in rezerwacje_klienta)
            {
                licznik += 1;
                if (licznik == rezerwacja)
                {
                    foreach(Rezerwacja i in lista_rezerwacji)
                    {
                        if(r.ToString() == i.ToString())
                        {
                            i.GetLot().Zwroc_miejsca(i.getMiejsca());
                            do_usuniecia = i;
                        }
                    }
                }
            }

            if(rezerwacje_klienta.Count() >= rezerwacja)
            {
                Console.WriteLine("Usunięto rezerwację nr: " + do_usuniecia.numer_rezerwacji);
                lista_rezerwacji.Remove(do_usuniecia);
            }
            else
            {
                throw new ExceptionBrakRezerwacji("\nNie znaleziono wybranej rezerwacji");
            }
        }

        public string getRezerwacje(Klient k) //Zwróć listę rezerwacji danego obiektu klasy Klient w postaci string
        {
            string rezerwacjes = "";
            int licznik = 0;
            Klient pom = null;
            if (k.GetType() == typeof(Osoba))
            {
                foreach (Rezerwacja r in lista_rezerwacji)
                {
                    pom = r.GetKlient();

                    if (pom.ToString() == k.ToString() && pom.GetType() == typeof(Osoba))
                    {
                        licznik += 1;
                        rezerwacjes += licznik.ToString() + ". ";
                        rezerwacjes += r.ToString();
                        rezerwacjes += "\n";
                    }
                }

                if (licznik == 0)
                {
                    throw new ExceptionBrakRezerwacji("Brak rezerwacji");
                }
                return rezerwacjes;
            }
            else
            {
                foreach (Rezerwacja r in lista_rezerwacji)
                {
                    pom = r.GetKlient();
                    if (pom.ToString() == k.ToString() && pom.GetType() == typeof(Pośrednik))
                    {
                        licznik += 1;
                        rezerwacjes += licznik.ToString() + ". ";
                        rezerwacjes += r.ToString();
                        rezerwacjes += "\n";
                    }
                }
                return rezerwacjes;
            }

        }

        public int getRezerwacje(int x) //Zwróć liczbę elementów w liście rezerwacji
        {
            return lista_rezerwacji.Count;
        }

        public List<Trasa> getTrasyzLotow() //Zwróć listę tras, na których aktualnie odbywają się loty
        {
            List<Trasa> lista_aktywnych_tras = new List<Trasa>();

            foreach (Lot l in lista_lotow)
            {
                if(!lista_aktywnych_tras.Contains(l.getTrasa()))
                {
                    lista_aktywnych_tras.Add(l.getTrasa());
                }
            }

            return lista_aktywnych_tras;
        }

        public string usunLotyZTrasy(Trasa t) //Usuń wszystkie zaplanowane loty na trasie "t" przekazanej w parametrze
        {
            List<Lot> lista_do_usuniecia = new List<Lot>();

            foreach(Lot l in lista_lotow)
            {
                if(l.getTrasa().ToString() == t.ToString())
                {
                    lista_do_usuniecia.Add(l);
                }
            }

            foreach(Lot l in lista_do_usuniecia)
            {
                lista_lotow.Remove(l);
            }

            return t.getNazwaTrasy();
        }

    }
    [Serializable]
    public abstract class Klient
    {
        private List<Rezerwacja> rezerwacje_klienta = new List<Rezerwacja>();

        public void Zarezerwuj_lot(Rezerwacja x, Firma firma) //Zapisz rezerwację "x" do listy rezerwacji w obiekcie "firma"
        {
            rezerwacje_klienta.Add(x);
            firma.dodajRezerwacje(x);
        }

        public abstract override string ToString();
    }
    [Serializable]
    public class Osoba : Klient
    {
        protected string imie;
        protected string nazwisko;
        protected string nr_paszportu;
        public Osoba(string imie, string nazwisko, string nr_paszportu)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.nr_paszportu = nr_paszportu;
        }

        public override string ToString() //Zwróć imię i nazwisko osoby w postaci string
        {
            return this.imie + " " + this.nazwisko;
        }
        public string getNr_Pasz() //Zwróć numer paszportu osoby w postaci string
        {
            return nr_paszportu;
        }
    }
    [Serializable]
    public class Pośrednik : Klient
    {
        protected string nazwa;
        protected string KRS;
        public Pośrednik(string nazwa, string KRS)
        {
            this.nazwa = nazwa;
            this.KRS = KRS;
        }

        public override string ToString() //Zwróć nazwę pośrednika w postaci string
        {
            return this.nazwa;
        }
        public string GetKRS() //Zwróć numer KRS pośrednika w postaci string
        {
            return this.KRS;
        }
    }
    [Serializable]
    public class Rezerwacja
    {
        public Lot lot;
        public string numer_rezerwacji;
        public int ile_miejsc_zarezerwowac;
        protected Klient klient;
        public Rezerwacja(Lot lot, Klient klient, string numer_rezerwacji, int ile_miejsc_zarezerwowac)
        {
            this.lot = lot;
            this.numer_rezerwacji = numer_rezerwacji;
            this.ile_miejsc_zarezerwowac = ile_miejsc_zarezerwowac;
            this.klient = klient;
        }
        public Klient GetKlient() //Zwróć obiekt klasy Klient, który jest przypisany do rezerwacji
        {
            return this.klient;
        }

        public override string ToString() //Zwróć informacje o rezerwacji w postaci string
        {
            return "Nr. " + this.numer_rezerwacji + ", Miejsca: " + this.ile_miejsc_zarezerwowac + ", Klient: " + this.klient.ToString() + ", Lot: " + this.lot.ToString();
        }
        public int getMiejsca() //Zwróć liczbę zarezerwowanych miejsc w postaci int
        {
            return this.ile_miejsc_zarezerwowac;
        }
        public Lot GetLot() //Zwróć obiekt klasy Lot, który jest przypisany do rezerwacji
        {
            return this.lot;
        }
    }
    [Serializable]
    public class Samolot
    {
        public string typ;
        protected string nr_seryjny;
        protected double zasięg;
        protected int liczba_miejsc;
        public Samolot(string typ, string nr_seryjny, double zasięg, int liczba_miejsc)
        {
            this.typ = typ;
            this.nr_seryjny = nr_seryjny;
            this.zasięg = zasięg;
            this.liczba_miejsc = liczba_miejsc;
        }
        public double Zasieg() //Zwróć zasięg samolotu w postaci double
        {
            return this.zasięg;
        }
        public int getMiejsca() //Zwróć liczbę miejsc znajdujących się w samolocie w postaci int
        {
            return this.liczba_miejsc;
        }
        public override string ToString() //Zwróć informacje o samolocie w postaci string
        {
            return this.typ + " Nr. Seryjny: " + this.nr_seryjny + " Zasięg: " + this.zasięg + " (km)";
        }
    }
    [Serializable]
    public class Lotnisko
    {
        private string nazwa;
        private string kod_lotniska;
        public Lotnisko(string nazwa, string kod_lotniska)
        {
            this.nazwa = nazwa;
            this.kod_lotniska = kod_lotniska;
        }

        public override string ToString() //Zwróć informacje o lotnisku w postaci string
        {
            return this.nazwa + " (" + this.kod_lotniska + ")";
        }
    }

    [Serializable]
    public class Trasa
    {
        protected Lotnisko lotnisko1;
        protected Lotnisko lotnisko2;
        protected double odleglosc;

        public Trasa(Lotnisko lotnisko1, Lotnisko lotnisko2, double odleglosc)
        {
            this.lotnisko1 = lotnisko1;
            this.lotnisko2 = lotnisko2;
            this.odleglosc = odleglosc;
        }

        public override string ToString() //Zwróć informacje o trasie w postaci string
        {
            return this.lotnisko1 + " - " + this.lotnisko2 + " (" + this.odleglosc + " km)";
        }
        public double getOdleglosc() //Zwróć długość lotu na tej trasie w postaci double
        {
            return this.odleglosc;
        }

        public string getNazwaTrasy() //Zwróć nazwę trasy w postaci string
        {
            return this.lotnisko1 + " - " + this.lotnisko2;
        }

    }
    [Serializable]
    public class Lot
    {
        protected Samolot samolot;
        protected DateTime termin;
        protected Trasa trasa;
        protected int wolne_miejsca;

        public Lot(Samolot samolot, DateTime termin, Trasa trasa, int wolne_miejsca)
        {
            this.samolot = samolot;
            this.termin = termin;
            this.trasa = trasa;
            this.wolne_miejsca = wolne_miejsca;
        }

        public override string ToString() //Zwróć informacje o locie w postaci string
        {
            return "Data: " + this.termin.ToString() + " na trasie " + this.trasa.ToString() + " obsługiwany przez " + this.samolot.typ;
        }

        public Trasa getTrasa() //Zwróć obiekt klasy Trasa, który jest przypisany do lotu
        {
            return this.trasa;
        }

        public int getWolne_miejsca() //Zwróć liczbę wolnych miejsc pozostałych w locie w postaci int
        {
            return this.wolne_miejsca;
        }

        public void Zmniejsz_miejsca(int x) //Zmniejsz liczbę wolnych miejsc w locie
        {
            this.wolne_miejsca -= x;
        }

        public void Zwroc_miejsca(int x) //Zwiększ liczbę wolnych miejsc w locie
        {
            this.wolne_miejsca += x;
        }

        public DateTime getTermin() //Zwróć obiekt DateTime reprezentujący termin odbycia się lotu
        {
            return this.termin;
        }
    }
    class Program
    {
        public static int wprowadzDaneInt() //Ta metoda umożliwia wczytywanie z klawiatury danych typu int jednocześnie sprawdzając poprawność wprowadzonych danych
        {
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());

                if(x < 1)
                {
                    Console.WriteLine("Użyto niepoprawnego formatu. Spróbuj ponownie:");
                    return wprowadzDaneInt();
                }

                return x;
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("Użyto niepoprawnego formatu. Spróbuj ponownie:");
                return wprowadzDaneInt();
            }
        }

        public static double wprowadzDaneDouble() //Ta metoda umożliwia wczytywanie z klawiatury danych typu double jednocześnie sprawdzając poprawność wprowadzonych danych
        {
            try
            {
                double x = Double.Parse(Console.ReadLine());

                if (x < 1)
                {
                    Console.WriteLine("Użyto niepoprawnego formatu. Spróbuj ponownie:");
                    return wprowadzDaneInt();
                }

                return x;
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("Użyto niepoprawnego formatu. Spróbuj ponownie:");
                return wprowadzDaneDouble();
            }
        }

        static void Main(string[] args)
        {
            Firma main_firma = new Firma();

            main_firma.Wczytaj();

            Console.WriteLine("Automatycznie odczytano dane z plików lokalnych");
            DateTime now = DateTime.Now;
            main_firma.UsunStareLoty(now);
            Thread.Sleep(700);

            while (true)
            {
                int option, option2, option3, option4, option5;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("|            Wybierz opcję:            |");
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("|  1.   Zarządzanie samolotami         |");
                    Console.WriteLine("|  2.   Zarządzanie klientami          |");
                    Console.WriteLine("|  3.   Zarządzanie lotniskami         |");
                    Console.WriteLine("|  4.   Zarządzanie trasami            |");
                    Console.WriteLine("|  5.   Zarządzanie lotami             |");
                    Console.WriteLine("|  6.   Generuj lot                    |");
                    Console.WriteLine("|  7.   Zarezerwuj bilet               |");
                    Console.WriteLine("|  8.   Panel Klienta                  |");
                    Console.WriteLine("|  9.   Zapisz stan na dysk            |");
                    Console.WriteLine("|  10.  Odczytaj stan z dysku          |");
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("\nDziałanie:");

                    option = wprowadzDaneInt();

                    switch (option)
                    {
                        case 1:
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("| Co chcesz zrobić z samolotem?      |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|  1. Dodaj samolot                  |");
                                Console.WriteLine("|  2. Usuń samolot                   |");
                                Console.WriteLine("|  3. Przegląd samolotów             |");
                                Console.WriteLine("|  4. Powrót                         |");
                                Console.WriteLine("+------------------------------------+");
                                option2 = wprowadzDaneInt();

                                if (option2 == 4)
                                {
                                    break;
                                }

                                switch (option2)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Podaj typ samolotu: ");
                                        string typ = Console.ReadLine();
                                        Console.WriteLine("\nPodaj nr_seryjny samolotu: ");
                                        string nr_seryjny = Console.ReadLine();
                                        Console.WriteLine("\nPodaj zasięg samolotu (km): ");
                                        double zasieg = wprowadzDaneDouble();
                                        Console.WriteLine("\nPodaj liczbę miejsc znajdujących się w samolocie: ");
                                        int liczba_miejsc = wprowadzDaneInt();

                                        Samolot samolot = new Samolot(typ, nr_seryjny, zasieg, liczba_miejsc);
                                        main_firma.dodajSamolot(samolot);
                                        break;
                                    case 2:
                                        Console.Clear();

                                        if (main_firma.getSamoloty(0) > 0)
                                        {
                                            Console.Write(main_firma.getSamoloty());
                                            Console.WriteLine("\nWybierz samolot do usunięcia: ");
                                            int index = wprowadzDaneInt();

                                            try
                                            {
                                                main_firma.usunSamolot(index - 1);
                                            }
                                            catch (ExceptionBrakSamolotu ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba samolotów");
                                            Thread.Sleep(1500);
                                        }

                                        break;
                                    case 3:
                                        Console.Clear();

                                        if (main_firma.getSamoloty(0) > 0)
                                        {
                                            Console.Write(main_firma.getSamoloty());
                                            Console.WriteLine("\nWcisnij dowolny przycisk żeby przejść dalej");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba samolotów");
                                            Thread.Sleep(1500);
                                        }

                                        break;
                                    default:
                                        Console.WriteLine("Wybrano niepoprawną formułę");
                                        Thread.Sleep(1500);
                                        break;
                                }
                            }
                            break;

                        case 2:
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("| Co chcesz zrobić z klientem?       |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|  1. Dodaj klienta                  |");
                                Console.WriteLine("|  2. Usuń klienta                   |");
                                Console.WriteLine("|  3. Przegląd klientów              |");
                                Console.WriteLine("|  4. Powrót                         |");
                                Console.WriteLine("+------------------------------------+");
                                option3 = wprowadzDaneInt();

                                if (option3 == 4)
                                {
                                    break;
                                }

                                switch (option3)
                                {
                                    case 1:
                                        Console.Clear();
                                        int wybor;

                                        Console.WriteLine("   Proszę wybrać odpowiedną pozycję:  ");
                                        Console.WriteLine("+------------------------------------+");
                                        Console.WriteLine("|  1. Osoba prywatna                 |");
                                        Console.WriteLine("|  2. Pośrednik                      |");
                                        Console.WriteLine("+------------------------------------+");
                                        Console.WriteLine("Wybór:");
                                        wybor = wprowadzDaneInt();

                                        switch (wybor)
                                        {
                                            case 1:
                                                Console.WriteLine("Podaj swoje imię: ");
                                                string imie = Console.ReadLine();
                                                Console.WriteLine("\nPodaj swoje nazwisko: ");
                                                string nazwisko = Console.ReadLine();
                                                Console.WriteLine("\nPodaj numer swojego paszportu: ");
                                                string nr_paszportu = Console.ReadLine();

                                                Osoba osoba = new Osoba(imie, nazwisko, nr_paszportu);
                                                main_firma.dodajKlienta(osoba);
                                                break;
                                            case 2:
                                                Console.WriteLine("Podaj nazwę swojej firmy: ");
                                                string nazwa = Console.ReadLine();
                                                Console.WriteLine("\nPodaj numer KRS: ");
                                                string KRS = Console.ReadLine();

                                                Pośrednik posrednik = new Pośrednik(nazwa, KRS);
                                                main_firma.dodajKlienta(posrednik);
                                                break;
                                            default:
                                                Console.WriteLine("Wybrano niepoprawną formułę");
                                                break;
                                        }

                                        break;
                                    case 2:
                                        Console.Clear();

                                        if (main_firma.getKlienci(0) > 0)
                                        {
                                            Console.Write(main_firma.getKlienci());
                                            Console.WriteLine("\nWybierz klienta do usunięcia: ");
                                            int index = wprowadzDaneInt();

                                            try
                                            {
                                                main_firma.usunKlienta(index - 1);
                                            }
                                            catch (ExceptionBrakKlienta ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba klientów");
                                            Thread.Sleep(1500);
                                        }
                                        break;
                                    case 3:
                                        Console.Clear();

                                        if (main_firma.getKlienci(0) > 0)
                                        {
                                            Console.Write(main_firma.getKlienci());
                                            Console.WriteLine("\nWcisnij dowolny przycisk żeby przejść dalej");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba klientów");
                                            Thread.Sleep(1500);
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Wybrano niepoprawną formułę");
                                        Thread.Sleep(1500);
                                        break;
                                }
                            }
                            break;
                        case 3:
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("| Co chcesz zrobić z lotniskami?     |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|  1. Dodaj lotnisko                 |");
                                Console.WriteLine("|  2. Usuń lotnisko                  |");
                                Console.WriteLine("|  3. Przegląd lotnisk               |");
                                Console.WriteLine("|  4. Powrót                         |");
                                Console.WriteLine("+------------------------------------+");
                                option5 = wprowadzDaneInt();

                                if (option5 == 4)
                                {
                                    break;
                                }

                                switch (option5)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Podaj nazwę lotniska: ");
                                        string nazwa = Console.ReadLine();
                                        Console.WriteLine("\nPodaj kod lotniska: ");
                                        string kod = Console.ReadLine();

                                        Lotnisko lotnisko = new Lotnisko(nazwa, kod);
                                        main_firma.dodajLotnisko(lotnisko);
                                        break;
                                    case 2:
                                        Console.Clear();

                                        if (main_firma.getLotniska(0) > 0)
                                        {
                                            Console.Write(main_firma.getLotniska());
                                            Console.WriteLine("\nWybierz lotnisko do usunięcia: ");
                                            int index = wprowadzDaneInt();

                                            try
                                            {
                                                main_firma.usunLotnisko(index - 1);
                                            }
                                            catch (ExceptionBrakLotniska ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba lotnisk");
                                            Thread.Sleep(1500);
                                        }
                                        break;
                                    case 3:
                                        Console.Clear();

                                        if (main_firma.getLotniska(0) > 0)
                                        {
                                            Console.Write(main_firma.getLotniska());
                                            Console.WriteLine("\nWcisnij dowolny przycisk żeby przejść dalej");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba lotnisk");
                                            Thread.Sleep(1500);
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Wybrano niepoprawną formułę");
                                        Thread.Sleep(1500);
                                        break;
                                }
                            }
                            break;
                        case 4:
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("| Co chcesz zrobić z trasami?        |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|  1. Dodaj trasę                    |");
                                Console.WriteLine("|  2. Usuń trasę                     |");
                                Console.WriteLine("|  3. Przegląd tras                  |");
                                Console.WriteLine("|  4. Powrót                         |");
                                Console.WriteLine("+------------------------------------+");
                                option4 = wprowadzDaneInt();

                                if (option4 == 4)
                                {
                                    break;
                                }

                                switch (option4)
                                {
                                    case 1:
                                        Console.Clear();

                                        if (main_firma.getLotniska(0) >= 2)
                                        {
                                            Console.Write(main_firma.getLotniska());
                                            Console.WriteLine("Wybierz lotniska spośród powyższych");

                                            Console.WriteLine("Lotnisko nr.1: ");
                                            int l1 = wprowadzDaneInt();
                                            Console.WriteLine("\nLotnisko nr.2: ");
                                            int l2 = wprowadzDaneInt();
                                            Console.WriteLine("\nPodaj dlugosc lotu (km): ");
                                            double odleglosc = wprowadzDaneDouble();

                                            main_firma.dodajTrase(l1 - 1, l2 - 1, odleglosc);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba lotnisk");
                                            Thread.Sleep(1500);
                                        }
                                        break;
                                    case 2:
                                        Console.Clear();

                                        if (main_firma.getTrasy(0) > 0)
                                        {
                                            Console.Write(main_firma.getTrasy());
                                            Console.WriteLine("\nWybierz trasę do usunięcia: ");
                                            int index = wprowadzDaneInt();

                                            try
                                            {
                                                main_firma.usunTrase(index - 1);
                                            }
                                            catch (ExceptionBrakTrasy ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba tras");
                                            Thread.Sleep(1500);
                                        }
                                        break;
                                    case 3:
                                        Console.Clear();
                                        if (main_firma.getTrasy(0) > 0)
                                        {
                                            Console.Write(main_firma.getTrasy());
                                            Console.WriteLine("\nWcisnij dowolny przycisk żeby przejść dalej");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Niewystarczająca liczba tras");
                                            Thread.Sleep(1500);
                                        }

                                        break;
                                    default:
                                        Console.WriteLine("Wybrano niepoprawną formułę");
                                        Thread.Sleep(1500);
                                        break;
                                }
                            }
                            break;
                        case 5:
                            Console.Clear();

                            if (main_firma.getLotyIlosc() <= 0)
                            {
                                Console.WriteLine("Brak lotów do wyświetlenia");
                                Thread.Sleep(1000);
                                break;
                            }

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("| Co chcesz zrobić z lotami?         |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|  1. Usuń loty                      |");
                                Console.WriteLine("|  2. Przegląd lotów                 |");
                                Console.WriteLine("|  3. Powrót                         |");
                                Console.WriteLine("+------------------------------------+");
                                option4 = wprowadzDaneInt();

                                if (option4 == 3)
                                {
                                    break;
                                }

                                switch(option4)
                                {
                                    case 1:
                                        Console.Clear();

                                        Console.WriteLine("+------------------------------------+");
                                        Console.WriteLine("|  1. Usuń pojedynczy lot            |");
                                        Console.WriteLine("|  2. Usuń wszystkie loty z trasy    |");
                                        Console.WriteLine("|  3. Powrót                         |");
                                        Console.WriteLine("+------------------------------------+");
                                        int option6 = wprowadzDaneInt();

                                        if (option6 == 3)
                                        {
                                            break;
                                        }

                                        switch(option6)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Lista lotów:");
                                                Console.Write(main_firma.getLoty());

                                                Console.WriteLine("\nWybierz lot do usunięcia:");
                                                int lot_do_usuniecia = wprowadzDaneInt();
                                                main_firma.usunLot(lot_do_usuniecia - 1);

                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("Lista tras na których aktualnie odbywają się loty:");
                                                List<Trasa> aktywne_loty = main_firma.getTrasyzLotow();

                                                int licz = 0;
                                                foreach(Trasa t in aktywne_loty)
                                                {
                                                    licz += 1;
                                                    Console.WriteLine(licz + ". " + t.ToString());
                                                }

                                                Console.WriteLine("\nWybierz trasę:");
                                                int wybor = wprowadzDaneInt();

                                                string trasa = main_firma.usunLotyZTrasy(aktywne_loty[wybor - 1]);

                                                Console.WriteLine("\nUsunięto wszystkie loty z trasy: " + trasa);
                                                Thread.Sleep(1500);

                                                break;
                                            default:
                                                break;
                                        }

                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Lista lotów:");
                                        Console.Write(main_firma.getLoty());

                                        Console.WriteLine("\nWciśnij dowolny przycisk, aby przejść dalej");
                                        Console.ReadKey();

                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case 6:
                            int x = 0;
                            Console.Clear();

                            if (main_firma.getSamoloty(x) == 0)
                            {
                                Console.WriteLine("Niewystarczająca liczba samolotów");
                                Thread.Sleep(1500);
                                break;
                            }
                            if (main_firma.getTrasy(x) == 0)
                            {
                                Console.WriteLine("Niewystarczająca liczba tras");
                                Thread.Sleep(1500);
                                break;
                            }

                            int wyb1;
                            Console.WriteLine("Lista tras:");
                            Console.WriteLine(main_firma.getTrasy());

                            Console.WriteLine("Wybierz trasę: ");
                            wyb1 = wprowadzDaneInt();
                            Trasa tralot;

                            try
                            {
                                tralot = main_firma.getTrasa(wyb1 - 1);
                            }
                            catch (ExceptionBrakTrasy ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                break;
                            }

                            Samolot SamolotLot = main_firma.WybSamolotu(tralot.getOdleglosc());

                            int rok, mies, dzien, godz, min;
                            DateTime dataAkt = DateTime.Now;
                            DateTime dataLotu;

                            Console.Clear();
                            Console.WriteLine("Kiedy ma się odbyć lot?");

                            Console.WriteLine("Rok: ");
                            rok = wprowadzDaneInt();

                            Console.WriteLine("Miesiąc: ");
                            mies = wprowadzDaneInt();

                            Console.WriteLine("Dzień: ");
                            dzien = wprowadzDaneInt();

                            Console.WriteLine("Godzina: ");
                            godz = wprowadzDaneInt();

                            Console.WriteLine("Minuta: ");
                            min = wprowadzDaneInt();

                            try
                            {
                                dataLotu = new DateTime(rok, mies, dzien, godz, min, 0);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine("Wprowadzono niepoprawną datę");
                                Thread.Sleep(1000);
                                break;
                            }

                            if (DateTime.Compare(dataLotu, dataAkt) > 0)
                            {
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Wprowadzono przeszłą datę");
                                Thread.Sleep(1000);
                                break;
                            }

                            int opt1 = 0, opt2 = 0, opt3 = 0;

                            bool keep_loop = true;

                            while(keep_loop)
                            {
                                Console.WriteLine("Czy powielić lot? (1 - Tak, 2 - Nie): ");
                                opt1 = wprowadzDaneInt();
                                Console.Clear();

                                switch (opt1)
                                {
                                    case 1:
                                        Console.WriteLine("Co ile dni ma sie powielać lot: ");
                                        opt2 = wprowadzDaneInt();

                                        Console.WriteLine("Ile razy chcesz powielić lot: ");
                                        opt3 = wprowadzDaneInt();
                                        keep_loop = false;

                                        break;
                                    case 2:
                                        keep_loop = false;

                                        break;
                                    default:
                                        Console.WriteLine("Wprowadzono nieprawidłowe dane");
                                        break;
                                }
                            }

                            Console.Clear();
                            int iloscmiejsc = SamolotLot.getMiejsca();

                            main_firma.dodajLot(new Lot(SamolotLot, dataLotu, tralot, iloscmiejsc));

                            for (int i = 0; i < opt3; i++)
                            {
                                dataLotu = dataLotu.AddDays(opt2);
                                main_firma.dodajLot(new Lot(SamolotLot, dataLotu, tralot, iloscmiejsc));
                            }

                            Console.WriteLine(main_firma.getLoty());
                            Console.WriteLine("\nWcisnij dowolny przycisk żeby przejść dalej");
                            Console.ReadKey();

                            break;
                        case 7:
                            Console.Clear();

                            if (main_firma.getLotyIlosc() < 1)
                            {
                                Console.WriteLine("Niewystarczająca liczba lotów");
                                Thread.Sleep(1500);
                                break;
                            }
                            else if (main_firma.getKlienci(0) < 1)
                            {
                                Console.WriteLine("Niewystarczająca liczba klientów");
                                Thread.Sleep(1500);
                                break;
                            }

                            Console.WriteLine("Lista tras: ");
                            Console.WriteLine(main_firma.getAktywneTrasy());

                            int opc1, opc2, opc3, opc4;
                            Console.WriteLine("Wybierz trasę: ");
                            opc1 = wprowadzDaneInt();

                            Trasa trasaRez;

                            Console.Clear();
                            try
                            {
                                trasaRez = main_firma.getTrasa((opc1 - 1));
                            }
                            catch (ExceptionBrakTrasy ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                break;
                            }

                            try
                            {
                                Console.WriteLine(main_firma.GetLoty(trasaRez));
                            }
                            catch (ExceptionBrakLotow ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1500);
                                break;
                            }

                            Console.WriteLine("Która z powyższych dat ci odpowiada?: ");

                            opc2 = wprowadzDaneInt();
                            Lot LotRez;

                            try
                            {
                                LotRez = main_firma.WybLot(opc2, trasaRez);
                            }
                            catch (ExceptionBrakLotow ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                break;
                            }

                            Console.Clear();
                            Console.WriteLine("+------------------------------------+");
                            Console.WriteLine("|    Jakim typem klienta jesteś?     |");
                            Console.WriteLine("+------------------------------------+");
                            Console.WriteLine("|  1. Klient Prywatny                |");
                            Console.WriteLine("|  2. Pośrednik                      |");
                            Console.WriteLine("+------------------------------------+");

                            opc3 = wprowadzDaneInt();
                            Klient klientRez;
                            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                            var random = new Random();
                            var randomString = new StringBuilder();

                            for (int i = 0; i < 15; i++)
                            {
                                int index = random.Next(chars.Length);
                                randomString.Append(chars[index]);
                            }

                            string numer_rez = randomString.ToString();

                            switch (opc3)
                            {
                                case 1:
                                    string nr_pasz;

                                    Console.Clear();
                                    Console.WriteLine("Podaj numer swojego paszportu: ");
                                    nr_pasz = Console.ReadLine();

                                    Console.Clear();
                                    try
                                    {
                                        klientRez = main_firma.getOsoba(nr_pasz);
                                    }
                                    catch (ExceptionBrakOsoby ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        Thread.Sleep(1000);
                                        break;
                                    }

                                    while (true)
                                    {
                                        Console.WriteLine("Liczba miejsc do zarezerwowania: ");
                                        opc4 = wprowadzDaneInt();

                                        if (opc4 <= LotRez.getWolne_miejsca())
                                        {
                                            LotRez.Zmniejsz_miejsca(opc4);
                                            main_firma.dodajRezerwacje(new Rezerwacja(LotRez, klientRez, numer_rez, opc4));
                                            Console.Clear();

                                            Console.WriteLine("Twój Numer Rezerwacji: " + numer_rez);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Brak wolnych miejsc");
                                            Thread.Sleep(1000);
                                            break;
                                        }
                                    }
                                    Console.WriteLine("Wcisnij dowolny przycisk żeby przejść dalej");
                                    Console.ReadKey();

                                    break;

                                case 2:
                                    string nr_krs;

                                    Console.Clear();
                                    Console.WriteLine("Podaj nr KRS: ");
                                    nr_krs = Console.ReadLine();

                                    Console.Clear();
                                    try
                                    {
                                        klientRez = main_firma.getFirma(nr_krs);
                                    }
                                    catch (ExceptionBrakFirmy ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        Thread.Sleep(1000);
                                        break;
                                    }

                                    while (true)
                                    {
                                        Console.WriteLine("Liczba miejsc do zarezerwowania: ");
                                        opc4 = wprowadzDaneInt();

                                        if (opc4 <= LotRez.getWolne_miejsca())
                                        {
                                            LotRez.Zmniejsz_miejsca(opc4);
                                            main_firma.dodajRezerwacje(new Rezerwacja(LotRez, klientRez, numer_rez, opc4));
                                            Console.Clear();

                                            Console.WriteLine("Twój Numer Rezerwacji: " + numer_rez);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Brak wolnych miejsc");
                                            Thread.Sleep(1000);
                                            break;
                                        }
                                    }
                                    Console.WriteLine("Wcisnij dowolny przycisk żeby przejść dalej");
                                    Console.ReadKey();

                                    break;
                                default:
                                    Console.WriteLine("Wybrano niepoprawną formułę");
                                    Thread.Sleep(1500);
                                    break;
                            }

                            break;
                        case 8:
                            bool ExitLoop = false;
                            Klient klientRezV2 = null;
                            int opcjaKlient = 0;

                            while (!ExitLoop)
                            {
                                Console.Clear();
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|    Jakim typem klienta jesteś?     |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|  1. Klient Prywatny                |");
                                Console.WriteLine("|  2. Pośrednik                      |");
                                Console.WriteLine("|  3. Powrót                         |");
                                Console.WriteLine("+------------------------------------+");
                                opcjaKlient = wprowadzDaneInt();

                                if(opcjaKlient == 3)
                                {
                                    ExitLoop = true;
                                    break;
                                }

                                switch (opcjaKlient)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Podaj numer swojego paszportu: ");
                                        string nr_pasz = Console.ReadLine();

                                        Console.Clear();
                                        try
                                        {
                                            klientRezV2 = main_firma.getOsoba(nr_pasz);
                                        }
                                        catch (ExceptionBrakOsoby ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1000);
                                            break;
                                        }
                                        ExitLoop = true;

                                        break;
                                    case 2:
                                        string nr_krs;

                                        Console.Clear();
                                        Console.WriteLine("Podaj nr KRS: ");
                                        nr_krs = Console.ReadLine();

                                        Console.Clear();
                                        try
                                        {
                                            klientRezV2 = main_firma.getFirma(nr_krs);
                                        }
                                        catch (ExceptionBrakFirmy ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1000);
                                            break;
                                        }

                                        ExitLoop = true;
                                        break;
                                    default:
                                        Console.WriteLine("Wybrano niepoprawną opcje");
                                        break;
                                }
                            }

                            int wyb = 0;
                            while (wyb != 4 && opcjaKlient != 3)
                            {
                                Console.Clear();
                                Console.WriteLine("Witaj " + klientRezV2.ToString() + "!\n");
                                Console.WriteLine("+-------------------------------------+");
                                Console.WriteLine("|            Panel Klienta            |");
                                Console.WriteLine("+-------------------------------------+");
                                Console.WriteLine("|  1. Sprawdż swoje rezerwacje        |");
                                Console.WriteLine("|  2. Zarezerwuj bilet                |");
                                Console.WriteLine("|  3. Usuń rezerwacje                 |");
                                Console.WriteLine("|  4. Powrót                          |");
                                Console.WriteLine("+-------------------------------------+");
                                wyb = wprowadzDaneInt();

                                switch (wyb)
                                {
                                    case 1:
                                        Console.Clear();

                                        if (main_firma.getRezerwacje(0) > 0)
                                        {
                                            try
                                            {
                                                Console.WriteLine(main_firma.getRezerwacje(klientRezV2));
                                            }
                                            catch (ExceptionBrakRezerwacji ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Brak rezerwacji do wyświelenia");
                                        }

                                        Console.WriteLine("\nWciśnij dowolny przycisk żeby przejść dalej");
                                        Console.ReadKey();

                                        break;
                                    case 2:
                                        Console.Clear();

                                        if (main_firma.getLotyIlosc() < 1)
                                        {
                                            Console.WriteLine("Niewystarczająca liczba lotów");
                                            Thread.Sleep(1500);

                                            break;
                                        }
                                        else if (main_firma.getKlienci(0) < 1)
                                        {
                                            Console.WriteLine("Niewystarczająca liczba klientów");
                                            Thread.Sleep(1500);

                                            break;
                                        }

                                        Console.Clear();
                                        Console.WriteLine("Lista tras: ");
                                        Console.WriteLine(main_firma.getAktywneTrasy());

                                        Console.WriteLine("Wybierz trasę: ");
                                        opc1 = wprowadzDaneInt();
                                        Trasa trasaRezKlient;

                                        Console.Clear();
                                        try
                                        {
                                            trasaRezKlient = main_firma.getTrasa((opc1 - 1));
                                        }
                                        catch (ExceptionBrakTrasy ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1000);
                                            break;
                                        }

                                        try
                                        {
                                            Console.WriteLine(main_firma.GetLoty(trasaRezKlient));
                                        }
                                        catch (ExceptionBrakLotow ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1500);
                                            break;
                                        }

                                        Console.WriteLine("Która z powyższych dat ci odpowiada?: ");

                                        opc2 = wprowadzDaneInt();
                                        Lot LotRezKlient;

                                        try
                                        {
                                            LotRezKlient = main_firma.WybLot(opc2, trasaRezKlient);
                                        }
                                        catch (ExceptionBrakLotow ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1000);
                                            break;
                                        }

                                        const string chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                                        var random1 = new Random();
                                        var randomString1 = new StringBuilder();

                                        for (int i = 0; i < 15; i++)
                                        {
                                            int index = random1.Next(chars1.Length);
                                            randomString1.Append(chars[index]);
                                        }
                                        Console.Clear();

                                        string numer_rez1 = randomString1.ToString();

                                        while (true)
                                        {
                                            Console.WriteLine("Liczba miejsc do zarezerwowania: ");
                                            opc4 = wprowadzDaneInt();

                                            if (opc4 <= LotRezKlient.getWolne_miejsca())
                                            {
                                                LotRezKlient.Zmniejsz_miejsca(opc4);
                                                main_firma.dodajRezerwacje(new Rezerwacja(LotRezKlient, klientRezV2, numer_rez1, opc4));

                                                Console.Clear();
                                                Console.WriteLine("Twój Numer Rezerwacji: " + numer_rez1);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Brak wolnych miejsc");
                                                break;
                                            }
                                        }

                                        Console.WriteLine("Wciśnij dowolny przycisk żeby przejść dalej");
                                        Console.ReadKey();

                                        break;
                                    case 3:
                                        Console.Clear();

                                        try
                                        {
                                            main_firma.getRezerwacje(klientRezV2);
                                        }
                                        catch (ExceptionBrakRezerwacji ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1000);
                                            break;
                                        }

                                        Console.WriteLine("\nTwoje rezerwacje:");
                                        Console.WriteLine(main_firma.getRezerwacje(klientRezV2));
                                        Console.WriteLine("Wybierz rezerwację do usunięcia:");
                                        option = wprowadzDaneInt();

                                        try
                                        {
                                            main_firma.UsunRezerwacjeZeZwrotem(option, klientRezV2);
                                        }
                                        catch (ExceptionBrakRezerwacji ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1000);
                                            break;
                                        }

                                        Console.WriteLine("Wcisnij przycisk żeby przejść dalej");
                                        Console.ReadKey();

                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;
                        case 9:
                            main_firma.Zapisz();

                            Console.WriteLine("Dane zostały zapisane");
                            Thread.Sleep(700);
                            break;
                        case 10:
                            main_firma.Wczytaj();

                            Console.WriteLine("Dane zostały odczytane");
                            now = DateTime.Now;
                            main_firma.UsunStareLoty(now);
                            Thread.Sleep(700);
                            break;
                        default:
                            Console.WriteLine("Wybrano niepoprawną formułę");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
        }
    }
}