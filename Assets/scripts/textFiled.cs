using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class textFiled : MonoBehaviour {

    public List<string> nameArray;

    public float timeToSwitch = 1.0f;
    private int index;
    private int listSize;
    private float currntTime;
    private string findName = "";
    // Use this for initialization
    void Start () {
        index = 0;
        currntTime = timeToSwitch;
        listSize = 0;
    }
	
	// Update is called once per frame
	void Update () {
        currntTime += Time.deltaTime;
        listSize = nameArray.Count;
        index = index % listSize;
        if (currntTime > timeToSwitch && listSize!=0)
        {

            currntTime = 0;
            GetComponent<TextMesh>().text = nameArray[index];
            index++;
            
        }
        //GetComponent<TextMesh>().text = name;
    }

    public void addName(string nameNow)
    {

        nameArray.Add(nameNow);
        listSize = listSize + 1;
    }

    private bool isName(string name)
    {

        return (name == findName);
    }


    public void removeName(string nameNow)
    {
        findName = nameNow;
        int inde = nameArray.FindIndex(isName);
        nameArray.RemoveAt(inde);
        listSize = listSize - 1;
    }


}
