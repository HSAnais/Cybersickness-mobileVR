using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonController : MonoBehaviour
{
    private GameObject MenuContainer; //menu
    private bool menuStatus;
    private GameObject slider;

    private GvrControllerInputDevice controller;
    private Camera cmr;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        cmr = Camera.main;

        //remember start position of camera
        startPos = cmr.transform.position;

        controller = GvrControllerInput.GetDevice(GvrControllerHand.Right);
        slider = GameObject.Find("PlayerSpeed");

        MenuContainer = GameObject.Find("MenuContainer");
        MenuContainer.SetActive(false);
        menuStatus = false;

        slider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //menu binding to App button
        if (controller.GetButtonDown(GvrControllerButton.App))
        {
            menuStatus = !menuStatus;
            MenuContainer.SetActive(menuStatus);

            //this doesnt happen through when coming back
            slider.SetActive(!menuStatus);
        }

        //reset camera position binding to Home button
        if (controller.GetButtonDown(GvrControllerButton.System))
            cmr.transform.position = startPos;
    }
}
