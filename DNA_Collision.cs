using UnityEngine;
using UnityEngine.SceneManagement;
public class DNA_Collision : MonoBehaviour
{
    [SerializeField] GameObject DetailMenu;
    bool collided=false;
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && collided)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       DetailMenu.SetActive(true);
        collided = true;
    }
    
    
}
