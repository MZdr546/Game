using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool _readyToJump = true;

    public Animator _animator;

    [Header("Keybinds")]
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode AttackKey = KeyCode.Mouse0;
    public KeyCode wKey = KeyCode.W;
    public KeyCode sKey = KeyCode.S;
    public KeyCode aKey = KeyCode.A;
    public KeyCode dKey = KeyCode.D;

    bool _isRunning = false;

    [Header("Ground Check")]
    public float playerHight;
    public LayerMask Ground;
    bool _onGround;

    public Transform orientation;
    float horizontalInput, verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    public GameObject AttackGameObject;
    public AttackAction attackAction;
    public HealthBar healthBar;

    public GameObject JIMMY;

    private void Start()
    {
        SetAfterLoad();
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    
    public void SetAfterLoad()
    {
        SetHealthLoad();
        this.gameObject.transform.position = GlobalPlayerData.PlayerPlacement;

        NpcController npcController = JIMMY.GetComponent<NpcController>();
        npcController.Dialogue._teleports = GlobalPlayerData.level;

        NavMeshAgent navMeshAgent = JIMMY.GetComponent<NavMeshAgent>();

        navMeshAgent.Warp(GlobalPlayerData.JimmyPlacement);
    }
    public void SetHealthLoad()
    {
        healthBar.SetMaxHealth(GlobalPlayerData.PlayerHealth);
        
    }

    private void Update()
    {
        _onGround = Physics.Raycast(transform.position, Vector3.down, playerHight * 0.5f + 0.2f, Ground);

        MyInput();
        SpeedControl();

        if (_onGround)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (Input.GetKey(wKey) || Input.GetKey(sKey) || Input.GetKey(aKey) || Input.GetKey(dKey))
        {
            MovePlayer();

        }

        bool walking = (Input.GetKey(wKey) || Input.GetKey(sKey) || Input.GetKey(aKey) || Input.GetKey(dKey));
        _animator.SetBool("isRunning", walking);

        bool attack = Input.GetKey(AttackKey);
        _animator.SetBool("Attack",attack);
        
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(JumpKey) && _readyToJump && _onGround)
        {
            _readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);

        }

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if(!_isRunning)
            RunningAnimation();
        if (_onGround)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            
        }
        else
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        _readyToJump = true;
    }

    public void RunningAnimation()
    {
        _isRunning = true;
        _animator.SetBool("isRunning", _isRunning);
         
    }
}
