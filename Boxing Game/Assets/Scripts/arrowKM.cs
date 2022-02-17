using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowKM : MonoBehaviour
{
    public Animator anim;
    protected Rigidbody Rigidbody;
    public Transform enemy;
    public Enemy_Follow2 enemyScr;
    public bool grabbed;
    public float grabDist = 1.0f;
    float speed = 1;
    public bool thrown = false;
    public bool pushed = false;
    public bool pushruned = false;

    public float throwBegin = 1.4f;
    public float throwEnd = 4.0f;
    public float resetTime = 5.0f;
    float throwTime = 0;

    public float pushBegin = 1.2f;
    public float pushEnd = 3.0f;
    public float pushresetTime = 5.0f;
    float pushTime = 0;

    public float pushrunBegin = 0.5f;
    public float pushrunEnd = 4.0f;
    public float pushrunresetTime = 5.0f;
    float pushrunTime = 0;

    public Animator enemyAnim;
    public int moveDir = 1;

    public MyButton forward;
    public MyButton backward;

    [HideInInspector]
    public bool Pressed;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        grabbed = false;
    }

    void FixedUpdate()
    {
        
        if (pushed == true)
        {
            pushTime += Time.deltaTime;
            if (pushTime > pushBegin && pushTime < pushEnd)
            {
                anim.SetBool("pushed", true);
                transform.position = new Vector3(transform.position.x + moveDir * 0.004f, transform.position.y, transform.position.z);
            }
            else if (pushTime > pushresetTime)
            {
                pushTime = 0;
                pushed = false;
                grabbed = false;
                enemyScr.grabbed = false;
                enemyScr.grabTimer = 0.0f;
                enemyAnim.SetInteger("attack", 0);
                enemyScr.audioPlayed = false;
                anim.SetBool("pushed", false);
                anim.SetBool("grabbed", false);
                enemyAnim.SetBool("grabbed", false);
            }
        }
        else if (thrown == true)
        {
            anim.SetBool("thrown", true);
            throwTime += Time.deltaTime;
            if (throwTime > throwBegin && throwTime < throwEnd)
            {
                transform.position = new Vector3(transform.position.x - moveDir * 0.03f, transform.position.y, transform.position.z);
            }
            else if (throwTime > resetTime)
            {
                throwTime = 0;
                thrown = false;
                grabbed = false;
                enemyScr.grabbed = false;
                enemyScr.grabTimer = 0.0f;
                enemyAnim.SetInteger("attack", 0);
                enemyScr.audioPlayed = false;
                anim.SetBool("thrown", false);
                anim.SetBool("grabbed", false);
                enemyAnim.SetBool("grabbed", false);
                transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                enemy.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                enemyScr.moveDir *= -1;
                moveDir *= -1;
            }
        }
        if (pushruned == true)
        {
            anim.SetBool("pushruned", true);
            pushrunTime += Time.deltaTime;
            if (pushrunTime > pushrunBegin && pushrunTime < pushrunEnd)
            {
                transform.position = new Vector3(transform.position.x + moveDir * 0.012f, transform.position.y, transform.position.z);
            }
            else if (pushrunTime > resetTime)
            {
                pushrunTime = 0;
                pushruned = false;
                grabbed = false;
                enemyScr.grabbed = false;
                enemyScr.grabTimer = 0.0f;
                enemyAnim.SetInteger("attack", 0);
                enemyScr.audioPlayed = false;
                anim.SetBool("pushruned", false);
                anim.SetBool("grabbed", false);
                enemyAnim.SetBool("grabbed", false);
            }
        }
        else if (grabbed == true || System.Math.Abs(enemy.position.x - transform.position.x) <= grabDist)
        {
            /*if (backward.buttonPressed)
            {
               // Pressed = true;
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if(forward.buttonPressed)
            {
                //Pressed = true;
                transform.position += Vector3.right * speed * Time.deltaTime;
            }*/
            

            if (System.Math.Abs(enemy.position.x - transform.position.x) < 0.2)
            {
                grabbed = true;
            }
            
            Rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            enemyScr.grabbed = true;

            Vector3 grabLoc = transform.position;
            grabLoc.x = transform.position.x - 0.1f;
            enemyScr.grabLoc = grabLoc;

            anim.SetBool("grabbed", true);
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);

            if (backward.buttonPressed && grabbed==true)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                enemy.position += Vector3.left * speed * Time.deltaTime;
            }
            if (forward.buttonPressed && grabbed==true)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                enemy.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        else if (backward.buttonPressed)
        {
            anim.SetBool("isWalkingLeft", true);
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetFloat("direction", 1.0f);
        }
        else if (forward.buttonPressed)
        {
            anim.SetBool("isWalkingRight", true);
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetFloat("direction", 1.0f);
        }

        else
        {
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
        }

        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "theobjectToIgnore")
        {
            Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), collision.collider);
        }
    }



}
