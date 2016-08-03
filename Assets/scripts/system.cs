using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class system : MonoBehaviour {

    private bool won = false;
    private int winner;
    private frog winnerFrog;
    public bool starPressed;
    public bool hammerPressed;
    // Use this for initialization
    void Start () {
        won = false;
        PlayerPrefs.SetInt("player", -1);
        starPressed = false;
        hammerPressed = false;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] frogs = GameObject.FindGameObjectsWithTag("frog");
        
        for (int i = 0; i < frogs.Length; i++)
        {
            frog nowFrog = frogs[i].GetComponent<frog>();
            if(frogs[i].transform.position.x < -45.0f)
            {
                won = true;
                winner = nowFrog.frogNum;
                winnerFrog = nowFrog;
            }

        }
        if(won)
        {
            PlayerPrefs.SetInt("winner", winner);
            List<string> selectedFrog = winnerFrog.selectedFrog;
            PlayerPrefs.SetInt("winnerCounet", selectedFrog.Count);
            
            for (int i = 0; i < selectedFrog.Count; i++)
            {
                PlayerPrefs.SetString("winnerNum" + i.ToString(), selectedFrog[i]);
            }
            SceneManager.LoadScene("winner");
        }
    }
}
