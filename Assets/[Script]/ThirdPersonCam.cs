using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform Orientation;
    public Transform Player;
    public Transform PlayerObj;
    public Rigidbody Rigidbody;

    public float RotationSpeed;

    [SerializeField]
    private CinemachineFreeLook cinemachineFree;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        Orientation.forward = viewDir.normalized;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = Orientation.forward * vertical + Orientation.right * horizontal;

        if (inputDir != Vector3.zero)
            PlayerObj.forward = Vector3.Lerp(PlayerObj.forward, inputDir.normalized, Time.deltaTime + RotationSpeed);

    }

}
