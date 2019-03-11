using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink_step : MonoBehaviour
{
    public int playerSpeed;
    private GameObject cover;
    
    public float _timeInDark; // time of blink
    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        cover = GameObject.Find("/Player/Main Camera/Cover");
        cover.SetActive(false);

        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);

        _timeInDark = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetButtonDown(GvrControllerButton.TouchPadButton))
        {
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        cover.SetActive(true);//screen is covered 

        //change position
        transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        yield return new WaitForSeconds(_timeInDark); // wait in the dark

        cover.SetActive(false);//cover dissappears
    }
}
