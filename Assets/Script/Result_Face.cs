using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.ARFoundation;

public class Result_Face : MonoBehaviour
{
    ARFaceManager faceManager;
    // Start is called before the first frame update
    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
        faceManager.facePrefab.GetComponent<Renderer>().material.mainTexture=Result.face;
    }
}
