using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class account_info : MonoBehaviour
{

    public Text playerAccount;
    // Start is called before the first frame update
    void Start()
    {
        string account = PlayerPrefs.GetString("Account");
        playerAccount.text = account;
        print(account);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
