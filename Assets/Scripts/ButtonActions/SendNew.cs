using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class scriptSendNew : MonoBehaviour
{
    private string url = "http://localhost:52052/api/AppConnect/GetTestJson/";

    public void SendNew()
    {
        StartCoroutine(RequestResponse());
    }

    IEnumerator RequestResponse()
    {
        //RequestTestJsonObj to = new RequestTestJsonObj(22, "REQUEST", 77);
        //var toj = JsonUtility.ToJson(to);

        using (UnityWebRequest request = UnityWebRequest.Get(url + "SOME MSG"))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var answer = JsonConvert.DeserializeObject<RequestTestJsonSimpleObj>(request.downloadHandler.text);
                //Show results as text
                Debug.Log(request.downloadHandler.text);

                var ro = answer;

            }
        }
    }



}
