using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private int index = 0;
    [SerializeField] private Text[] options = new Text[2];

    private void Start()
    {
        Movement();
    }

    private void Update()
    {
        CheckMovement();
        CheckEnter();
    }

    private void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index++;
            if (index > 1) index = 0;
            Movement(index);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index--;
            if (index < 0) index = 1;
            Movement(index);
        }
    }

    private void Movement(int i = 0)
    {
        transform.position = new Vector2(options[i].transform.position.x - 2, options[i].transform.position.y);
    }

    private void CheckEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (index)
            {
                case 0:
                    PlayerPrefs.DeleteAll();
                    SceneManager.LoadScene("WorldMap");
                    break;
                case 1:
                    Application.Quit();
                    break;
            }
        }
    }
}
