using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class LoginTest : MonoBehaviour
{
    WWWForm form;

    public TMP_InputField username;
    public TMP_InputField password;

    public TextMeshProUGUI errorMessage;

    [SerializeField] string url;
    public void OnLoginButtonClicked()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        form = new WWWForm();

        form.AddField("username", username.text);
        form.AddField("password", password.text);

        WWW w = new WWW(url, form);
        yield return w;

        if (w.error != null)
        {
            errorMessage.text = "error in the server";
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("message"))
                {
                    errorMessage.text = "Invalid username or password";
                }
                else
                {
                    print("Telah Login");
                }
            }
        }
    }
}
