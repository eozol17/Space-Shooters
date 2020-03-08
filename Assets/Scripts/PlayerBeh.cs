using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeh : MonoBehaviour
{
    //Data Types (int,float,bool,String)
    [SerializeField]
    private float DPX = 9f;
    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float DPY = 2.8f;
    [SerializeField]
    private float verticalInput;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float FireRate = 0.3f;
    [SerializeField]
    private float NextFire = -1f;
    [SerializeField]
    private int playerLives = 3;
    [SerializeField]
    private bool tripleShot;
    [SerializeField]
    private GameObject TripleShotPrefab;
    void start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        BasicMovement();
        fire();
    }



        void BasicMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 Movement = new Vector3(horizontalInput * DPX, verticalInput * DPY, 0);
        transform.Translate(Movement * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
        if (transform.position.x >= 10.250363f)
        {
            transform.position = new Vector3(-9.930363f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10.250363)
        {
            transform.position = new Vector3(9.930363f, transform.position.y, 0);
        }
    }
    bool CanFire()
    {
        if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            return true;
        }
        else
        {
            return false;
        }
    }

    void fire()
    {
       Vector3 IVec = new Vector3(transform.position.x, transform.position.y+0.824f, 0);
        if (Input.GetKeyDown(KeyCode.Space) && CanFire())
        {
            if(tripleShot == true)
            {
                Instantiate(TripleShotPrefab,transform.position, Quaternion.identity);
            }
            else Instantiate(BulletPrefab, IVec, Quaternion.identity);
        }
    }
    public bool isAlive()
    {
        if (playerLives > 0)
        {
            return true;
        }
        else return false;
    }
    public void Damage()
    {
        playerLives--;
        if(playerLives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
