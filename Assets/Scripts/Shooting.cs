using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameManager game;
    [SerializeField] GameObject shotMarker;
    [SerializeField] BirdSpawner spawner;

    bool inverted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !game.gameOver)
        {
            game.IncreaseTotalShots();
            Vector3 pos;
            Collider2D hit = Commands.Shoot(inverted, out pos);

            shotMarker.transform.position = pos;

            if (inverted == true)
            {
                inverted = false;
            }

            if (hit)
            {
                if (hit.name == "Duck")
                {
                    game.ShotDuck();
                }
                else if (hit.name == "Pigeon")
                {
                    game.ShotPigeon();
                    inverted = true;
                }
                hit.gameObject.SetActive(false);
                spawner.KillBird();
            }
        }
    }
}
