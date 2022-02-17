using UnityEngine;
using System.Collections;

public class Enemy_Follow2 : MonoBehaviour
{
    public Transform Player;
    public float f_RotSpeed = 3.0f, f_MoveSpeed = 1.0f;
    public Animator animEnemy;
    public bool grabbed = false;
    public Vector3 grabLoc;
    public bool thrown = false;
    public bool pushed = false;
    public bool pushruned = false;

    public float throwBegin;
    public float throwEnd;
    float throwTime = 0;

    public float grabTimer = 0;
    public float throwPlayerTime = 2.0f;
    public float resetTime = 5.0f;

    public float pushBegin = 1.2f;
    public float pushEnd = 3.0f;
    public float pushresetTime = 5.0f;
    float pushTime = 0;

    public float pushrunBegin = 1.0f;
    public float pushrunEnd = 4.0f;
    public float pushrunresetTime = 5.0f;
    float pushrunTime = 0;


    public arrowKM playerScr;
    public Animator playerAnim;

    public HealthBar healthBarscr;

    public int moveDir = 1;
    [HideInInspector]
    public bool scoreIncreased = false;
    public Transform enemyWanted;
    public Transform playerWanted;

    public GameObject PP;
    public GameObject EE;

    public AudioMananger audioManager;
    public bool audioPlayed = false;
    
    void FixedUpdate()
    {
        if ((Vector3.Distance(Player.position, this.transform.position)) > 1.5f && grabbed == false)
        {
            transform.position += (new Vector3(moveDir * 1.0f,0.0f,0.0f)) * f_MoveSpeed * Time.deltaTime;
        }
        else if (pushed == true)
        {
            scoreIncreased = true;
            pushTime += Time.deltaTime;
            if (pushTime > pushBegin && pushTime < pushEnd)
            {
                animEnemy.SetBool("pushed", true);
                transform.position = new Vector3(transform.position.x + moveDir * -0.004f, transform.position.y, transform.position.z);
            }
            else if (pushTime > pushresetTime)
            {
                scoreIncreased = false;
                pushTime = 0;
                pushed = false;
                grabbed = false;
                grabTimer = 0f;
                playerScr.grabbed = false;
                animEnemy.SetBool("pushed", false);
                playerAnim.SetInteger("attack", 0);
                //audioPlayed = true;
                playerAnim.SetBool("grabbed", false);
                animEnemy.SetBool("grabbed", false);
            }
        }
        else if (thrown == true)
        {
            scoreIncreased = true;
            throwTime += Time.deltaTime;
            if (throwTime > throwBegin && throwTime < throwEnd)
            {
                transform.position = new Vector3(transform.position.x + moveDir * 0.03f, transform.position.y, transform.position.z);
            }
            else if (throwTime > resetTime)
            {
                scoreIncreased = false;

                throwTime = 0;
                thrown = false;
                grabbed = false;
                grabTimer = 0f;
                playerScr.grabbed = false;
                animEnemy.SetBool("thrown", false);
                playerAnim.SetInteger("attack", 0);
                //audioPlayed = true;
                playerAnim.SetBool("grabbed", false);
                animEnemy.SetBool("grabbed", false);
                transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                Player.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                playerScr.moveDir *= -1;
                moveDir *= -1;
            }
        }

        else if (pushruned == true)
        {
            scoreIncreased = true;
            animEnemy.SetBool("pushruned", true);
            pushrunTime += Time.deltaTime;
            if (pushrunTime > pushrunBegin && pushrunTime < pushrunEnd)
            {
                transform.position = new Vector3(transform.position.x - moveDir * 0.03f, transform.position.y, transform.position.z);

            }
            else if (pushrunTime > pushrunresetTime)
            {
                scoreIncreased = false;
                pushrunTime = 0;
                pushruned = false;
                grabbed = false;
                grabTimer = 0f;
                playerScr.grabbed = false;
                animEnemy.SetBool("pushruned", false);
                playerAnim.SetInteger("attack", 0);
                //audioPlayed = true;
                playerAnim.SetBool("grabbed", false);
                animEnemy.SetBool("grabbed", false);
                //transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                // Player.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                //playerScr.moveDir *= -1;
                //moveDir *= -1;
            }
        }


        else if(grabbed == true)
        {
            if (playerScr.thrown == false && playerScr.pushruned == false && playerScr.pushed == false)
                transform.position = Vector3.Lerp(transform.position, grabLoc, 0.1f);
            animEnemy.SetBool("grabbed", true);

            grabTimer += Time.deltaTime;
            if ((grabTimer > throwPlayerTime) && (healthBarscr.level == 1))
            {
                playerScr.pushed = true;
                animEnemy.SetInteger("attack", 1);

                if(!audioPlayed)
                {
                    audioManager.Play("Lose");
                    Debug.Log("Played");
                    audioPlayed = true;
                }
                
            }
            else if ((grabTimer > throwPlayerTime) && (healthBarscr.level == 2))
            {
                //transform.position = a;
                playerScr.thrown = true;
                animEnemy.SetInteger("attack", 2);

                if (!audioPlayed)
                {
                    audioManager.Play("Lose");
                    Debug.Log("Played");
                    audioPlayed = true;
                }

            }
            else if ((grabTimer > throwPlayerTime) && (healthBarscr.level == 3))
            {
                playerScr.pushruned = true;
                animEnemy.SetInteger("attack", 3);

                if (!audioPlayed)
                {
                    audioManager.Play("Lose");                    
                    audioPlayed = true;
                }


            }

        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "theobjectToIgnore")
        {
            Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), collision.collider);
        }
    }

    /*public void enemyReset()
    {
        transform.position = enemyWanted.position;
        Player.transform.position = playerWanted.position;;
        throwTime = 0;
        thrown = false;
        grabbed = false;
        grabTimer = 0f;
        playerScr.grabbed = false;
        animEnemy.SetBool("thrown", false);
        playerAnim.SetInteger("attack", 0);
        playerAnim.SetBool("grabbed", false);
        animEnemy.SetBool("grabbed", false);

        scoreIncreased = false;
        pushTime = 0;
        pushed = false;
        animEnemy.SetBool("pushed", false);
        playerAnim.SetInteger("attack", 0);
        playerAnim.SetBool("grabbed", false);
        animEnemy.SetBool("grabbed", false);

        pushrunTime = 0;
        pushruned = false;
        animEnemy.SetBool("pushruned", false);
        playerAnim.SetInteger("attack", 0);
        playerAnim.SetBool("grabbed", false);
        animEnemy.SetBool("grabbed", false);

        if(thrown == true)
        {
            transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
            Player.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        }
       
    }*/

    public void enemyReset()
    {
        PP.SetActive(false);
        EE.SetActive(false);
    }

    public void tt()
    {
        PP.SetActive(true);
        EE.SetActive(true);
    }
}   