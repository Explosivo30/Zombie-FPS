using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public float TimeToHack = 600f;

    public bool TimerOn = false;

    [SerializeField] TextMeshProUGUI TimerTxt;

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeToHack > 0)
            {
                TimeToHack -= Time.deltaTime;
                updateTimer(TimeToHack);
            }
            else
            {
                TimeToHack = 0;
                TimerOn = false;
                Invoke("GameOver", 1f);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void GameOver()
    {
        //Canviar escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
