using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIController : MonoBehaviour {

    public InputField StartingYearField;
    public InputField EndingYearField;
    public InputField NumberOfPeopleField;
    public InputField MaxLifespanField;
    public InputField MostPopulousYearField;
    public InputField PopulationField;
    public PeopleViewController PeopleView;
    public GraphController Graph;

    public void GeneratePeopleAndCompute()
    {
        int numberOfPeople = 0;
        try { numberOfPeople = int.Parse(NumberOfPeopleField.text); } catch { NumberOfPeopleField.text = numberOfPeople.ToString(); }
        int startingYear = 1900;
        try { startingYear = int.Parse(StartingYearField.text); } catch { StartingYearField.text = startingYear.ToString(); }
        int endingYear = 2000;
        try { endingYear = int.Parse(EndingYearField.text); } catch { EndingYearField.text = endingYear.ToString(); }
        int maxLifespan = 100;
        try { maxLifespan = int.Parse(MaxLifespanField.text); } catch { MaxLifespanField.text = maxLifespan.ToString(); }

        if (startingYear > endingYear )
        {
            int temp = startingYear;
            startingYear = endingYear;
            endingYear = temp;
            StartingYearField.text = startingYear.ToString();
            EndingYearField.text = endingYear.ToString();
        }

        DataModel model = new DataModel(numberOfPeople, startingYear, endingYear, maxLifespan);

        PeopleView.PopulatePeopleView(model.People);

        int[] mappingOfPopulationToDate = DateComputation.ComputeNumberOfLivingForEachYear(model.People, startingYear, endingYear);
        Graph.PopulateGraph(startingYear, endingYear, numberOfPeople, mappingOfPopulationToDate);

        int mostPopulousYear = DateComputation.ComputeDateOfMostLiving(mappingOfPopulationToDate, startingYear);
        MostPopulousYearField.text = mostPopulousYear.ToString();
        PopulationField.text = mappingOfPopulationToDate[mostPopulousYear - startingYear].ToString();
    }
}
