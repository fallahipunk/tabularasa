using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene2 : MonoBehaviour {
    public Transform spheres1;
    public Transform spheres2;
    public Transform spheres3;
    public Transform spheres4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spheres1.childCount == 0 && spheres2.childCount == 0 && spheres3.childCount == 0 && spheres4.childCount == 0)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
