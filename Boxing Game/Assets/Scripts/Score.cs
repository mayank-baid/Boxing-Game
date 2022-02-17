using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;


public class Score : MonoBehaviour
{
   //public AudioSource happyHeroWinAudio;
    public TMP_Text score;
    public TMP_Text scoreshow;
    
    [HideInInspector]
    public static int scoreCount;

    [HideInInspector]
    public bool hit = true;

    public Animator playerAnim;
    public Animator enemyAnim;

    public arrowKM playerScr;
    public Enemy_Follow2 enemyScr;
    public Transform enemyTrans;    

    public HealthBar healthbar;

    public AudioMananger audioManager;


    private void Start()
    {
        scoreCount = 0;
        score.text = "Score: " + 0;
    }

    public void ScoreIncrease()
    {
        if (playerScr.grabbed == true && playerScr.pushed == false && healthbar.level ==1 && enemyScr.scoreIncreased == false)
        {
            
            scoreCount+=15;
            //happyHeroWinAudio.Play(0);
            enemyScr.pushed = true;
            audioManager.Play("Win");
            playerAnim.SetInteger("attack", 1);
            score.text = "Score: " + scoreCount;
            scoreshow.text = scoreCount.ToString();

        }
        else if (playerScr.grabbed == true && playerScr.thrown == false && healthbar.level == 2 && enemyScr.scoreIncreased == false)
        {
            
            scoreCount+=15;
            //happyHeroWinAudio.Play(0);
            enemyScr.thrown = true;
            audioManager.Play("Win");
            playerAnim.SetInteger("attack" , 2);
            enemyAnim.SetBool("thrown", true);
            score.text = "Score: " + scoreCount;
            scoreshow.text = scoreCount.ToString();

        }
        else if (playerScr.grabbed == true && playerScr.pushruned == false && healthbar.level == 3 && enemyScr.scoreIncreased == false)
        {
            
            scoreCount+=15;
            //happyHeroWinAudio.Play(0);
            enemyScr.pushruned = true;
            audioManager.Play("Win"); 
            playerAnim.SetInteger("attack" , 3);
            enemyAnim.SetBool("pushruned", true);
            score.text = "Score: " + scoreCount;
            scoreshow.text = scoreCount.ToString();

        }
        
    }

    public void ResetScore()
    {
        scoreCount = 0;
        score.text = "Score: " + scoreCount;
    }

    [DllImport("__Internal")]
    private static extern void GameOver(int scoreCount);

    public void SomeMethod()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
                    GameOver (scoreCount);
#endif

       
    }

}
