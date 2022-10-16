using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getAccount : MonoBehaviour
{

    public Text myAccount;
    // Start is called before the first frame update
    void Start()
    {
        string account = PlayerPrefs.GetString("Account");
        myAccount.text = account;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
