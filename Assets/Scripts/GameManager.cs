using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;

    //Class
    [SerializeField] BirdSpawner spawner;
    [SerializeField] TextManager text;

    //Objects
    [SerializeField] GameObject gameOverScreen;

    //Stats
    int level;
    int ducksShot;
    int pigeonsShot;
    int totalShots;
    int minimumKillCount = 5;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ducksShot - pigeonsShot >= minimumKillCount)
        {
            IncreaseLevel();
            spawner.KillAllBirds();
            ducksShot = 0;
            pigeonsShot = 0;
            totalShots = 0;
            minimumKillCount += 2;
            text.DirtyBirdText();
            text.DirtyShotsText();
        }

        if (totalShots >= minimumKillCount + Mathf.Floor(10 / minimumKillCount))
        {
            gameOver = true;
            gameOverScreen.SetActive(true);
        }
    }

    public void ShotDuck()
    {
        ducksShot++;
        text.DirtyBirdText();
    }

    public void ShotPigeon()
    {
        pigeonsShot++;
        text.DirtyBirdText();
    }

    public void IncreaseLevel()
    {
        level++;
        text.DirtyLevelText();
    }

    public void IncreaseTotalShots()
    {
        totalShots++;
        text.DirtyShotsText();
    }

    public int GetMinimumBirds()
    {
        return minimumKillCount;
    }

    public int GetDucksShot()
    {
        return ducksShot;
    }

    public int GetPigeonsShot()
    {
        return pigeonsShot;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetTotalShots()
    {
        return totalShots;
    }
}
