using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
    }

    IEnumerator GetDate()
    {
        TestObjForJson to = new TestObjForJson(1, "First", 5);
        var toj = JsonUtility.ToJson(to);
        Debug.Log("sending string is: " + "TRATATA");
        string url = "http://localhost:52052/api/AppConnect/GetTestJson/";


        using (UnityWebRequest www = UnityWebRequest.Post(url + "Tratata", string.Empty))
        {


            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                //Debug.Log(www.downloadHandler.ToString());

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

public class TestObjForJson
{
    public int id;
    public string name;
    public int vpNum;

    public TestObjForJson(int id1, string name1, int vpNum1)
    {
        id = id1;
        name = name1;
        vpNum = vpNum1;
    }
}
