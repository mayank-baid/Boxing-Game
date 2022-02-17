using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartButton;
    void Start()
    {
        StartCoroutine(ButtonShow());
    }

    IEnumerator ButtonShow()
    {
        yield return new WaitForSeconds(1.8f);
        StartButton.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        
    }
}
