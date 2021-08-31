using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private int health = 2;

    [SerializeField] private int levelToUnlock = 2;

    void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public int GetHealth()
    {
        return health;
    }

    public void LoseHealth()
    {
        health--;

        if (health != 0)
            SceneManager.LoadScene("WorldMap");
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }

    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene("WorldMap");
    }
}
