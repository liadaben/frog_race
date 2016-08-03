using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class systemLevel2 : MonoBehaviour {
    private int frogNum;
    private List<string> selectedFrog;
    public GUIStyle customGuiStyle;
    // Use this for initialization
    void Start () {
        frogNum = PlayerPrefs.GetInt("winner");
        selectedFrog = new List<string>();
        int coun = PlayerPrefs.GetInt("winnerCounet");
        for (int i = 0; i < coun; i++)
        {
            selectedFrog.Add(PlayerPrefs.GetString("winnerNum" + i.ToString()));
        }

    }
	
	// Update is called once per frame
	void Update () {
        

	}

    void OnGUI()
    {
        GUI.Label(new Rect(50, 50, Screen.width, Screen.height), "winner is " + frogNum.ToString(), customGuiStyle);
        for (int i = 0; i < selectedFrog.Count; i++)
        {
            GUI.Label(new Rect(50, 100 * (i + 1), Screen.width, Screen.height), "winner is " + selectedFrog[i], customGuiStyle);
        }

        if (GUI.Button(new Rect(50, 100*(selectedFrog.Count + 2), Screen.width/8, Screen.height/8), "restart!"))
        {
            Application.LoadLevel("race");
        }
    }
}
