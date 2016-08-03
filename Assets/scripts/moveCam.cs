using UnityEngine;
using System.Collections;

public class moveCam : MonoBehaviour {

    public float camSpeed = 1.0f;
    public float lowerBound = -9.0f;
    public float upperBound = 100.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        float inDir = Input.GetAxis("Horizontal");
        Vector3 camPos = cam.transform.position;
        camPos.x = camPos.x + camSpeed * inDir;
        if (camPos.x < lowerBound)
        {
            camPos.x = lowerBound;
        }
        if (camPos.x > upperBound)
        {
            camPos.x = upperBound;
        }

        GameObject[] frogs = GameObject.FindGameObjectsWithTag("frog");
        float lowerestx = 10.0f;
        for (int i = 0; i < frogs.Length; i++)
        {
            frog nowFrog = frogs[i].GetComponent<frog>();
            if (frogs[i].transform.position.x < lowerestx)
            {
                lowerestx = frogs[i].transform.position.x;
            }

        }
        camPos.x = lowerestx - 1;
        cam.transform.position = camPos;



    }
}
