using UnityEngine;
using System.Collections;

public class comScript : MonoBehaviour {
    private string comName;
	// Use this for initialization
	void Start () {
	
	}

    public void setName(string name)
    {
        PlayerPrefs.SetInt(name, -1);
        comName = name;
        int chosenFrog;
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        int numberOfFrogs = cam.GetComponent<buildTrack>().numberOfTracks;
        chosenFrog = Random.Range(0, numberOfFrogs);
        GameObject[] frogs = GameObject.FindGameObjectsWithTag("frog");
        for (int i = 0; i < frogs.Length; i++)
        {
            frog nowFrog = frogs[i].GetComponent<frog>();
            if (nowFrog.frogNum == chosenFrog)
            {
                nowFrog.selectFrog(name);
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
