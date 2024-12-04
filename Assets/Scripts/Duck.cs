using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    bool isDuck; //if false then its a pigeon
    [SerializeField] float speed;

    [SerializeField] Rigidbody2D rig;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitiateBird(bool newIsDuck, float newSpeed)
    {
        isDuck = newIsDuck;
        speed = newSpeed;
        if (isDuck)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5396226f, 0.3171603f, 0.1455963f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 8)
        {
            direction = -1;
        }
        else if (transform.position.x <= -8)
        {
            direction = 1;
        }
        rig.velocity = Vector3.right * direction * speed;
    }
}
