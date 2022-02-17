using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamchaMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hero;
    public GameObject game;
    public float speed;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hero.transform.position = Vector3.MoveTowards(hero.transform.position, gameObject.transform.position, speed);
        if(hero.transform.position==gameObject.transform.position)
        {
            hero.SetActive(false);
            game.SetActive(true);

        }
        
    }
}
