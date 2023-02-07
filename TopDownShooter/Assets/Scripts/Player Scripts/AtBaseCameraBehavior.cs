using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtBaseCameraBehavior : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject playerBody;

    void Update()
    {
        _camera.transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y, _camera.transform.position.z);
    }
}
