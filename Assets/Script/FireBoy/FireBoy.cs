using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum FireBoyStateType
{
    Idle,Move,Jump,Air
}

public class FireBoy : MonoBehaviour
{
    private Animator[] anims;
    public Animator HeadAnim;
    public Animator LegAnim;
    public SpriteRenderer hsr;
    public SpriteRenderer lsr;
    public SpriteRenderer[] srs;
    public Rigidbody2D rd;
    public PlayerInput playerInput;

    public GameObject fire;
    public GameObject ice;
    public PhysicsMaterial2D yes;
    public PhysicsMaterial2D no;

    private Dictionary<FireBoyStateType, IState> states = new Dictionary<FireBoyStateType, IState>();
    private IState currentState;

    [Header("ÒÆ¶¯")]
    public bool isMove;
    public float moveSpeed;
    public Vector2 direction;

    [Header("ÌøÔ¾")]
    public bool isJump;
    public float jumpForce;

    [Header("ÏÂÂä×´Ì¬")]
    public bool isAir;

    [Header("Åö×²")]
    public Transform groundCheckPosition;
    public float groundCheckDistance;
    public LayerMask whatIsGround;

    public bool isIdle;

    public DropItem dropItem;



    private void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
        HeadAnim = anims[0];
        LegAnim = anims[1];
        srs = GetComponentsInChildren<SpriteRenderer>();
        hsr = srs[0];
        lsr = srs[1];
        rd = GetComponent<Rigidbody2D>();
        dropItem = GetComponent<DropItem>();

        states.Add(FireBoyStateType.Idle, new FireBoyIdleState(this));
        states.Add(FireBoyStateType.Move, new FireBoyMoveState(this));
        states.Add(FireBoyStateType.Jump, new FireBoyJumpState(this));
        states.Add(FireBoyStateType.Air, new FireBoyAirState(this));

        tranState(FireBoyStateType.Idle);
        playerInput.startPlayerInput();
    }
    private void OnEnable()
    {
        playerInput.onMove += onMove;
        playerInput.disMove += disMove;
        playerInput.onJump += onJump;
        playerInput.onTrans += onTrans;
    }
    private void OnDisable()
    {
        playerInput.onMove -= onMove;
        playerInput.disMove -= disMove;
        playerInput.onJump -= onJump;
        playerInput.onTrans -= onTrans;
    }
    public void onTrans()
    {
        if (fire.GetComponent<FireBoy>().isActiveAndEnabled)
        {
            ice.GetComponent<PolygonCollider2D>().sharedMaterial = no;
            fire.GetComponent<PolygonCollider2D>().sharedMaterial = yes;
            fire.GetComponent<FireBoy>().tranState(FireBoyStateType.Idle);
            ice.GetComponent<FireBoy>().enabled = true;
            fire.GetComponent<FireBoy>().enabled = false;
        }
        else
        {
            ice.GetComponent<PolygonCollider2D>().sharedMaterial = yes;
            fire.GetComponent<PolygonCollider2D>().sharedMaterial = no;
            ice.GetComponent<FireBoy>().tranState(FireBoyStateType.Idle);
            ice.GetComponent<FireBoy>().enabled = false;
            fire.GetComponent<FireBoy>().enabled = true;
        }
        
    }
    public void onJump()
    {
        if (currentState.returnName() == "idle" || currentState.returnName() == "move")
        {
            isJump = true;
            dropItem.generateDrop();
        }
            
    }
    public void disMove()
    {
        direction = Vector2.zero;
        isMove = false;
    }
    public void onMove(Vector2 dir)
    {
        isMove = true;
        direction = dir;
    }
    public void tranState(FireBoyStateType state)
    {
        if (currentState != null)
            currentState.onExit();
        currentState = states[state];
        currentState.onEnter();
    }
    private void Update()
    {
        currentState.onUpdate();
    }
    private void FixedUpdate()
    {
        currentState.onFixedUpdate();
    }
    public void move()
    {
        if (direction.magnitude > 0.99f)
        {
            rd.velocity = direction * moveSpeed;
            if (direction.x > 0)
            {
                hsr.flipX = false;
                lsr.flipX = false;
            }


            if (direction.x < 0)
            {
                hsr.flipX = true;
                lsr.flipX = true;
            }

        }
    }
    public void move1()
    {
        if (direction.magnitude > 0.99f)
        {
            rd.velocity = new Vector2(direction.x * moveSpeed, rd.velocity.y);
            if (direction.x > 0)
            {
                hsr.flipX = false;
                lsr.flipX = false;
            }


            if (direction.x < 0)
            {
                hsr.flipX = true;
                lsr.flipX = true;
            }

        }
    }
    public void die()
    {
        SceneManager.LoadScene("End");
    }
    public bool groundCheck()
    {
        return Physics2D.Raycast(groundCheckPosition.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPosition.position, new Vector2(groundCheckPosition.position.x, groundCheckPosition.position.y - groundCheckDistance));
    }
}
