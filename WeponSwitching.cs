using UnityEngine;


public class WeponSwitching : MonoBehaviour
{
    public int selectedWepon = 0;
    
 
    void Start()
    {
       
        selectwepon();
    }

    void Update()
    {
       
        int previousSelectedWepon=selectedWepon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWepon >= transform.childCount-1) 
                selectedWepon = 0;
            else
                selectedWepon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWepon <= 0)
                selectedWepon = transform.childCount - 1;
            else
                selectedWepon--;
        }
        if (selectedWepon != previousSelectedWepon)
            selectwepon();
    }
    void selectwepon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWepon)
                weapon.gameObject.SetActive(true);
            else 
                weapon.gameObject.SetActive(false); 
            i++;
        }

    }
}
