using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGCameraManager : MonoBehaviour
{
    public static RPGCameraManager SharedInstance = null;



    [HideInInspector]
    public CinemachineVirtualCamera VirtualCamera;



    public void Awake()
    {
        if (SharedInstance != null && SharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            SharedInstance = this;
        }



        VirtualCamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }
}
