using System;
using System.Collections.Generic;


class AddressBook
{
    List<Address> addresses;

    public AddressBook()
    {
        addresses = new List<Address>();
    }

    public bool add(string pesel, string name, string surname, int age, string male, string postcode, string city, string street, int housenumber)
    {
        Address addr = new Address(pesel, name, surname, age, male, postcode, city, street, housenumber);
        Address result = find(pesel);

        if (result == null)
        {
            addresses.Add(addr);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool remove(string pesel)
    {
        Address addr = find(pesel);
        
        if (addr != null)
        {
            addresses.Remove(addr);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void list(Action<Address> action)
    {
        addresses.ForEach(action);
    }

    public bool isEmpty()
    {
        return (addresses.Count == 0);
    }

    public Address find(string pesel)
    {
        Address addr = addresses.Find((a) => a.pesel == pesel);
        return addr;
    }
}