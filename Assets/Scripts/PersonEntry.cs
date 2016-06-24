using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PersonEntry : MonoBehaviour {

    public Text entryText;

    public void SetPerson(Person person)
    {
        string deathString = "Still Alive";
        if ( person.DeathYear.HasValue )
        {
            deathString = person.DeathYear.Value.ToString();
        }
        entryText.text = "Name: " + person.Name + " - Birth: " + person.BirthYear + " - Death: " + deathString;
    } 
}