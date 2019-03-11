using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_step : MonoBehaviour
{
    private int playerSpeed;
    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
    }

    // Update is called once per frame
    void Update()
    {
        //if the controller's position is changed:
        //(?) calculate speed from the difference of coordinates
        transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
    }
}
