using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool lostHealth = false;

    [SerializeField] private int levelToUnlock = 2;

    public void LoseHealth()
    {
        if (!lostHealth)
        {
            lostHealth = true;
            SceneManager.LoadScene("WorldMap");
        }
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene("WorldMap");
    }
}
