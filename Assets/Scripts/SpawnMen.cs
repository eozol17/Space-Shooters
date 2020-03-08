using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMen : MonoBehaviour
{
    [SerializeField]
    private float spwnTime = 5;
    [SerializeField]
    private float nxtSpawn;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int spawned = 0;
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerBeh player1 = player.transform.GetComponent<PlayerBeh>();

        if (player1.isAlive() == true)
        {
            if(spawned < 10)
            {
                float nxtSpawn = randomNess(1f, 2f);
                float xR = randomNess(-9.5f, 9.5f);
                if (Time.time >= spwnTime)
                {
                    spwnTime = Time.time + nxtSpawn;
                    GameObject newEnemy = Instantiate(enemy, new Vector3(xR, 5, 0), Quaternion.identity);
                    newEnemy.transform.parent = container.transform;
                    spawned++;
                }
            }
               
            else if(spawned >= 10)
            {
                float nxtSpawn = randomNess(0.2f, 1f);
                float xR = randomNess(-9.5f, 9.5f);
                if (Time.time > spwnTime)
                {
                    spwnTime = Time.time + nxtSpawn;
                    GameObject newEnemy = Instantiate(enemy, new Vector3(xR, 5, 0), Quaternion.identity);
                    newEnemy.transform.parent = container.transform;
                    spawned++;
                }
            }

        }
    }
   public float randomNess(float min, float max)
    {
        Random random = new Random();
        return Random.Range(min, max);
    }
}
