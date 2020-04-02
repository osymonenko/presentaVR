using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject email;
    public GameObject password;
    private string Email;
    private string Password;

    private string form;
    private bool EmailValid = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SendLogin()
    {
        print ("Login info sended.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Email != "")
                SendLogin();
        }

        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
