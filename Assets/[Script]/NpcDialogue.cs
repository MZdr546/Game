using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject NPC_UI, Hint, QuestCanvas;
    [SerializeField]
    private bool QuestNpc;
    [SerializeField]
    private List<string> NpcLines, NpcLineQuest, NpcLineComplitedQuest, NpcLineKillQuest, NpcLineComplitedKillQuest;
    [SerializeField]
    private TMP_Text DialogueText;
    [SerializeField]
    private GameObject NPC;
    [SerializeField]
    private GameObject[] NPCDestination;
    [SerializeField]
    private GameObject ToDestroy;
    [SerializeField]
    private GameObject[] EnemyTerritory, TeleportCollider;
    [SerializeField]
    private Image image;

    [SerializeField]
    private NPC_Dialogue[] _npcDialogues;

    [SerializeField]
    private List<GameObject> teleports;

    private bool _firstQuestDone = false;

    private bool _firstConversation = true;
    private bool _complitedQuest = false;
    private bool _startedConversation = false;
    int _lines = 0;
    public int _teleports = 0;
    bool _going = false;

    public Animator animator;
    public GameObject _camera;
    private Cinemachine.CinemachineBrain cinemachineBrain;
    private PlayerMovement _player;
    private ThirdPersonCam thirdPersonCam;
    public NpcController npcController;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _player = player.GetComponent<PlayerMovement>();
        thirdPersonCam = _camera.GetComponent<ThirdPersonCam>();
        cinemachineBrain = _camera.GetComponent<CinemachineBrain>();

        NPC_UICanvas nPC_UICanvas = NPC_UI.GetComponent<NPC_UICanvas>();
        nPC_UICanvas.Initiate(_player, thirdPersonCam, cinemachineBrain);

        GlobalPlayerData.HowManyElementsToPickUp = 0;
        GlobalPlayerData.EnemyKilled = 0;
        _teleports = 0;

        SetDialogue();

    }

    public void SetDialogue()
    {
        NpcLines.Clear();
        NpcLines = _npcDialogues[_teleports].NpcLines;

        NpcLineQuest.Clear();
        NpcLineQuest = _npcDialogues[_teleports].NpcLineQuest;

        NpcLineComplitedQuest.Clear();
        NpcLineComplitedQuest = _npcDialogues[_teleports].NpcLineComplitedQuest;

        NpcLineKillQuest.Clear();
        NpcLineKillQuest = _npcDialogues[_teleports].NpcLineKillQuest;

        NpcLineComplitedKillQuest.Clear();
        NpcLineComplitedKillQuest = _npcDialogues[_teleports].NpcLineComplitedKillQuest;
    }


    public void LevelComplited()
    {
        Debug.Log("level complited");

        NavMeshAgent navMeshAgent = NPC.GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(teleports[_teleports].transform.position);
        GlobalPlayerData.EnemyKilled = 0;
        GlobalPlayerData.HowManyElementsToPickUp = 0;
        GlobalPlayerData.PlayerHealth += 10;
        GlobalPlayerData.PlayerAttack += 1;

        _player.SetHealthLoad();

        
        _teleports++;
        GlobalPlayerData.level = _teleports;

        _firstConversation = true;
        _complitedQuest = false;
        _startedConversation = false;
        _firstQuestDone = false;

        SetDialogue();
    }

    private void OnEnable()
    {
        _lines = 0;
        FirstLine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (_startedConversation)
            {
                NextLine();
                
            }
            else
            {
                Hint.SetActive(false);
                NPC_UI.SetActive(true);
                FirstLine();
                _startedConversation = true;
            }
            
        }

        if(_going)
        {
            CheckDistance();
        }
        
    }

    public void CheckDistance()
    {
        float distance = Vector3.Distance(NPC.transform.position, NPCDestination[_teleports].transform.position);
        if (_going)
        {
            //Debug.Log(distance);
            NPC.transform.LookAt(NPCDestination[_teleports].transform.position);

            if (distance < 2f)
            {
                _going = false;
                animator.SetBool("Running", false);
                NavMeshAgent navMeshAgent = NPC.GetComponent<NavMeshAgent>();
                navMeshAgent.isStopped = true;
                navMeshAgent.ResetPath();

            }
        }
    }


    public void FirstLine()
    {

        if (NpcLines.Count == 0)
        {
            DialogueText.text = "Hello";
        }
        else
            NextLine();
        
    }
    
    public void NextLine()
    {
        
        if (_firstConversation)
        {

            if (_lines < NpcLines.Count)
            {
                DialogueText.text = NpcLines[_lines];
                _lines++;
            }
            else
            {
                if (QuestNpc)
                    _firstConversation = false;
                NPC_UI.SetActive(false);
                
                _startedConversation = false;
                QuestCanvas.SetActive(true);



            }
        }
        else
        {
            if (!_complitedQuest)
            {
                if (GlobalPlayerData.HowManyElementsToPickUp == 5)
                {

                    if (_lines < NpcLineComplitedQuest.Count)
                    {
                        DialogueText.text = NpcLineComplitedQuest[_lines];
                        _lines++;
                    }
                    else
                    {
                        _complitedQuest = true;
                        NPC_UI.SetActive(false);
                        
                        QuestCanvas.SetActive(false);
                        _startedConversation = false;


                        if (NPC != null)
                        {
                            NavMeshAgent navMeshAgent = NPC.GetComponent<NavMeshAgent>();
                            if (NPCDestination != null)
                            {
                                _going = true;
                                Debug.Log(navMeshAgent.isOnNavMesh);
                                navMeshAgent.isStopped = false;
                                navMeshAgent.SetDestination(NPCDestination[_teleports].transform.position);
                                animator.SetBool("Running", true);
                                if (!GlobalPlayerData.questBeach)
                                {
                                    GlobalPlayerData.questBeach = true;
                                   
                                }
                                else
                                {
                                    if (!GlobalPlayerData.questVillage)
                                    {
                                        
                                        GlobalPlayerData.questVillage = true;
                                        
                                    }
                                    else
                                    {
                                        if (!GlobalPlayerData.questForest)
                                        {
                                            GlobalPlayerData.questForest = true;
                                            
                                        }
                                    }
                                }


                            }
                        }
                    }
                }
                else
                {

                    if (_lines < NpcLineQuest.Count)
                    {
                        DialogueText.text = NpcLineQuest[_lines];
                        _lines++;
                    }
                    else
                    {
                        NPC_UI.SetActive(false);
                        
                        _startedConversation = false;

                        _firstQuestDone = true;

                    }
                }
            }
            else
            {
                if (GlobalPlayerData.EnemyKilled >= 3)
                {



                    if (_lines < NpcLineComplitedKillQuest.Count)
                    {
                        DialogueText.text = NpcLineComplitedKillQuest[_lines];
                        _lines++;
                    }
                    else
                    {
                        NPC_UI.SetActive(false);
                        
                        QuestCanvas.SetActive(false);
                        _startedConversation = false;

                        if (!GlobalPlayerData.questKillBeach)
                        {
                            DestroyStones();
                        }
                        else
                        {
                            if (!GlobalPlayerData.questKillVillage)
                            {
                                TeleportCollider[_teleports].SetActive(true);
                            }
                            else
                            {
                                if (!GlobalPlayerData.questKillForest)
                                {
                                    TeleportCollider[_teleports].SetActive(true);
                                }
                            }
                        }

                        LevelComplited();
                    }
                }
                else
                {
                    
                    if (_lines < NpcLineKillQuest.Count)
                    {

                        DialogueText.text = NpcLineKillQuest[_lines];
                        _lines++;
                    }
                    else
                    {
                        if (!EnemyTerritory[_teleports].active)
                            EnemyTerritory[_teleports].SetActive(true);

                        NPC_UI.SetActive(false);
                        
                        QuestCanvas.SetActive(false);
                        _startedConversation = false;


                    }
                    
                }
            }
            
        }

    }


    public void DestroyStones()
    {

        Destroy(ToDestroy);
        TeleportCollider[_teleports].SetActive(true);
        GlobalPlayerData.questKillBeach = true;

    }

}
