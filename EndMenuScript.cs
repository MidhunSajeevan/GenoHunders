using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuScript :MonoBehaviour
{
    [SerializeField] private GameObject WinpopUp;
    public void play()
    {
      
        SceneManager.LoadScene("scene_2");
        WinpopUp.SetActive(false);
    }
    public void stop()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

}
