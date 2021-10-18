using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    void LateUpdate()
    {
        Vector3 me = new Vector3((player.transform.position).x, (player.transform.position).y, 0.0f);
        transform.position = me + offset;
    }
}