using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class puertaBanco : MonoBehaviour
{
    public GameObject Taladro;
    public GameObject PuertaBanco;
    public GameObject PressButtonUI;

    public float TimeToDrill = 10f;
    private bool dentrotrigger = false;

    public bool TimerOn = false;

    //public Text TimerTxt;
    [SerializeField] TextMeshProUGUI TimerTxt;

    void Start()
    {
        Taladro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dentrotrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Invoke("Drill", 0f);
                TimerOn = true;
            }
        }
        if (TimerOn)
        {
            if (TimeToDrill > 0)
            {
                TimeToDrill -= Time.deltaTime;
                updateTimer(TimeToDrill);
            }
            else
            {
                TimeToDrill = 0;
                TimerOn = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { dentrotrigger = true;
            PressButtonUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { dentrotrigger = false; 
         PressButtonUI.SetActive(false); }
    }

    private void Drill()
    {
        Taladro.SetActive(true);
        Invoke("OpenDoor", TimeToDrill);
    }
    private void OpenDoor()
    {
        Taladro.SetActive(false);
        Destroy(PressButtonUI);
        PuertaBanco.transform.Rotate(0f, 182f, 0.0f, Space.Self);
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}   
