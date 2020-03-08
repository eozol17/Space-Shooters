using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour
{
    public float BullSpeed = 9.4f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.up * BullSpeed * Time.deltaTime);
        if (transform.position.y >= 6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
