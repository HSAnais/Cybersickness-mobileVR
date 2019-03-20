using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_v2 : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
       
    }
    public void TeleportPlayer()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }

    public void PointerEnter()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PointerExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
