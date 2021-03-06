using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    // constants
    const float HOLD_THRESHOLD = 0.15f; // threshold of time (in seconds) after which we consider mouse click/touch to be a "hold" instead of click

    // component and object references (linked through inspector)
    //public LineRenderer lineRenderer;
    public Camera mainCam;
    
    // class variables
    float mouseHoldDuration = 0f; // how long its been since we were holding the mouse/touch (to determine hold vs click)
    bool startFollowing = false; // a flag to determin whether or not we pushed the mouse/touch down to start following and orbiting the camera
    float touchRotationScale = 0.1f; // scale factor to convert screen size to rotation (for touch)
    float rotationY = 0f; // to keep track of up-down rotation

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Escape)) { Application.Quit(); }
        Vector2 delta = Vector2.zero;

        if (Input.touchCount > 0)
        {
            // get touch input
            Touch t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    startFollowing = true;
                    mouseHoldDuration = 0;
                    break;
                case TouchPhase.Moved:
                    delta = touchRotationScale * t.deltaPosition;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    startFollowing = false;
                    if (mouseHoldDuration < HOLD_THRESHOLD) { ClickHandler(); }
                    break;
                case TouchPhase.Canceled:
                    startFollowing = false;
                    if (mouseHoldDuration < HOLD_THRESHOLD) { ClickHandler(); }
                    break;
                default:
                    break;
            }
        }
        else
        {
            startFollowing = true;
            delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if (Input.GetMouseButtonUp(0)) { ClickHandler(); }
        }

        // rotate screen
        if (startFollowing)
        {
            mouseHoldDuration += Time.deltaTime;
            float rotationX = transform.localEulerAngles.y +  delta.x;
            rotationY +=  delta.y;
            rotationY = Mathf.Clamp(rotationY, -89.9f, 89.9f);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }

    private void ClickHandler()
    {
        Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //lineRenderer.SetPosition(0, ray.origin);
        //lineRenderer.SetPosition(1, ray.GetPoint(500));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Sphere"))
            {
                StartCoroutine("fadeSphere", hit.collider.gameObject);
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
