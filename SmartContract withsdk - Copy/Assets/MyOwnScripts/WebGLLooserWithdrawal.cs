using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

#if UNITY_WEBGL
public class WebGLLooserWithdrawal : MonoBehaviour
{
    [SerializeField]
    private string contract = "0xd75F5371Da7BD82fC228C5735cDf96d8361c629B";

    [SerializeField]
    private string _amount = "5000000000000000000";
    private readonly string abi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"inputs\":[],\"name\":\"IGToken\",\"outputs\":[{\"internalType\":\"contract ERC20Token\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"USDc\",\"outputs\":[{\"internalType\":\"contract ERC20Token\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"depositTokens\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"hasTransferred\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"players\",\"outputs\":[{\"internalType\":\"address payable\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"stakingBalance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_amount\",\"type\":\"uint256\"}],\"name\":\"withdrawalSecond\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_amount\",\"type\":\"uint256\"}],\"name\":\"withdrawalWinner\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";

    async public void withdrawalLooser()
    {
        // smart contract method to call
        string method = "withdrawalSecond";
        // array of arguments for contract
        string[] obj = { _amount };
        string args = JsonConvert.SerializeObject(obj);
        // value in wei
        string value = "0";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to send a transaction
        try
        {
            string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
            Debug.Log(response);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }
}
#endif