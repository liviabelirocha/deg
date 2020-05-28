﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private Node startNode;
    [SerializeField] private Text currentLevel;

    private void Awake()
    {
        startNode.enabled = true;
    }

    private void Start()
    {
        character.Initialize(this, startNode);
    }

    private void Update()
    {
        if (character.isMoving) return;
        CheckForInput();
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
        currentLevel.text = string.Format("Nível: {0}", character.currentNode.SceneToLoad);
    }
}
