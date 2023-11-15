using UnityEngine;
using UnityEngine.SceneManagement;
public class HelicopterCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
