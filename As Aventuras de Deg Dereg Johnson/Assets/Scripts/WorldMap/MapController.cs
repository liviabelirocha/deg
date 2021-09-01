using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private CharacterController character = null;
    [SerializeField] private Node startNode = null;
    [SerializeField] private Text currentLevel = null;

    [SerializeField] private Node[] levels = new Node[2];

    [SerializeField] private Text healthText = null;


    private void Awake()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levels.Length; i++)
            if (i + 1 > levelReached) levels[i].enabled = false;
    }

    private void Start()
    {
        character.Initialize(this, startNode);
        healthText.text = FindObjectOfType<GameController>().GetHealth().ToString();
    }

    private void Update()
    {
        if (!character.isMoving) CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow)) character.TrySetDirection(Direction.Up);
        else if (Input.GetKeyUp(KeyCode.DownArrow)) character.TrySetDirection(Direction.Down);
        else if (Input.GetKeyUp(KeyCode.LeftArrow)) character.TrySetDirection(Direction.Left);
        else if (Input.GetKeyUp(KeyCode.RightArrow)) character.TrySetDirection(Direction.Right);
        else if (Input.GetKeyUp(KeyCode.Return)) SceneManager.LoadScene(character.currentNode.SceneToLoad);
    }

    public void UpdateGui()
    {
        currentLevel.text = string.Format("Nível : {0}", character.currentNode.SceneToLoad);
    }


}
