
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [SerializeField] private GameObject WinpopUp;
    PlayerMovement PlayerMovement;
    private void Update()
    {
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
     
        if (CheckCondition())
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            ShowWinPopUp();
          
        }
    }
    bool CheckCondition()
    {
       
        return PlayerMovement.IsPlayerDead;
    }
     void ShowWinPopUp()
    {
     
        WinpopUp.SetActive(true);
    }
    public void play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("scene_2");
        WinpopUp.SetActive(false);
    }
    public void stop()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
    
  
}
