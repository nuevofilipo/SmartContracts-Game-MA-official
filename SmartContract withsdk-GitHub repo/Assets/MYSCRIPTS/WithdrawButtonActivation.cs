using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WithdrawButtonActivation : MonoBehaviour
{
    [SerializeField] GameObject _withdrawButton;

    string chain = "binance";
    string network = "testnet";
    string contract = "0x5f310227dd9a9e65DaEb9d92282E27DD0eFcA02E";

    int counter = 0;


    float timer = 0f; // variable to keep track of the elapsed time

    async void Update()
    {
        timer += Time.deltaTime; // increment the timer by the time elapsed since the last frame

        // check if the timer has reached 3 seconds
        if (timer >= 3f)
        {
            timer = 0f; // reset the timer

            //string account = PlayerPrefs.GetString("Account");
            string account = "0x035dCD3b056BdDbf82273A1b93c7B8cd25614995";
            BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
            print(balanceOf);

            if (balanceOf > 50000 & counter == 0)
            {
                _withdrawButton.SetActive(true);
                counter++;
            }
            else { }
        }
    }
}
