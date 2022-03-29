using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator anim;
    public int MaxHP;
    public int MaxMP;
    public int Damage;
    public int CurrentHP;
    public int CurrentMP;
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpPower;
    public float maxSpeed;
    private Rigidbody2D rigid;
    public SpriteRenderer sprite;
    RaycastHit2D rayHit;
    public ScriptManager scriptManager;
    public GameObject savePanel;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!savePanel.activeSelf && !scriptManager.isAction && anim.GetBool("Start") && !anim.GetBool("Die") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Character-Wake") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Character-Sleep"))
        {
            if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);
            }
            else if (Input.GetButtonDown("Jump") && !anim.GetBool("isDoubleJumping"))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(Vector2.up * jumpPower * 0.8f, ForceMode2D.Impulse);
                anim.SetBool("isDoubleJumping", true);
            }

            if (rigid.velocity.y <= 0)
            {
                anim.SetBool("Falling", true);
                if (math.abs(rigid.velocity.y) >= maxSpeed)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, -maxSpeed);
                }
                //Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));

                rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 3, LayerMask.GetMask("Platform"));

                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 2)
                    {
                        anim.SetBool("isJumping", false);
                        anim.SetBool("isDoubleJumping", false);
                        anim.SetBool("Falling", false);
                    }
                }
            }
            else {
                anim.SetBool("Falling", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (anim.GetBool("Start") && !anim.GetBool("Die") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Character-Wake") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Character-Sleep"))
        {
            float inputX = scriptManager.isAction || savePanel.activeSelf ? 0 : Input.GetAxis("Horizontal");
            float inputY = scriptManager.isAction || savePanel.activeSelf ? 0 : Input.GetAxis("Vertical");
            // -1 ~ 1

            float fallSpeed = rigid.velocity.y; // 떨어지는 속도 저장
            if (inputX > 0)
            {
                if (!anim.GetBool("isJumping"))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        anim.SetBool("Walk", true);
                        anim.SetBool("Run", false);
                    }
                    else
                    {
                        anim.SetBool("Run", true);
                        anim.SetBool("Walk", false);
                    }
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (inputX < 0)
            {
                if (!anim.GetBool("isJumping"))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        anim.SetBool("Walk", true);
                        anim.SetBool("Run", false);
                    }
                    else
                    {
                        anim.SetBool("Run", true);
                        anim.SetBool("Walk", false);
                    }
                }
                transform.localScale = new Vector3(1, 1, 1);
            }
            else {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
            }
            Vector2 velocity = new Vector2(inputX, inputY);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity.x *= walkingSpeed;
            }
            else {
                velocity.x *= runningSpeed;
            }
            velocity.y = fallSpeed; // 떨어지는 속도 초기화
            rigid.velocity = velocity;
        }
    }
}
