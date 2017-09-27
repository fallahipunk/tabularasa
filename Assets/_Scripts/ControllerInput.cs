using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public LineRenderer rightLineRenderer;

    public int sphereCounter;
    public Transform rightControllerSphere;
    public Transform leftControllerSphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       // Check if right touch contoller is connected
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch))
        {
            rightControllerSphere.gameObject.SetActive(true);

            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {

                rightLineRenderer.enabled = true;

                RaycastRightContoller();

            }
            else
            {
                rightLineRenderer.enabled = false;
            }
        }

        //if the rigt contoller is not connected disable the right contoller sphere
        else
        {
            rightControllerSphere.gameObject.SetActive(false);
        }

       // check  if left contoller is connected

        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTouch))
        {
            leftControllerSphere.gameObject.SetActive(true);
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {

                rightLineRenderer.enabled = true;

                RaycastLeftContoller();

            }
            else
            {
                rightLineRenderer.enabled = false;
            }
        }

        //if the left contoller is not connected disable the left contoller sphere
        else
        {
            leftControllerSphere.gameObject.SetActive(false);
        }
    }

    private void RaycastRightContoller()
    {
       
        Ray ray = new Ray(rightControllerSphere.position, rightControllerSphere.forward);
        RaycastHit hit;

        rightLineRenderer.SetPosition(0, ray.origin);
        rightLineRenderer.SetPosition(1, ray.GetPoint(500));



        if (Physics.Raycast(ray, out hit)){
            if (hit.collider.gameObject.CompareTag("Sphere"))
            {
                StartCoroutine("fadeSphere", hit.collider.gameObject);

            }
        }
    }

    private void RaycastLeftContoller()
    {

        Ray ray = new Ray(leftControllerSphere.position, leftControllerSphere.forward);
        RaycastHit hit;

        rightLineRenderer.SetPosition(0, ray.origin);
        rightLineRenderer.SetPosition(1, ray.GetPoint(500));



        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Sphere"))
            {

                StartCoroutine ("fadeSphere", hit.collider.gameObject);

            }
        }
    }

    IEnumerator fadeSphere(GameObject sphere)
    {
        // Destroy(sphere);
        // sphereCounter--;
        //  Debug.Log(sphereCounter);

 

       // Renderer r = sphere.GetComponent<Renderer>();
        //Color c = r.material.color;
        for (float f = 1f; f >= 0; f -= 0.007f)
        {
            if (sphere != null)
            {
                sphere.transform.localScale = new Vector3(f, f, f);
            }
            yield return null;
        }

        Destroy(sphere);
    }
    
}
