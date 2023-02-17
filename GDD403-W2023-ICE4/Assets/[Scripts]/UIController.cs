using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TMP_Dropdown difficultyDropdown;
    public Difficulty difficulty;


    // Start is called before the first frame update
    void Start()
    {
        difficultyDropdown = FindObjectOfType<TMP_Dropdown>();
        difficulty = Difficulty.EASY;
    }

    public void OnDifficulty_Changed()
    {
        difficulty = (Difficulty)difficultyDropdown.value;
    }
}
