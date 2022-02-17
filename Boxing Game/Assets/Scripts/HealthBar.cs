using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    // Health Bar
    public Image healthbarfill;
    public Image healthCircle;
    public Image healthSymbol;
    public Sprite[] HealthCircle;
    public Sprite[] HealthSymbol;

    // Panels Control
    public GameObject InitialGameOverPanel;
    public GameObject FinalGameOverPanel;
    public GameObject FinalGameEndPanel;
    public GameObject InitialGameEndPanel;
    public GameObject[] PlayModeThings;
    public GameObject ScoreUI;
    public Enemy_Follow2 enemy;
    // Play Video

    //public Text LevelText;
    public TMP_Text LevelText2;
    public int level;
    private float timeRemaining;
    private float maxtime;

    public OnlineVideoLoader vv;
    public GameObject gameOver;

    public MyButton fwdbutton;
    public MyButton backbutton;

    public GameObject RenderImage;
    public GameObject audiomanager;
    int flag;

    private bool healthIncreased = false;
    void Start()
    {
        healthCircle.sprite = HealthCircle[0];
        healthSymbol.sprite = HealthSymbol[0];
        //level = 1;
        timeRemaining = 60f;
        maxtime = timeRemaining;

        flag=0;
        
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            float health = timeRemaining / maxtime;
            if (health < .2f)
            {
                healthCircle.sprite = HealthCircle[2];
                healthSymbol.sprite = HealthSymbol[1];
            }
            else if (health < .5)
            {
                healthCircle.sprite = HealthCircle[1];
                healthbarfill.color = Color.Lerp(Color.red, Color.yellow, health * 2f);
            }
            else
            {
                healthCircle.sprite = HealthCircle[0];
                healthSymbol.sprite = HealthSymbol[0];

                healthbarfill.color = Color.Lerp(Color.yellow, Color.green, (health - .5f) * 2f);
            }
            healthbarfill.fillAmount = (1.0f / maxtime) * timeRemaining;
            timeRemaining -= Time.deltaTime;
            flag=0;
        }
        else
        {
            fwdbutton.buttonPressed = false;
            backbutton.buttonPressed = false;


            if (level != 3)
            {
                if(flag==0)
                {
                    if(healthIncreased)
                    {
                        FinalGameOverPanel.SetActive(true);
                    }
                    else
                    {
                        InitialGameOverPanel.SetActive(true);
                    }
                    
                    foreach(var obj in PlayModeThings)
                    {
                        obj.SetActive(false);
                    }
                    ScoreUI.SetActive(true);
                    flag=1;
                }
                

            }
            else
            {
                if(flag==0)
                {
                    if (healthIncreased)
                    {
                        FinalGameEndPanel.SetActive(true);
                    }
                    else
                    {
                        InitialGameEndPanel.SetActive(true);
                    }
                    foreach(var obj in PlayModeThings)
                    {
                        obj.SetActive(false);
                    }
                    ScoreUI.SetActive(true);
                    flag=1;
                }
                

            }
        }
    }


    public void IncreaseHealth()
    {
        StartCoroutine(Health());
    }
    public IEnumerator Health()
    {
        RenderImage.SetActive(true);
        audiomanager.SetActive(false);
        vv.play();

        if (healthIncreased)
        {
            FinalGameOverPanel.SetActive(false);
        }
        else
        {
            InitialGameOverPanel.SetActive(false);
        }
        if (healthIncreased)
        {
            FinalGameEndPanel.SetActive(false);
        }
        else
        {
            InitialGameEndPanel.SetActive(false);
        }
        
        healthIncreased = true;
        ScoreUI.SetActive(false);
        yield return new WaitForSeconds(15);

        RenderImage.SetActive(false);
        audiomanager.SetActive(true);

        foreach(var obj in PlayModeThings)
        {
            obj.SetActive(true);
        }
        
        enemy.tt();

        vv.stop();

        if (level == 1)
        {            
            timeRemaining = 60f;
            maxtime = timeRemaining;
        }
        else if (level == 2)
        {
            timeRemaining = 45f;
            maxtime = timeRemaining;
        }
        else if (level == 3)
        {
            InitialGameEndPanel.SetActive(false);
            

            foreach(var obj in PlayModeThings)
            {
                obj.SetActive(true);
            }
            ScoreUI.SetActive(false);
            timeRemaining = 30f;
            maxtime = timeRemaining;
        }
        else
        {
            FinalGameEndPanel.SetActive(true);
            foreach (var obj in PlayModeThings)
            {
                obj.SetActive(false);
            }
            ScoreUI.SetActive(true);
        }

    }


    public void NextLevel()
    {
        level++;

        if (healthIncreased)
        {
            FinalGameOverPanel.SetActive(false);
        }
        else
        {
            InitialGameOverPanel.SetActive(false);
        }

        foreach (var obj in PlayModeThings)
            {
                obj.SetActive(true);
            }
        ScoreUI.SetActive(false);
        enemy.enemyReset();
        enemy.tt();

        if (level == 2)
        {
            
            LevelText2.text = "Round 2";
            healthIncreased = false;
            timeRemaining = 45f;
            maxtime = timeRemaining;
        }
        else if (level == 3)
        {

            LevelText2.text = "Round 3";
            healthIncreased = false;
            timeRemaining = 30f;
            maxtime = timeRemaining;
        }
        else
        {
            FinalGameEndPanel.SetActive(true);
            foreach (var obj in PlayModeThings)
            {
                obj.SetActive(false);
            }
            return;
        }
    }

    public void Restart()
    {

        level = 1;
        InitialGameEndPanel.SetActive(false);
        FinalGameEndPanel.SetActive(false);
        foreach (var obj in PlayModeThings)
        {
            obj.SetActive(true);
        }

        ScoreUI.SetActive(false);
        enemy.enemyReset();
        enemy.tt();

        LevelText2.text = "Round 1";
        healthIncreased = false;
        timeRemaining = 60f;
        maxtime = timeRemaining;
    }

}
