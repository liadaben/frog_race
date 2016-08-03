using UnityEngine;
using System.Collections;

public class buildFrogs : MonoBehaviour {

    public frog frogPrefab = null;
    public float startModifier = 9.0f;
    protected void craeteTracks()
    {
        buildTrack trackBuilder = GetComponent<buildTrack>();
        int numberOfTracks = trackBuilder.numberOfTracks;
        Vector3 initPosition = trackBuilder.initPosition;
        Vector3 endPosition = trackBuilder.endPosition;
        initPosition[2] = initPosition[2] - 1;
        endPosition[2] = endPosition[2] - 1;

        initPosition[0] = initPosition[0] + startModifier;
        endPosition[0] = endPosition[0] + startModifier;

        int i;
        for (i = 0; i < numberOfTracks; i++)
        {
            // spawn bullet
            float startI = (float)i / (float)(numberOfTracks - 1);
            Vector3 finPosition = initPosition * startI + endPosition * (1.0f - startI);
            GameObject thisFrogg = (GameObject)Instantiate(frogPrefab.gameObject, finPosition, Quaternion.identity);
            frog thisFrog = thisFrogg.GetComponent<frog>();
            thisFrog.frogNum = i;
        }

    }


    // Use this for initialization
    void Start () {
        craeteTracks();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
