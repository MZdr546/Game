using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SirenUi : MonoBehaviour
{
    GameObject player;
    public GameObject UI;
    Camera camera;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
    }

    void Update()
    {
        gameObject.transform.LookAt(camera.transform);
        if (Input.GetKey(KeyCode.F))
        {
            UI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
