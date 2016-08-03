using UnityEngine;
using System.Collections;

public class starScript : MonoBehaviour {


    Color org;
	// Use this for initialization
	void Start () {
        org = this.gameObject.GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        system systems = cam.GetComponent<system>();
        if (systems.starPressed)
        {

            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = org;
        }
    }

    void OnMouseDown()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        system systems = cam.GetComponent<system>();
        if (!systems.starPressed)
        {

            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = org;
        }


        systems.starPressed = !systems.starPressed;
    }
}
