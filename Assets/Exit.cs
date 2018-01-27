using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    Text ui;
    public GameObject closed;
    public GameObject open;

	// Use this for initialization
	void Start () {
        ui = GameObject.FindGameObjectWithTag("EnemiesRemaining").GetComponent<Text>();
        CountEnemies();
    }

    public void CountEnemies()
    {
        int remaining = GameObject.FindObjectsOfType<EnemyMovement>().Length;

        if(ui!= null) ui.text = remaining.ToString();

        if(remaining == 0)
        {
            closed.SetActive(false);
            open.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
