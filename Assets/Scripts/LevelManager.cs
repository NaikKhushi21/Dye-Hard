using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to update the UI text
    void UpdateLevelUI()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }

    // Call this method when the level changes
    public void ModifyLevel()
    {
        // TODO
    }
}
