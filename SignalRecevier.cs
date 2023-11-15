using UnityEngine;
using UnityEngine.SceneManagement;

public class SignalRecevier : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    public void LoadNewScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void showTittle()
    {
        canvas.SetActive(true);
    }
  
}
