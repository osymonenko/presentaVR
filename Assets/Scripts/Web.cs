using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class Web : MonoBehaviour
{
    public string name;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
    }

    IEnumerator GetDate()
    {
        RequestTestJsonObj to = new RequestTestJsonObj(1, "First", 5);
        var toj = JsonUtility.ToJson(to);
        //Debug.Log("sending string Json(tostring): " + toj.ToString());
        string url = "http://localhost:52052/api/AppConnect/GetTestJson/";


        using (UnityWebRequest request = UnityWebRequest.Get(url + "Tratata"))
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

                //Or retrieve results as binary data
                //byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:52052/Account/Login", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

public class RequestTestJsonObj
{
    public int id { get; set; }
    public string name { get; set; }
    public int vpNum { get; set; }

    public RequestTestJsonObj(int id1, string name1, int vpNum1)
    {
        id = id1;
        name = name1;
        vpNum = vpNum1;
    }
}

public class RequestTestJsonSimpleObj
{
    public string id { get; set; }

}
