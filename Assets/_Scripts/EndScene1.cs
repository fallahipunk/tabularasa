using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene1 : MonoBehaviour {

    public Transform spheres;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spheres.childCount == 0)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
		
	}
}
