using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gaze_waypoint : MonoBehaviour
{
    private RaycastHit hitObj;
    private int distanceOfRay = 100;
    private Camera cmr;

    private GameObject waypoints;
    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        cmr = Camera.main;
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Right);

        waypoints = GameObject.Find("Waypoints");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cmr.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out hitObj, distanceOfRay))
        {
            if (hitObj.transform.gameObject.CompareTag("Waypoint"))
                if (controller.GetButtonDown(GvrControllerButton.TouchPadButton))
                {
                    hitObj.transform.gameObject.GetComponent<Teleport_v2>().TeleportPlayer();
                    hitObj.transform.gameObject.GetComponent<Teleport_v2>().PointerExit();
                }
                else
                    hitObj.transform.gameObject.GetComponent<Teleport_v2>().PointerEnter();
            else
                for (int i = 0; i < waypoints.transform.childCount; i++)
                    waypoints.transform.GetChild(i).gameObject.GetComponent<Teleport_v2>().PointerExit();         
        }
    }
}
