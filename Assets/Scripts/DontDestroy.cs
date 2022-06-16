using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject music;
    private static DontDestroy _instance;

    void Start()
    {
        music = GameObject.Find("Music");
    }

    // Update is called once per frame
    void Awake()
    {
        if (!_instance)
            _instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(transform.gameObject);
    }


}
