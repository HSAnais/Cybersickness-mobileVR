using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnelling_step : MonoBehaviour
{
    public int speed = 10;
    private GvrControllerInputDevice controller;

    private Vector2 previousPos;

    private bool isHover;
    public GameObject cover;

    // Start is called before the first frame update
    void Start()
    {
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Right);

        cover = GameObject.Find("/Player/Main Camera/TunnelCover");
        cover.SetActive(false);

        isHover = false;

    }

    // Update is called once per frame
    void Update()
    {
        //turning cover on/off
        if (controller.GetButtonDown(GvrControllerButton.TouchPadButton))
        {
            isHover = !isHover;
            cover.SetActive(isHover);            
        }

        //move camera 
        if(isHover == true)
        {
            if(controller.TouchPos != previousPos)
                transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }

        previousPos = controller.TouchPos;
    }
}
