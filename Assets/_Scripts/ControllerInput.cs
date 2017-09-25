using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public LineRenderer rightLineRenderer;

    public Transform rightController;
    public Transform leftController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

  //      laserLineRenderer.SetPosition(0, rightController.transform.position);
//        laserLineRenderer.SetPosition(1, rightController.transform.forward);

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            rightLineRenderer.enabled = true;

            RaycastRightContoller();
            
        }
        else{
            rightLineRenderer.enabled=false;
        }
		
	}

    private void RaycastRightContoller()
    {
        RaycastHit hit;
        Ray ray = new Ray(rightController.position, rightController.forward);

        rightLineRenderer.SetPosition(0, ray.origin);
        rightLineRenderer.SetPosition(1, ray.GetPoint(500));
       // Debug.DrawLine(ray.origin, ray.GetPoint(10));


        if (Physics.Raycast(ray, out hit)){
            if (hit.collider.gameObject.CompareTag("Sphere"))
            {
                Destroy(hit.collider.gameObject);
                
            }
        }
    }
}
