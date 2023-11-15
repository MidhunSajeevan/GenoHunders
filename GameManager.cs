using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagement : MonoBehaviour
{
    

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
   
}
