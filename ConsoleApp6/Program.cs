﻿using System;
using System.Text.RegularExpressions;

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
            string postcode = "";
            string city = "";
            string street = "";
            int housenumber = 0;
            string pesel ="";

            switch (selection.ToUpper())
            {
                case "A":

                    Console.WriteLine("Podaj numer Pesel");
                    pesel = Console.ReadLine();
                    while (pesel.Length != 11)
                    {
                        Console.WriteLine("Błędne dane. Pesel musi się składać z 11 cyfr");
                        Console.WriteLine("Spróbój jeszcze raz");
                        pesel = Console.ReadLine();
                    }
                    Console.WriteLine("Podaj imię: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko: ");
                    surname = Console.ReadLine();
                    Console.WriteLine("Podaj wiek: ");
                    while (!int.TryParse(Console.ReadLine(), out age))
                        Console.WriteLine("Zła wartość");                  
                    Console.WriteLine("Podaj płeć: m - mężczyzna / k - kobieta");
                    while (true)
                    {
                        string male2 = Console.ReadLine();
                        if (male2 == "k")
                        {
                            male = "kobieta";
                            break;
                        }
                        else if (male2 == "m")
                        {
                            male = "mężczyzna";
                            break;
                        }
                    }
                    Console.WriteLine("Podaj miasto");
                    city = Console.ReadLine();
                    Console.WriteLine("Podaj kod pocztowy[xx-xxx]: ");
                    while (true)
                    {
                        postcode = Console.ReadLine();
                        Regex postCodeValidation = new Regex(@"[0-9]{2}-[0-9]{3}");
                        if (postCodeValidation.Match(postcode).Success)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Try again");
                        }
                    }        
                    Console.WriteLine("Podaj ulice: ");
                    street = Console.ReadLine();
                    Console.WriteLine("Podaj numer domu: ");
                    while (!int.TryParse(Console.ReadLine(), out housenumber))
                        Console.WriteLine("Zła wartość");                 

                    if (book.add(pesel, name, surname, age, male, postcode, city, street, housenumber))
                        {
                            Console.WriteLine("Adres zostały dodany pomyślnie!");
                        }
                    else
                        {
                            Console.WriteLine("Adres istnieje już na liście, dla numeru {0}.", pesel);
                        }

                    break;
                    
                case "U":
                    try
                    {
                        Console.WriteLine("Podaj pesel osoby do usunięcia: ");
                        pesel = Console.ReadLine();
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
                        pesel = Console.ReadLine();
                        Address addr = book.find(pesel);
                        if (addr == null)
                        {
                            Console.WriteLine("Adres dla numeru pesel {0} nie został znaleziony.", pesel); ;
                        }
                        else
                        {
                            Console.WriteLine("Podaj miasto");
                            addr.city = Console.ReadLine();
                            Console.WriteLine("Podaj kod pocztowy[xx-xxx]: ");
                            while (true)
                            {
                                string postcode2 = Console.ReadLine();
                                Regex postCodeValidation = new Regex(@"[0-9]{2}-[0-9]{3}");
                                if (postCodeValidation.Match(postcode2).Success)
                                {
                                    postcode2 = addr.postcode;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Try again");
                                }
                            }
                            Console.WriteLine("Podaj ulice: ");
                            addr.street = Console.ReadLine();
                            Console.WriteLine("Podaj numer domu: ");
                            while (!int.TryParse(Console.ReadLine(), out addr.housenumber))
                                Console.WriteLine("Zła wartość");
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
