using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float timeduration = 2f * 60f;
    private float timer;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI firstsecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
    [SerializeField] private TextMeshProUGUI seperator;
    private PlayerMovement player;
    private float flashInterval = 0.1f; // Interval for the flashing effect
    private bool isFlashing = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        ResetTimer();   

    }

   
    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            Updatediplay(timer);
            if (timer < 6 && !isFlashing)
            {
                firstMinute.color = Color.red;
                secondMinute.color = Color.red;
                seperator.color = Color.red;
                firstsecond.color = Color.red;
                secondSecond.color = Color.red;
                isFlashing = true;
                StartCoroutine(FlashTimer());
            }

        }
        else
        {
            flash();
        }
            
   
    }
    private void ResetTimer()
    {
        timer = timeduration;
    }

    private void Updatediplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds=Mathf.FloorToInt(time % 60);

        string currentTime=string.Format("{00:00}{1:00}",minutes,seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstsecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();  
    }
    void flash()
    {
        if(timer !=0)
        {
            timer = 0;
            Updatediplay(timer);
            player.IsPlayerDead = true;
        }

    }

    private void settextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        secondSecond.enabled = enabled;
        firstsecond.enabled = enabled;
        seperator.enabled = enabled;    
    }
    IEnumerator FlashTimer()
    {
        while (isFlashing)
        {
            settextDisplay(false);
            yield return new WaitForSeconds(flashInterval);
            settextDisplay(true);
            yield return new WaitForSeconds(flashInterval);
        }
    }

}
