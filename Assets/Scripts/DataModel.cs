using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataModel {

    public readonly List<Person> People = new List<Person>();

    public DataModel(int numberOfPeopleToGenerate, int startingYear, int currentYear, int maxLifeSpan)
    {
        // this helps prevent skewing towards the right of the graph
        int earliestBirthYear = startingYear - (maxLifeSpan/2) + 1;

        for (int i = 0; i < numberOfPeopleToGenerate; ++i)
        {
            int lifeSpan = Random.Range(0, maxLifeSpan);
            int birthYear = Random.Range(earliestBirthYear, currentYear);
            if ( birthYear < startingYear )
            {
                // shift all birth years onto the graph per requirements
                birthYear = startingYear;
            }
            int? deathYear = null;
            if ( birthYear + lifeSpan <= currentYear ) 
            {
                deathYear = birthYear + lifeSpan;
            }
            
            People.Add(new Person("Person " + i, birthYear, deathYear));
        }
    }
}
