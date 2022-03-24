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
    public float speed;
    public float jumpPower;
    bool isJumping = false;
    bool isDoubleJumping = false;
    public float maxSpeed;
    private Rigidbody2D rigid;
    BoxCollider2D colider;
    RaycastHit2D rayHit;
    public ScriptManager scriptManager;
    public GameObject savePanel;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        colider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Start") && !anim.GetBool("Die") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Character-Wake") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Character-Sleep"))
        {
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
            }
            else if (Input.GetButtonDown("Jump") && !isDoubleJumping)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(Vector2.up * jumpPower * 0.8f, ForceMode2D.Impulse);
                isDoubleJumping = true;
            }

            if (rigid.velocity.y <= 0)
            {
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
                        isJumping = false;
                        isDoubleJumping = false;
                    }
                }
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
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (inputX < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            Vector2 velocity = new Vector2(inputX, inputY);
            velocity *= speed;
            velocity.y = fallSpeed; // 떨어지는 속도 초기화
            rigid.velocity = velocity;
        }
    }
}
