using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_step : MonoBehaviour
{
    public int playerSpeed;
    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (controller.GetButtonDown(GvrControllerButton.TouchPadButton))
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
    }
}
