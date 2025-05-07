using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickedUpElement : MonoBehaviour
{
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private TMP_Text QuestText;

    private void OnTriggerEnter(Collider other)
    {
        Canvas.SetActive(true);

    }

    private void OnTriggerStay(Collider other)
    {


        Camera camera = Camera.main;
        Canvas.transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

    }

    private void OnTriggerExit(Collider other)
    {
        Canvas.SetActive(false);
    }

    public void SetQuestText()
    {

        QuestText.text = GlobalPlayerData.HowManyElementsToPickUp.ToString() + "/5";

    }

}
