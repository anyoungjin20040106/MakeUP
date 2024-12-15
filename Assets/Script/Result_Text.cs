using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result_Text : MonoBehaviour
{
    Text text;
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn=GameObject.Find("btn").GetComponent<Button>();
        text=GetComponent<Text>();
        text.text=Result.name;
        btn.onClick.AddListener(()=>{
            SceneManager.LoadScene("Title");
        });
    }
}
