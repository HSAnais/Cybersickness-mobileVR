using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private GameObject player;
    private GameObject checkpoint;
    private GameObject slider;
    private GameObject menu;

    public Text step_text;

    private bool isSelected;
    private int btnIndex;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;

        player = GameObject.Find("Player");
        checkpoint = GameObject.Find("Waypoints");
        slider = GameObject.Find("PlayerSpeed");
        menu = GameObject.Find("MenuContainer");

        step_text.text = "Press the 'Menu' button to choose a type of movement";

        btnIndex = 0;


    }
    
    public void MenuButtonClick(int index)
    {
        //if this isnt the first time selecting a movement, disable all movements
        if (isSelected == true)
            ClearSelection();

        btnIndex = index;
        print("MenuButtonClick: " + btnIndex);

        switch (index)
        {
            case 1:
                step_text.text = "Press down the touchpad to move";
                player.GetComponent<Blink_step>().enabled = true;
                slider.GetComponent<Slider>().value = player.GetComponent<Blink_step>().playerSpeed;
                menu.SetActive(false);//close menu
                slider.SetActive(true);
                break;
            case 2:
                step_text.text = "Press down the touchpad to move";
                player.GetComponent<Dash_step>().enabled = true;
                slider.GetComponent<Slider>().value = player.GetComponent<Dash_step>().playerSpeed;
                menu.SetActive(false);//close menu
                slider.SetActive(true);
                break;
            case 3:
                step_text.text = "Shake the controller in your hand to move";
                player.GetComponent<Hand_step>().enabled = true;
                slider.GetComponent<Slider>().value = player.GetComponent<Hand_step>().playerSpeed;
                menu.SetActive(false);//close menu
                slider.SetActive(true);
                break;
            case 4:
                step_text.text = "Look at the waypoints to teleport";
                player.GetComponent<Gaze_waypoint>().enabled = true;
                checkpoint.SetActive(true);
                menu.SetActive(false);//close menu
                slider.SetActive(true);
                break;
            case 5:
                step_text.text = "(1) Press down the touchpad to toggle on/off tunnel; " +
                    "(2) Move your finger along the touchpad to move;";
                player.GetComponent<Tunnelling_step>().enabled = true;
                slider.GetComponent<Slider>().value = player.GetComponent<Tunnelling_step>().speed;
                menu.SetActive(false);//close menu
                slider.SetActive(true);
                break;
            default:
                break;
        }

        isSelected = true;
    }

    private void ClearSelection()
    {
        //disable all scripts(components) of player...
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;

        isSelected = false;

        //...except for menu
        player.GetComponent<PlayerButtonController>().enabled = true;

        //disable teleport waypoints
        checkpoint.SetActive(false);
    }

    public void ChangeValueSlider()
    {
        switch (btnIndex)
        {
            case 1://blink
                player.GetComponent<Blink_step>().playerSpeed = (int)slider.GetComponent<Slider>().value;
                break;
            case 2://dash
                player.GetComponent<Dash_step>().playerSpeed = (int)slider.GetComponent<Slider>().value;
                break;
            case 3://hand
                player.GetComponent<Hand_step>().playerSpeed = (int)slider.GetComponent<Slider>().value;
                break;
            case 5://tunnelling
                player.GetComponent<Tunnelling_step>().speed = (int)slider.GetComponent<Slider>().value;
                break;
            default:
                break;
        }
    }
}
