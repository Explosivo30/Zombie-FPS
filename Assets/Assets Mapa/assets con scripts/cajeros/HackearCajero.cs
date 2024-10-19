using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HackearCajero : MonoBehaviour
{

    public GameObject PressButtonUI;
    public GameObject Cajero;
    Monedero Monedero;


    public int randomMonenyMin = 100;
    public int randomMonenyMax = 200;
    public int receivemoney;

    private bool dentrotrigger = false;
    private bool YaHackeado = false;

    public float TimeToHack = 10f;

    public bool TimerOn = false;

    [SerializeField] TextMeshProUGUI TimerTxt;

    // Start is called before the first frame update
    void Awake()
    {
        Monedero = GameObject.Find("Monedero").GetComponent<Monedero>();
    }


    // Update is called once per frame
    void Update()
    {
        if (dentrotrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && !YaHackeado)
            {
                Invoke("Hakeando", 0f);
                TimerOn = true;
            }
        }

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
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentrotrigger = true;
            PressButtonUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentrotrigger = false;
            PressButtonUI.SetActive(false);
        }
    }
    private void Hakeando()
    {
        YaHackeado = true;
        Invoke("FInalizaHackeo", TimeToHack);
    }
    private void FInalizaHackeo()
    {
        receivemoney = Random.Range(randomMonenyMin, randomMonenyMax);
        Monedero.monedasActual += receivemoney;
        Destroy(PressButtonUI);
        Destroy(TimerTxt);
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
