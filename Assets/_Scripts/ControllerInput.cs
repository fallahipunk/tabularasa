using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public Transform rightControllerSphere;
    public Transform leftControllerSphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("button pressed");
            RaycastRightContoller();
        }
		
	}

    private void RaycastRightContoller()
    {
        RaycastHit hit;
        if (Physics.Raycast(rightControllerSphere.position, rightControllerSphere.forward, out hit)){
            if (hit.collider.gameObject.CompareTag("Sphere"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
