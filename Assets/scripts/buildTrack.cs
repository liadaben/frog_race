using UnityEngine;
using System.Collections;

public class buildTrack : MonoBehaviour {

    public Track trackPrefab = null;
    public textFiled textPrefab = null;
    public int numberOfTracks = 6;
    public Vector3 initPosition;
    public Vector3 endPosition;
    public float moveText = -0.8f;


    protected void craeteTracks()
    {
        int i;
        for (i = 0; i < numberOfTracks; i++)
        {
            // spawn bullet
            float startI = (float)i / (float)(numberOfTracks - 1);
            Vector3 finPosition = initPosition * startI + endPosition * (1.0f - startI);
            Instantiate(trackPrefab.gameObject, finPosition, Quaternion.identity);
            finPosition.x -= moveText;
            textFiled g = (textFiled)Instantiate(textPrefab, finPosition, Quaternion.identity);
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
            g.GetComponent<Transform>().parent = cam.transform;
            g.addName(i.ToString());



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
