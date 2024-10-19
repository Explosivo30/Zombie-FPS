using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monedero : MonoBehaviour
{
    public int monedasActual;
    public int maxMoney = 1000;
    [SerializeField] TextMeshProUGUI MoneyText;
    [SerializeField] TextMeshProUGUI MaxMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        monedasActual = 0;
    }

    void Update()
    {
        MoneyText.text = "" + monedasActual;
        if (monedasActual >= maxMoney)
        {
            monedasActual = maxMoney;
            MaxMoneyText.text = "You can not take more money leave it in the van.";
        }
        if (monedasActual < maxMoney)
        {
            MaxMoneyText.text = "";
        }
    }
}
