using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(LayoutElement))]
public class GraphEntry : MonoBehaviour {

    public int MaxHeight = 300;
    public int MinHeight = 1;
    public int CurrentHeight = 1;

    private LayoutElement layout;
    
	void Awake () {
        layout = GetComponent<LayoutElement>();
	}
	
	public void SetPercentage(float percent)
    {
        layout.preferredHeight = percent * MaxHeight;
        if ( percent == 0.0f)
        {
            layout.preferredHeight = MinHeight;
        }
    }
}
