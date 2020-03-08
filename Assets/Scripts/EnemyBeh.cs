using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeh : MonoBehaviour
{
    [SerializeField]
    private float Espeed = 2.4f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject Laser;

    void Start()
    {

    }
    void Update()
    {
        Vector3 Mov = new Vector3(0, -1 * Espeed, 0);
        transform.Translate(Mov * Time.deltaTime);
        if (transform.position.y < -6)
        {

            float Sx = randomNumber(-9.5f, 9.5f);
            transform.position = new Vector3(Sx, 5.5f, 0);
        }
    }
    public float randomNumber(float min, float max)
    {
        Random random = new Random();
        return Random.Range(min, max);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            PlayerBeh player = other.transform.GetComponent<PlayerBeh>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }           
    }
}
