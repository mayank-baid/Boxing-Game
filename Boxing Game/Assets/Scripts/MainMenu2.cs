using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    //public GameObject StartButton;
    public GameObject mainmenu;
    // Start is called before the first frame update

    private void Start()
    {

        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
       // SceneManager.LoadScene("Game");
        mainmenu.SetActive(false);

        
    }
}
