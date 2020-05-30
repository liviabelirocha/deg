using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private RectTransform rectTransform;
    private int index = 0;
    [SerializeField] private Text[] options = new Text[4];

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
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
            if (index > 3) index = 0;
            Movement(index);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index--;
            if (index < 0) index = 3;
            Movement(index);

        }
    }

    private void Movement(int i = 0)
    {
        rectTransform.position = new Vector2(options[i].rectTransform.position.x - options[i].rectTransform.sizeDelta.x / 2 - 100,
                                                 options[i].rectTransform.position.y + 5);
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
                    SceneManager.LoadScene("WorldMap");
                    break;
                case 2:
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }
    }
}
