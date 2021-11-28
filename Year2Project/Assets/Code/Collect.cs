using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public string ID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerCollider"))
        {
            PlayerPrefs.SetInt(ID, PlayerPrefs.GetInt(ID + 1));
            Destroy(gameObject);
        }
    }
}
