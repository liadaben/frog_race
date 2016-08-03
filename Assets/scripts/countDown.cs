using UnityEngine;
using System.Collections;

public class countDown : MonoBehaviour {

    public float countDownTime = 11.0f;
    private bool insiatedComputers;
    private float startcountDownTime;
    public comScript comPrefab = null;
    public int numOfComputers = 15;
    public textFiled textLabelPrefab = null;

 
    // Use this for initialization
    void Start () {
        insiatedComputers = false;
        startcountDownTime = countDownTime;
    }
	
	// Update is called once per frame
	void Update () {
        countDownTime -= Time.deltaTime;
        int floorCount = (int)Mathf.Floor(countDownTime);
        GetComponent<TextMesh>().text = floorCount.ToString();
        if (countDownTime < 0.9f)
        {
            GameObject[] frogs = GameObject.FindGameObjectsWithTag("frog");
            for(int i=0;i< frogs.Length;i++)
            {
                frog nowFrog = frogs[i].GetComponent<frog>();
                nowFrog.paused = false;

            }
            Destroy(this.gameObject);
        }
        if(!insiatedComputers && countDownTime < startcountDownTime/2.0f)
        {
            insiatedComputers = true;
            for (int i = 0; i < numOfComputers; i++)
            {
                comScript newCom = (comScript)Instantiate(comPrefab, Vector3.one, Quaternion.identity);
                newCom.setName("com" + i.ToString());
            }

        }

    }
}
