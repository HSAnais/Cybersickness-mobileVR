using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gaze_waypoint : MonoBehaviour
{
    private RaycastHit hitObj;
    private int distanceOfRay = 100;
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
            if (hitObj.transform.gameObject.CompareTag("Waypoint"))
                hitObj.transform.gameObject.GetComponent<Teleport_v2>().TeleportPlayer();                     
    }
}
