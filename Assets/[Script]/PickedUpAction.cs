using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpAction : MonoBehaviour
{

    [SerializeField]
    private GameObject Apple, PickUpElement;

    void Update()
    {
        if(Apple.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.E))
            {
                GlobalPlayerData.HowManyElementsToPickUp++;
                PickedUpElement pickedUpElement = PickUpElement.GetComponent<PickedUpElement>();
                pickedUpElement.SetQuestText();
                Apple.SetActive(false);
            }
        }
        else
            PickUpElement.SetActive(false);
    }
}
