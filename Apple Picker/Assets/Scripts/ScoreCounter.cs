using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TextMeshProUGUI uiText;
    // Start is called before the first frame update
    void Start() {
        // Attempt to get the Text component
        uiText = GetComponent<TextMeshProUGUI>();
        
        if (uiText == null) {
            Debug.LogError("Text component not found! Ensure this script is attached to a GameObject with a Text component.");
        } else {
            uiText.text = score.ToString("#,0"); // Initialize the score display
        }
    }

    void Update() {
        if (uiText != null) {
            uiText.text = score.ToString("#,0"); // Continuously update the score
        }
    }
}
