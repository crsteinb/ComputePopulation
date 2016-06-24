using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PeopleViewController : MonoBehaviour
{

    public PersonEntry PersonEntryPrefab;
    public VerticalLayoutGroup PeopleViewContentPanel;

    private void ClearPeople()
    {
        PersonEntry[] entries = GetComponentsInChildren<PersonEntry>();
        foreach (PersonEntry entry in entries)
        {
            Destroy(entry.gameObject);
        }
    }

    public void PopulatePeopleView(List<Person> people)
    {
        ClearPeople();

        foreach (Person person in people)
        {
            PersonEntry personEntry = Instantiate(PersonEntryPrefab);
            personEntry.transform.SetParent(PeopleViewContentPanel.transform, false);
            personEntry.SetPerson(person);
        }
    }
}
