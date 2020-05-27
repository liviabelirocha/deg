using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public bool isMoving { get; private set; }
    public Node currentNode { get; private set; }
    private Node target;
    private MapController mapController;

    public void Initialize(MapController mapController, Node startNode)
    {
        this.mapController = mapController;
        SetCurrentNode(startNode);
    }

    private void SetCurrentNode(Node node)
    {
        currentNode = node;
        target = null;
        transform.position = node.transform.position;
        isMoving = false;
        mapController.UpdateGui();
    }

    private void Update()
    {
        if (target == null || !target.enabled) return;

        var currentPosition = transform.position;
        var targetPosition = target.transform.position;

        if (Vector2.Distance(currentPosition, targetPosition) > .02f)
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, Time.deltaTime * speed);
        else SetCurrentNode(target);
    }


    public void TrySetDirection(Direction direction)
    {
        var node = currentNode.GetNodeInDirection(direction);
        if (node == null) return;
        MoveToNode(node);
    }

    private void MoveToNode(Node node)
    {
        target = node;
        isMoving = true;
    }
}