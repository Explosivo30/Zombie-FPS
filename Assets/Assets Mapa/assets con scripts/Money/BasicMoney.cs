using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoney : MonoBehaviour
{

    public GameObject PressButtonUI;
    public GameObject Dinero;
    Monedero Monedero;

    public int randomMonenyMin = 100;
    public int randomMonenyMax = 200;
    public int receivemoney;

    private bool dentrotrigger = false;
    private bool YaRecojido = false;

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
            if (Input.GetKeyDown(KeyCode.E) && !YaRecojido)
            {
                Invoke("Recojido", 0f);
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
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentrotrigger = false;
            PressButtonUI.SetActive(false);
        }
    }
    private void Recojido()
    {
        receivemoney = Random.Range(randomMonenyMin, randomMonenyMax);
        Monedero.monedasActual += receivemoney;
        Destroy(Dinero);
        Destroy(PressButtonUI);
        YaRecojido = false;
    }
}
