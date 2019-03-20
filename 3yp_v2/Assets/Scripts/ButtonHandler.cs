using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private RaycastHit hitObj;
    private int distanceOfRay = 100;
    private Camera cmr;
    private GvrControllerInputDevice controller;

    private GameObject menu;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        cmr = Camera.main;
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Right);

        menu = GameObject.Find("MenuContainer");

        switch(this.gameObject.name)
        {
            case "Blink_Button":
                index = 1;
                break;
            case "Dash_Button":
                index = 2;
                break;
            case "Hand_Button":
                index = 3;
                break;
            case "Teleport_Button":
                index = 4;
                break;
            case "Tunnel_Button":
                index = 5;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cmr.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out hitObj, distanceOfRay) && controller.GetButtonDown(GvrControllerButton.TouchPadButton))
        {
            print(hitObj.transform.name);
            print("Button index: " + index);//it changes here to 2 for some reason
            menu.GetComponent<MenuController>().MenuButtonClick(index);
        }
    }

}
