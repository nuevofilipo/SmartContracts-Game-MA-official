using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ERC20BalanceOfExample : MonoBehaviour
{

    public Text tokenBalance;
    async void Start()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0x281b6DDD31b86D4F564fff336f69fA1B004Ef694";
        string account = PlayerPrefs.GetString("Account");

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf);
        tokenBalance.text = balanceOf.ToString();
    }
}
