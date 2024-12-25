using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    Button btn;
    Text text;
    bool isClick;
    // Start is called before the first frame update
    void Start()
    {
        isClick = false;
        btn = GetComponent<Button>();
        text = transform.GetChild(0).GetComponent<Text>();
        btn.onClick.AddListener(() =>
        {
            if (!isClick)
                StartCoroutine(Capture());
        });
    }
    IEnumerator Capture()
    {
        isClick = true;
        yield return new WaitForEndOfFrame();
        var colors = btn.colors;
        colors.normalColor = new Color(1, 1, 1, 0);
        btn.colors = colors;
        text.text = "";
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();
        colors.normalColor = new Color(1, 1, 1, 1);
        text.text = "분석중";
        btn.colors = colors;
        StartCoroutine(Response(texture.EncodeToJPG()));
    }
    IEnumerator Response(byte[] img)
    {
        WWWForm form = new WWWForm();
        form.AddBinaryData("img", img, "img.jpg");
        using (UnityWebRequest www = UnityWebRequest.Post(Result.URL+"predict", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Result.result = www.downloadHandler.text;
                StartCoroutine(SetFace());
            }
            else
            {
                text.text = "분석실패";
                isClick = false;
            }
        }
    }
    
    IEnumerator SetFace()
    {
        string textureUrl = Result.URL + Result.img;
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(textureUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"텍스처 다운로드 실패: {www.error}");
                text.text = "분석실패";
                isClick = false;
                yield break;
            }
            Result.face= ((DownloadHandlerTexture)www.downloadHandler).texture;
            SceneManager.LoadScene("Result");
        }
    }
}