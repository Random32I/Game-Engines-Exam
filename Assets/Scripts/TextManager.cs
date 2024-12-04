using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] GameManager game;

    //Dirty Flags
    bool isbirdTextDirty = true;
    bool islevelTextDirty = true;
    bool isShotsTextDirty = true;

    //Texts
    [SerializeField] TextMeshProUGUI BirdText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI ShotsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isbirdTextDirty)
        {
            BirdText.text = $"{game.GetDucksShot() - game.GetPigeonsShot()}/{game.GetMinimumBirds()}";
            isbirdTextDirty = false;
        }

        if (islevelTextDirty)
        {
            LevelText.text = $"Level {game.GetLevel() + 1}";
            islevelTextDirty = false;
        }

        if (isShotsTextDirty)
        {
            ShotsText.text = $"Shots: {game.GetTotalShots()}/{game.GetMinimumBirds() + Mathf.Floor(10 / game.GetMinimumBirds())}";
            isShotsTextDirty = false;
        }
    }

    public void DirtyBirdText()
    {
        isbirdTextDirty = true;
    }

    public void DirtyLevelText()
    {
        islevelTextDirty = true;
    }

    public void DirtyShotsText()
    {
        isShotsTextDirty = true;
    }
}
