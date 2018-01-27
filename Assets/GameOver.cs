using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    bool startEnd = false;
    float timer;
    float timeToRestart = 5;

    public void EndGame()
    {
        startEnd = true;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(startEnd)
        {
            timer += Time.deltaTime;
        }
		
        if(timer > timeToRestart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
