using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpElementSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PickUpElements;
    [SerializeField]
    private List<Vector3> PickUpElementsPositions;

    [UnityEngine.ContextMenu("Click")]
    public void Yup()
    {
        
        for (int i = 0; i < PickUpElements.Length; i++)
        {
            Vector3 placement = PickUpElements[i].transform.position;
            PickUpElementsPositions.Add(placement);
        }
    }
}
