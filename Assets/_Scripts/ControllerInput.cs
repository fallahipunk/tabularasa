using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour {

    public LineRenderer rightLineRenderer;

    // //public int sphereCounter;
    // public Transform rightControllerSphere;
    // public Transform leftControllerSphere;

private bool startFollowing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }

public void StartFollowing(InputAction.CallbackContext context)
{
    if (context.phase == InputActionPhase.Performed)
        startFollowing = true;
    else if (context.phase == InputActionPhase.Canceled)
        startFollowing = false;
    //Debug.Log("Start following: " + context.phase.ToString());
}

public void Pan(InputAction.CallbackContext context){
    if (startFollowing)
    {
        Vector2 val = 0.1f*context.ReadValue<Vector2>();
    // float speed = 3.5f;
        transform.Rotate(new Vector3(val.y,val.x,0));
//         Camera.main.transform.Rotate(new Vector3(val.y*speed, -val.x * speed, 0));
             float X = transform.rotation.eulerAngles.x;
            float Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);

            // Debug.Log(transform.rotation.eulerAngles.ToString());
    }
}

    // private void RaycastLeftContoller()
    // {

    //     Ray ray = new Ray(leftControllerSphere.position, leftControllerSphere.forward);
    //     RaycastHit hit;

    //     rightLineRenderer.SetPosition(0, ray.origin);
    //     rightLineRenderer.SetPosition(1, ray.GetPoint(500));



    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         if (hit.collider.gameObject.CompareTag("Sphere"))
    //         {

    //             StartCoroutine ("fadeSphere", hit.collider.gameObject);

    //         }
    //     }
    // }

    IEnumerator fadeSphere(GameObject sphere)
    {
        // Destroy(sphere);
        // sphereCounter--;
        //  Debug.Log(sphereCounter);

 

       // Renderer r = sphere.GetComponent<Renderer>();
        //Color c = r.material.color;
        for (float f = sphere.transform.localScale.x; f >= 0; f -= 0.007f)
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
