using UnityEngine;
using System.Collections;

public class Person
{
    public readonly string Name;
    public readonly int BirthYear;
    public readonly int? DeathYear;

    public Person(string name, int birthYear, int? deathYear)
    {
        Name = name;
        BirthYear = birthYear;
        DeathYear = deathYear;
    }
}
