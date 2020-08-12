using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    //We want this script to serve 3 purposes:
        // 1) Count 1 money for every popped balloon
        // 2) Display available money as a text
        // 3) Police the ability to purchase towers, and subtract money when purchase is complete

    private string moneyUIText;
    //public Button towerItemInCart;//this we want to set at runtime. will be set to the tower corresponding to the button we select from the menu
    //public MonkeyPowers monkeyMoneyStats;//we will pull a price from this script; when the location is selected, the tower will be placed, and money will be "spent"
    public Money()
    {
        //Default Constructor

    }
    public int MoneyCounter { get; set; } = 250;

    private void Start()
    {
        moneyUIText = MoneyCounter.ToString();
        gameObject.GetComponent<Text>().text = moneyUIText;

    }
    private void Update()
    {
        moneyUIText = MoneyCounter.ToString();
        gameObject.GetComponent<Text>().text = moneyUIText;

    }
}
