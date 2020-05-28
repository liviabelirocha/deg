using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direction { Up, Down, Left, Right }

public class Node : MonoBehaviour
{
    private Animator animator;

    public string SceneToLoad;

    [Header("Nodes")]
    [SerializeField] private Node UpNode;
    [SerializeField] private Node DownNode;
    [SerializeField] private Node LeftNode;
    [SerializeField] private Node RightNode;

    public bool enabled = false;
    private Dictionary<Direction, Node> nodeDirections;

    private void Start()
    {
        animator = GetComponent<Animator>();

        nodeDirections = new Dictionary<Direction, Node>
        {
            {Direction.Up, UpNode},
            {Direction.Down, DownNode},
            {Direction.Left, LeftNode},
            {Direction.Right, RightNode},
        };
    }

    private void Update()
    {
        animator.SetBool("enabled", enabled);
    }

    public Node GetNodeInDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up: return UpNode;
            case Direction.Down: return DownNode;
            case Direction.Left: return LeftNode;
            case Direction.Right: return RightNode;
            default: throw new ArgumentOutOfRangeException("direction", direction, null);
        }
    }

    public Node GetNextNode(Node node)
    {
        return nodeDirections.FirstOrDefault(x => x.Value != null && x.Value != node).Value;
    }
}
