using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaitForIGToken : MonoBehaviour
{

    [SerializeField] GameObject _withdrawbutton;

    string chain = "binance";
    string network = "testnet";
    string contract = "0x5f310227dd9a9e65daeb9d92282e27dd0efca02e ";

    int counter = 0;


    async void Update()
    {

        string account = PlayerPrefs.GetString("Account");
        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf);



        if (balanceOf >= 5000000000000000000 & counter == 0)
        {
            _withdrawbutton.SetActive(true);
            counter++;
        }
        else { }

    }
}