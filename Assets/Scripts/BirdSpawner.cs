using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] GameObject InstantiableDuck;
    [SerializeField] List<GameObject> birds = new List<GameObject>();

    [SerializeField] int activeBirds = 0;

    [SerializeField] GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject newBird = Instantiate(InstantiableDuck);
            newBird.SetActive(false);
            newBird.transform.parent = transform;
            birds.Add(newBird);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBirds < 10)
        {
            SpawnBirdFromPool();
            activeBirds++;
        }
    }

    public void KillBird()
    {
        activeBirds--;
    }

    public void KillAllBirds()
    {
        activeBirds = 0;
        foreach (GameObject bird in birds)
        {
            bird.SetActive(false);
        }
    }

    void SpawnBirdFromPool()
    {
        int birdIndex = 0;

        //Returns the first inactive bird it finds
        foreach (GameObject bird in birds)
        {
            if (!bird.activeSelf)
            {
                birdIndex = birds.IndexOf(bird);
                break;
            }
        }

        bool isDuck = Random.Range(0, 4) != 0;

        if (isDuck)
        {
            birds[birdIndex].name = "Duck";
        }
        else
        {
            birds[birdIndex].name = "Pigeon";
        }
        birds[birdIndex].GetComponent<Duck>().InitiateBird(isDuck, 1 * Random.Range(0.7f, 1.3f) + game.GetLevel());

        birds[birdIndex].transform.position = new Vector3 (-8,Random.Range(0f,4f),0);

        birds[birdIndex].SetActive(true);
    }
}
