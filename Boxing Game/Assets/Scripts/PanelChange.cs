using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel1;
    public GameObject Panel2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        FindObjectOfType<AudioMananger>().Play("Crowd");
        FindObjectOfType<AudioMananger>().Play("BGM");
    }
}
 