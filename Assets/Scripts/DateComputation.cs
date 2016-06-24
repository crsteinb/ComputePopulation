using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class DateComputation {

    /// <summary>
    /// Returns the date of the earliest year within the given year range that had the most living people in it. 
    /// Will assume whole year is evaluated regardless of specific day of birth/death.
    /// </summary>
    /// <param name="people">The list of people to evaluate</param>
    /// <param name="beginningYear">The year to start evaluation from</param>
    /// <param name="endingYear">The year to stop evalution from</param>
    /// <returns>The earliest year containing the most living people</returns>
	public static int ComputeDateOfMostLiving(List<Person> people, int beginningYear, int endingYear)
    {
        int[] years = ComputeNumberOfLivingForEachYear(people, beginningYear, endingYear);

        return ComputeDateOfMostLiving(years, beginningYear);
    }

    /// <summary>
    /// Variant of ComputeDateOfMostLiving that can consume a pre-existing year mapping (for efficiency in graphing)
    /// </summary>
    /// <param name="preExistingMapping">Pre-existing mapping of years to number of living</param>
    /// <param name="beginningYear">The base year offset for the pre-existing mapping</param>
    /// <returns>The earliest year containing the most living people</returns>
    public static int ComputeDateOfMostLiving(int[] preExistingMapping, int beginningYear)
    {
        if ( preExistingMapping.Length == 0)
        {
            return beginningYear;
        }

        int numberOfMostLiving = Enumerable.Max(preExistingMapping);
        int index = Array.IndexOf(preExistingMapping, numberOfMostLiving);

        return index + beginningYear;
    }

    /// <summary>
    /// Returns a mapping of years starting from the beginning year to the ending year of the number of living people.
    /// </summary>
    /// <param name="people">The list of people to evaluate</param>
    /// <param name="beginningYear">The year to start evaluation from</param>
    /// <param name="endingYear">The year to stop evalution from</param>
    /// <returns>The list of the number of people living in each year (0 based index offset from beginning year)</returns>
    public static int[] ComputeNumberOfLivingForEachYear(List<Person> people, int beginningYear, int endingYear)
    {
        if (endingYear < beginningYear)
        {
            Debug.LogError("Evalution failed due to ending year being earlier than beginning year");
        }
        int numberOfYearsToEvaluate = endingYear - beginningYear + 1;
        int[] years = Enumerable.Repeat(0, numberOfYearsToEvaluate).ToArray(); ;

        foreach (Person person in people)
        {
            int startIndex = person.BirthYear - beginningYear;
            startIndex = Math.Max(0, startIndex);
            int endIndex = numberOfYearsToEvaluate - 1;
            if (person.DeathYear.HasValue && person.DeathYear <= endingYear)
            {
                endIndex = person.DeathYear.GetValueOrDefault() - beginningYear;
            }
            for (int i = startIndex; i <= endIndex; ++i)
            {
                ++years[i];
            }
        }
        return years;
    }
}
