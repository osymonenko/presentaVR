using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class scriptSendNew : MonoBehaviour
{
    [SerializeField] private Text text;

    private string url = "http://localhost:52052/api/AppConnect/GetTestJson/";
    private string msg = "NEW MODEL CREATION(JSON HERE)";

    private float progress;

    private void Start()
    {
        StartCoroutine(WWWRoutine());
    }

    private IEnumerator WWWRoutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + msg);
        var asyncOperation = www.SendWebRequest();

        while (!www.isDone)
        {
            progress = asyncOperation.progress;
            yield return null;
        }

        progress = 1f;

        if (!string.IsNullOrEmpty(www.error))
        {
            //Some error occured
        }

        text.text = www.downloadHandler.text;

    }
}
