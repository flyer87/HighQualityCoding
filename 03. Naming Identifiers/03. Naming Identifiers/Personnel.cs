using System;
using System.Collections.Generic;

public class Personnel 
{
    public enum Gender
    {
        Male, Female
    }

    public void CreatePerson(int magicNumber)
    {
        Person person = new Person();
        person.Age = magicNumber;
        if (magicNumber % 2 == 0)
        {
            person.FullName = "Male name";
            person.Sex = Gender.Male;
        }
        else
        {
            person.FullName = "Female name";
            person.Sex = Gender.Female;
        }
    }

    private class Person
    {
        public Gender Sex { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }
    }
}