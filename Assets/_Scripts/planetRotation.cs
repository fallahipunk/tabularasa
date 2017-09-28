using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetRotation : MonoBehaviour {

    public Transform cubes;
    public Transform spheres1;
    public Transform spheres2;
    public Transform spheres3;
    public Transform spheres4;

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        cubes.Rotate(Vector3.up * Time.deltaTime);
        spheres1.Rotate(Vector3.up * Time.deltaTime);
        spheres2.Rotate(Vector3.down * Time.deltaTime);
        spheres3.Rotate(Vector3.left * Time.deltaTime);
        spheres4.Rotate(Vector3.left * Time.deltaTime);
    }
}
