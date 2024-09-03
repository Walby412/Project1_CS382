using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rounds : MonoBehaviour
{
    public ScoreCounter scoreCounter; // Reference to the ScoreCounter script
    public TextMeshProUGUI roundText; // Reference to the TextMeshProUGUI component for the round
    private int round = 1;
    private int pointsPerRound = 2000;
    private AppleTree appleTree;

    void Start()
    {
        appleTree = FindObjectOfType<AppleTree>(); // Find the AppleTree in the scene

        if (roundText == null)
        {
            Debug.LogError("Round Text component not found! Ensure this script is attached to a GameObject with a Text component.");
        }
        else
        {
            roundText.text = "Round: " + round.ToString(); // Initialize the round display
        }
    }

    void Update()
    {
        if (scoreCounter.score >= round * pointsPerRound)
        {
            IncreaseRound();
        }
    }

    // Function to increase the round and make the game harder
    private void IncreaseRound()
    {
        round++;
        UpdateRoundText();
        IncreaseDifficulty();
    }

    // Function to update the round display
    private void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Round: " + round.ToString();
        }
    }

    // Function to make the game harder
    private void IncreaseDifficulty()
    {
        if (appleTree != null)
        {
            appleTree.IncreaseDifficulty(round);
        }

        Debug.Log("Game gets harder! Round: " + round);
    }
}
