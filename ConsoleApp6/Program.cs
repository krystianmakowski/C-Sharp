using System;

namespace ConsoleApp6
{
    class TelAdres
    {
        AddressBook book;

        public TelAdres()
        {
            book = new AddressBook();
        }

        static void Main(string[] args)
        {
            string selection = "";
            TelAdres prompt = new TelAdres();

            //prompt.displayMenu();
            while (!selection.ToUpper().Equals("W"))
            {
                prompt.displayMenu();
                Console.WriteLine("Wybór: ");
                selection = Console.ReadLine();
                Console.Clear();
                prompt.menu(selection);
            }
        }

        void displayMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Main Menu");
            Console.WriteLine("=========");
            Console.WriteLine("A - Dodaj adres");
            Console.WriteLine("U - Usuń adres");
            Console.WriteLine("E - Edytuj adres");
            Console.WriteLine("L - Lista wszystkich adresów");
            Console.WriteLine("W - Wyjście");
        }

        void menu(string selection)
        {
            string name = "";
            string surname = "";
            int age = 0;
            string male = "";
            int postcode = 0;
            string city = "";
            string street = "";
            int housenumber = 0;
            int pesel = 0;

            switch (selection.ToUpper())
            {
                case "A":
                    try
                    {
                        Console.WriteLine("Podaj numer Pesel");
                        pesel = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj imię: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko: ");
                        surname = Console.ReadLine();
                        Console.WriteLine("Podaj wiek: ");
                        age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj płeć: ");
                        male = Console.ReadLine();
                        Console.WriteLine("Podaj miasto");
                        city = Console.ReadLine();
                        Console.WriteLine("Podaj kod pocztowy: ");
                        postcode = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj ulice: ");
                        street = Console.ReadLine();
                        Console.WriteLine("Podaj numer domu: ");
                        housenumber = int.Parse(Console.ReadLine());
                    


                        if (book.add(pesel, name, surname, age, male, postcode, city, street, housenumber))
                        {
                        Console.WriteLine("Adres zostały dodany pomyślnie!");
                        }
                        else
                        {
                        Console.WriteLine("Adres istnieje już na liście, dla numeru {0}.", pesel);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Błędne dane");
                    }
                    break;
                case "U":
                    try
                    {
                        Console.WriteLine("Podaj pesel osoby do usunięcia: ");
                        pesel = int.Parse(Console.ReadLine());
                        if (book.remove(pesel))
                        {
                            Console.WriteLine("Adres został usunięty pomyślnie");
                        }
                        else
                        {
                            Console.WriteLine("Adres dla numeru {0} nie został znaleziony.", pesel);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Błędne dane");
                    }
                    break;
                case "L":
                    if (book.isEmpty())
                    {
                        Console.WriteLine("Brak kontaktów.");
                    }
                    else
                    {
                        Console.WriteLine("Adresy:");
                        book.list((a) => Console.WriteLine("{0}. {1} {2} - {3} {4} {5} {6} {7} {8}", a.pesel, a.name, a.surname, a.age, a.male, a.street, a.housenumber, a.postcode, a.city));
                    }
                    break;
                case "E":
                    try
                    {
                        Console.WriteLine("Podaj numer pesel użytkownika do edycji: ");
                        pesel = int.Parse(Console.ReadLine());
                        Address addr = book.find(pesel);
                        if (addr == null)
                        {
                            Console.WriteLine("Adres dla numeru pesel {0} nie został znaleziony.", pesel); ;
                        }
                        else
                        {
                            Console.WriteLine("Podaj miasto");
                            addr.city = Console.ReadLine();
                            Console.WriteLine("Podaj kod pocztowy: ");
                            addr.postcode = int.Parse(Console.ReadLine());
                            Console.WriteLine("Podaj ulice: ");
                            addr.street = Console.ReadLine();
                            Console.WriteLine("Podaj numer domu: ");
                            addr.housenumber = int.Parse(Console.ReadLine());
                            Console.WriteLine("Adres dla numeru {0} został zaktualizowany", pesel);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Błędne dane");
                    }
                    break;
            }
        }
    }
}
