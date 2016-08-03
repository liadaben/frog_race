using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class frog : MonoBehaviour {

    public textFiled textLabelPrefab = null;
    public bool paused;
    public int moveX = 0;
    public float upAmount = 1.0f;
    public float distBack = 0.5f;
    private string frogName;
    private int betAmount;
    private bool selected = false;
    public List<string> selectedFrog;
    private textFiled g;
    public int frogNum;
    private string findName = "";

    private int Stared;
    // Use this for initialization
    void Start () {
        paused = true;
        betAmount = 0;
        upAmount = 1.0f;
        selectedFrog = new List<string>();
        Stared = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (!paused)
        {
            moveX = Random.Range(1 + Stared, 50);
            moveX = moveX / 3;
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * (-1), 0);
        }
    }

    private bool isName(string name)
    {

        return (name == findName);
    }

    public void deSelectFrog(string name)
    {
        Vector3 pos2 = this.transform.position;
        pos2.x -= distBack;
        this.transform.position = pos2;
        findName = name;
        int inde = selectedFrog.FindIndex(isName);
        selectedFrog.RemoveAt(inde);
        
        if (selectedFrog.Count == 0)
        {
            selected = false;
            Destroy(g.gameObject);
        }
        else
        {
            g.removeName(name);
        }


    }
    public void selectFrog(string name)
    {
        int frogNum = PlayerPrefs.GetInt(name);
        if (frogNum != this.frogNum)
        {
            selectedFrog.Add(name);
        }
        else
        {
            return;
        }
        if (frogNum != -1)
        {
            GameObject[] frogs = GameObject.FindGameObjectsWithTag("frog");
            for (int i = 0; i < frogs.Length; i++)
            {
                frog nowFrog = frogs[i].GetComponent<frog>();
                if (nowFrog.frogNum == frogNum && this.frogNum != nowFrog.frogNum)
                {
                    nowFrog.deSelectFrog(name);
                }

            }
        }

        PlayerPrefs.SetInt(name, this.frogNum);
        if (!selected)
        {
           
            selected = true;
            Vector3 TextPosition = gameObject.transform.position;
            TextPosition.y += upAmount;
            TextPosition.x -= 0.5f;
            g = (textFiled)Instantiate(textLabelPrefab, TextPosition, Quaternion.identity);

            g.GetComponent<Transform>().parent = transform;
        }
       // textFiled texti = g.GetComponent<textFiled>();

        g.addName(name);
        Vector3 pos = this.transform.position;
        pos.x += distBack;
        this.transform.position = pos;
    }

    public void starFrog()
    {
        Stared++;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        
    }
    void OnMouseDown()
    {
        
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        system systems = cam.GetComponent<system>();
        if(systems.starPressed)
        {
            systems.starPressed = !systems.starPressed;
            starFrog();
        }
        else
        {
            selectFrog("player");
        }

    }


}
