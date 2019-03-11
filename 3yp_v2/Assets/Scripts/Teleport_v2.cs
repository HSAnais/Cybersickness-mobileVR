using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_v2 : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        print("teleport script is up");
        player = GameObject.FindGameObjectWithTag("Player");
        print(player);
    }
    public void TeleportPlayer()
    {
        print("position method is accessed");
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }

    public void PointerEnter()
    {
        print("pointer enter");
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PointerExit()
    {
        print("pointer exit");
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
