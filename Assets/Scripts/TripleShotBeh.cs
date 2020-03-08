using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotBeh : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private bool Collected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        destroy();
        
    }
    void movement()
    {
        transform.Translate(new Vector3(0, -3, 0)*Time.deltaTime);
    }
    void destroy()
    {
        if (this.gameObject.transform.position.y < 6.1f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            Collected = true;
        }
    }
}
