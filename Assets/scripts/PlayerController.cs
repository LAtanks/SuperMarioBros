using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    [Space(5)]
    public float gravity;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public int life_count;
    [Space(5)]
    public float speed;
    public float minSpeed = 3f;
    public float maxSpeed = 5f;
    [Space(5)]
    public float jumpAmount;
    public float jumpTimeCounter;
    public float jumpTime;
     
    [Header("Sounds Effects")]
    public AudioClip deadStx;
    public AudioClip invicibilityStx;
    public AudioClip jumpSfx;
    public AudioClip ouchSfx;
    public AudioSource as_sfx;
    public AudioSource as_stx;

    [Header("Ground")]
    public Transform feetPos;
    public float checkRadiusg;
    public LayerMask groundMask;

    [Header("Wall")]
    public Transform sidesPos;
    public float checkRadius;
    public LayerMask wallMask;

    bool isGround;
    public bool isCrounch;
    bool walk, walk_left, walk_right, down, jump_up, jump_down, jump, running;
    private Vector2 velocity;
    private bool isJumping;
    private void Start()
    {
        gameObject.transform.localScale = new Vector2(1f, 1f);
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGround = Physics2D.OverlapCircle(feetPos.position, checkRadiusg, groundMask);
        CheckPlayerInput();
        Moviment();
        Jump();
    }
    void CheckPlayerInput()
    {
        bool input_left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("Horizontal") < 0);
        bool input_rigth = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || (Input.GetAxis("Horizontal") > 0);
        bool input_down = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || (Input.GetAxis("Vertical") < 0);
        bool input_running = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2);
        bool input_jump = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.JoystickButton1);
        bool inputDown_jump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.JoystickButton1);
        bool inputUp_jump = Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.JoystickButton1);

        down = input_down;
        walk = input_left || input_rigth;
        walk_left = !input_rigth || input_left;
        walk_right = !input_left || input_rigth;
        running = input_running && walk;
        jump = input_jump;
        jump_down = inputDown_jump;
        jump_up = inputUp_jump;
    }

    private void Moviment()
    {
        Vector3 pos = transform.localPosition;

        if (down) isCrounch = true;
        else isCrounch = false;

        if (walk)
        {
            if (walk && running) speed = maxSpeed;
            else speed = minSpeed;
            if (walk_left)
            {
                pos.x -= speed * Time.deltaTime;
                sr.flipX = false;
            }
            if (walk_right)
            {
                pos.x += speed * Time.deltaTime;
                sr.flipX = true;
            }

        }
        transform.localPosition = pos;
    }
    private void Jump()
    {

        float jumpForce = Mathf.Sqrt(this.jumpAmount * -2 * (Physics2D.gravity.y * rb.gravityScale));

        if (isGround)
        {
            rb.gravityScale = gravityScale;
        }
        else if (!isGround)
        {
            rb.gravityScale = fallingGravityScale;
        }

        if (jump_down && isGround)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector2.up * jumpAmount * Time.deltaTime);
            as_sfx.clip = jumpSfx;
            as_sfx.Play();
            as_sfx.loop = false;
        }
        if (jump && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpAmount;
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }
        if (jump_up)
        {
            isJumping = false;
        }
              
    }
    public void Hit()
    {
        as_sfx.clip = ouchSfx;
        as_sfx.Play();
        life_count--;
        StartCoroutine(HitDamager());
        if(life_count == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
    public IEnumerator HitDamager()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(.10f);
        sr.color = Color.white;
    }
}
