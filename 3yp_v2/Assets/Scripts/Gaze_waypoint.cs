using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gaze_waypoint : MonoBehaviour
{
    private RaycastHit hitObj;
    public int distanceOfRay = 100;
    private Camera cmr;

    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        cmr = Camera.main;
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Right);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cmr.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        
        if (Physics.Raycast(ray, out hitObj, distanceOfRay) && controller.GetButtonDown(GvrControllerButton.TouchPadButton))
            if (hitObj.transform.CompareTag("Waypoint"))//atm it only hits terrain, even tho it is pointed at waypoint
            {
                print("found waypoint is being pressed at");
                print(hitObj);
                hitObj.transform.gameObject.GetComponent<Teleport_v2>().TeleportPlayer();
                print("teleport just called");
            }
            else
                print(hitObj.transform.name);        
    }
}
