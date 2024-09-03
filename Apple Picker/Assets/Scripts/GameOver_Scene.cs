using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Scene : MonoBehaviour
{
    public void OnResetButton(){
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton(){
        Application.Quit();
    }
}
