using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GraphController : MonoBehaviour {

    public GraphEntry GraphEntryPrefab;
    public Text MinHorizontalValue;
    public Text MaxHorizontalValue;
    public Text MaxVerticalValue;
    public HorizontalLayoutGroup GraphEntryPanel;

	private void ClearGraph()
    {
        GraphEntry[] entries = GetComponentsInChildren<GraphEntry>();
        foreach(GraphEntry entry in entries)
        {
            Destroy(entry.gameObject);
        }
    }

    public void PopulateGraph(int minHorizontalValue, int maxHorizontalValue, int maxVerticalValue, int[] values)
    {
        MinHorizontalValue.text = minHorizontalValue.ToString();
        MaxHorizontalValue.text = maxHorizontalValue.ToString();
        MaxVerticalValue.text = maxVerticalValue.ToString();

        ClearGraph();

        for(int i = 0; i < values.Length; ++i)
        {
            GraphEntry entry = Instantiate(GraphEntryPrefab);
            entry.transform.SetParent(GraphEntryPanel.transform, false);
            entry.SetPercentage((float)values[i] / maxVerticalValue);
        }
    }
}
