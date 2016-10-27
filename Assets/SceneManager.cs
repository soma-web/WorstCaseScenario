using UnityEngine;
using System.Collections;
using System;

public class SceneManager : MonoBehaviour {

    public GameObject Train, Meteroit;
    public Camera _planeCam, _trainCam, _meteroitCam;
    public float meteoritVisibleTime = 2f;
    public static SceneManager Instance;

    void Awake()
    {
        Instance = this;
        Invoke("ChangeToPlaneCam", meteoritVisibleTime);
    }

    void ChangeToPlaneCam()
    {
        ChangeToCam(_planeCam);
    }

    void ChangeToCam(Camera cam)
    {
        _trainCam.enabled = false;
        _planeCam.enabled = false;
        _meteroitCam.enabled = false;
        cam.enabled = true;

    }

    public void MetalBirdLanded()
    {
        _planeCam.enabled = false;
        Train.SetActive(true);
        ChangeToCam(_trainCam);
    }

    internal void MeteroitHitMetalBird()
    {
        Meteroit.SetActive(false);
        Debug.Log("jashsakfhhfgjdghjsd");
        //_planeCam.enabled = true;
    }
}
