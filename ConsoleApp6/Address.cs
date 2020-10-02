using System;

class Address
{
    public string pesel;
    public string name;
    public string surname;
    public int age;
    public string male;
    public string postcode;
    public string city;
    public string street;
    public int housenumber;

    public Address(string pesel, string name, string surname, int age, string male, string postcode, string city, string street, int housenumber)
    {
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.male = male;
        this.postcode = postcode;
        this.city = city;
        this.street = street;
        this.housenumber = housenumber;
        this.pesel = pesel;
    }
}