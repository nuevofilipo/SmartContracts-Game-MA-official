using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfDeposited : MonoBehaviour
{
    [SerializeField] GameObject _enterButton;

    public Text tokenBalance;
    public int resultBalance;
    async void Start()
    {
        string chain = "binance";
        string network = "testnet";
        string contract = "0xBB7DFc1aBbd94d53648e9DF1F7584B898b1D57C2";
        string account = PlayerPrefs.GetString("Account");

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        int resultBalance = (int)balanceOf;
        print(resultBalance);
        tokenBalance.text = balanceOf.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (resultBalance > 5000)
        {
            _enterButton.SetActive(true);
        }

    }
}
