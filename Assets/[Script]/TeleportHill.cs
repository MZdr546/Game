using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TeleportHill : MonoBehaviour
{
    public GameObject toTeleport;
    public GameObject _player;
    public GameObject _ui;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _player = player.transform.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        _ui.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            _player.transform.position = toTeleport.transform.position;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _ui.SetActive(false);
    }


}


