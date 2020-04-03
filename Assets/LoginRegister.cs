using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class LoginRegister : MonoBehaviour
{
    public GameObject email;
    public GameObject password;
    public GameObject LoginButtonObj;
    public GameObject RegisterButtonObj;
    private string Email;
    private string Password;

    private string form;
    private bool EmailValid = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoginButton()
    {
        print("Login info sended.");
    }

    public void RegisterButton()
    {
        print("Register info sended.");
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
                LoginButton();
        }

        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }



    //if all is OK...
    //Application.LoadLevel("Start level");

}
