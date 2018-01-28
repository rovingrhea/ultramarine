using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {

    public float zoom;
    public float zoomSpeed;

    public bool endScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoom, zoomSpeed * Time.deltaTime / 100);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(endScene)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
