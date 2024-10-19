using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    Monedero Monedero;
    public GameObject PressButon;
    [SerializeField] TextMeshProUGUI TotalMoney;
    public int BotinTotal = 0;
    public bool dentrotrigger = false;

    // Start is called before the first frame update
    void Awake()
    {
        Monedero = GameObject.Find("Monedero").GetComponent<Monedero>();
    }

    void start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dentrotrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Invoke("RecibirDinero", 0f);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Invoke("Escapar", 1f);
            }
        }
        TotalMoney.text = "" + BotinTotal;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentrotrigger = true;
            PressButon.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentrotrigger = false;
            PressButon.SetActive(false);
        }
    }
    private void RecibirDinero()
    {
        BotinTotal += Monedero.monedasActual;
        Monedero.monedasActual = 0;
    }
    private void Escapar()
    {
        //Canviar escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
