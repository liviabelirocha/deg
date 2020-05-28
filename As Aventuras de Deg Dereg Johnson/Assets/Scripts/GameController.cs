using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool lostHealth = false;

    public void LoseHealth()
    {
        if (!lostHealth)
        {
            lostHealth = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene("WorldMap");
    }
}
