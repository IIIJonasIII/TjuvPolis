﻿namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> belongings = new List<string>();
            belongings.Add("nycklar");
            belongings.Add("mobiltelefon");
            belongings.Add("plånbok");
            belongings.Add("klocka");

            Medborgare medborgare = new Medborgare(belongings, 10, 20, 1000);
            Medborgare medborgare1 = new Medborgare(belongings, 15, -2, 1000);
            Medborgare medborgare2 = new Medborgare(belongings, 1, 55, 1000);
            Medborgare medborgare3 = new Medborgare(belongings, -6, 22, 1000);
            Medborgare medborgare4 = new Medborgare(belongings, 26, -20, 1000);
            Medborgare medborgare5 = new Medborgare(belongings, 11, 30, 1000);


            List<Person> persons = new List<Person>();  
            persons.Add(medborgare);
            persons.Add(medborgare1);
            persons.Add(medborgare2);
            persons.Add(medborgare3);
            persons.Add(medborgare4);
            persons.Add(medborgare5);

            foreach (Person person in persons)
            {
                Console.WriteLine($"{person}");
            }
        }
    }
}
