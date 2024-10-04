using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public TextMeshProUGUI levelText;
    public Dictionary<int, int> levelMilestones = new Dictionary<int, int>()
    {
        { 1, 100 },
        { 2, 300 },
        { 3, int.MaxValue }
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateLevelUI()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }

    public void LevelUp()
    {
        currentLevel += 1;
        UpdateLevelUI();
    }
}
