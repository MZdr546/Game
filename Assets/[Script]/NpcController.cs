using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NpcController : MonoBehaviour
{

    [SerializeField]
    private GameObject NPC_UI, Hint;
    public Animator Animator;
    public NpcDialogue Dialogue;

    private void Update()
    {
        Dialogue.CheckDistance();
    }

    private void OnTriggerEnter(Collider other)
    {
        Hint.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {


        Camera camera = Camera.main;
        Hint.transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

    }

    private void OnTriggerExit(Collider other)
    {

        Hint.SetActive(false);
        NPC_UI.SetActive(false);
    }

    

}
