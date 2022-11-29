using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAgainActivation : MonoBehaviour
{
    [SerializeField] GameObject _withdrawButton;
    [SerializeField] GameObject _playAgainButton;


    string chain = "binance";
    string network = "testnet";
    string contract = "0xBB7DFc1aBbd94d53648e9DF1F7584B898b1D57C2";

    int counter = 0;


    async void Update()
    {

        string account = PlayerPrefs.GetString("Account");
        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf);



        if (balanceOf <= 5000000 & counter == 0 & _withdrawButton.activeSelf)
        {

            _playAgainButton.SetActive(true);
            counter++;
        }
        else { }

    }
}
