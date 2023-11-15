
using UnityEngine;
using UnityEngine.SceneManagement;
public class scene1ended : MonoBehaviour
{
    [SerializeField]
    GameObject LabName;
    [SerializeField]
    GameObject chek1;
    [SerializeField]
    GameObject chek2; 
    [SerializeField]
    GameObject chek3;


    public void scene1_Ended()
    {
        chek3.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LabReached()
    {
        LabName.SetActive(true);
    }
    public void cheakpoint1Reached()
    {
        LabName.SetActive(false);
        chek1.SetActive(true);

    }
    public void cheakpoint2Reached()
    {
        chek1.SetActive(false);
        chek2.SetActive(true);
    }
    public void cheakpoint3Reached()
    {
        chek2.SetActive(false);
        chek3.SetActive(true);
    }
}
