using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonController : MonoBehaviour
{
    public GameObject MenuContainer; //menu prefab
    private GameObject menuInstance;

    private GvrControllerInputDevice controller;
    private Camera cmr;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        menuInstance = null;
        cmr = Camera.main;

        //remember start position of camera
        startPos = cmr.transform.position;

        controller = GvrControllerInput.GetDevice(GvrControllerHand.Right);
    }

    // Update is called once per frame
    void Update()
    {
        //menu binding to App button
        if (controller.GetButtonDown(GvrControllerButton.App))
            if (menuInstance)
                DestroyMenu();
            else
                CreateMenu();

        //reset camera position binding to Home button
        if (controller.GetButtonDown(GvrControllerButton.System))
            cmr.transform.position = startPos;
    }

    private void CreateMenu()
    {
        //Move camera in front of player's view
        Vector3 direction = cmr.transform.forward * 3;
        direction.y += MenuContainer.transform.position.y;

        menuInstance = Instantiate(MenuContainer, direction, cmr.transform.rotation);
    }

    private void DestroyMenu()
    {
        Destroy(menuInstance);
        menuInstance = null;
    }
}
