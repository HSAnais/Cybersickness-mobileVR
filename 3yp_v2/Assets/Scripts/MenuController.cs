using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private GameObject player;
    private GameObject checkpoint;
    private bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        player = GameObject.Find("Player");
        checkpoint = GameObject.Find("Waypoints");
    }

    public void MenuButtonClick(int index)
    {
        //if this isnt the first time selecting a movement, disable all movements
        if (isSelected)
            ClearSelection();

        switch (index)
        {
            case 1:
                print("You selected Blink step");
                player.GetComponent<Blink_step>().enabled = true;
                break;
            case 2:
                print("You selected Dash step");
                player.GetComponent<Dash_step>().enabled = true;
                break;
            case 3:
                print("You selected Move your hand");
                player.GetComponent<Hand_step>().enabled = true;
                break;
            case 4:
                print("You selected Teleport");
                player.GetComponent<Gaze_waypoint>().enabled = true;
                checkpoint.SetActive(true);
                break;
            case 5:
                print("You selected Tunnel vision");
                //player.GetComponent<Dash_step>().enabled = true;
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
}
