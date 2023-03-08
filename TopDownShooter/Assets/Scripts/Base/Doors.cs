using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "ShopDoorIn":
                this.gameObject.transform.position -= new Vector3(13.5f, 0);
                break;
            case "ShopDoorOut":
                this.gameObject.transform.position += new Vector3(13.5f, 0);
                break;
            case "BlackSmithDoorIn":
                this.gameObject.transform.position += new Vector3(13.5f, 0);
                break;
            case "BlackSmithDoorOut":
                this.gameObject.transform.position -= new Vector3(13.5f, 0);
                break;
            case "PurpleDoorIn":
                this.gameObject.transform.position += new Vector3(0, 12f);
                break;
            case "PurpleDoorOut":
                this.gameObject.transform.position -= new Vector3(0, 12f);
                break;
            default:
                break;
        }
    }
}
