using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_UICanvas : MonoBehaviour
{
    private Cinemachine.CinemachineBrain _cinemachineBrain;
    private PlayerMovement _player;
    private ThirdPersonCam _thirdPersonCam;


    private void OnEnable()
    {
       
        _cinemachineBrain.enabled = false;
        _player.enabled = false;
        _thirdPersonCam.enabled = false;
     

    }

    private void OnDisable()
    {
        
        _cinemachineBrain.enabled = true;
        _player.enabled = true;
        _thirdPersonCam.enabled = true;
        
    }

    public void Initiate(PlayerMovement playerMovement, ThirdPersonCam thirdPersonCam, CinemachineBrain cinemachineBrain)
    {
        _player = playerMovement;
        _thirdPersonCam = thirdPersonCam;
        _cinemachineBrain = cinemachineBrain;

    }

}
