using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Camera being used
    public Camera camera;

    // Get the Dynamic Steering component to handle player movement
    private DynamicSteer movementControls;
    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        // Init controls and target
        movementControls = gameObject.GetComponent<DynamicSteer>();
        currentTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse click input
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Trace a ray from the camera to the world
            // where the mouse is pointing
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Set the target to the hit position
                currentTarget = hit.point;
            }
        }

        // Make the player move to the target
        movementControls.Steer(currentTarget);
    }
}