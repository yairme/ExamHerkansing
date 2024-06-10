using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Movement Move;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move.TurnDirection(Direction.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move.TurnDirection(Direction.LEFT);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move.TurnDirection(Direction.DOWN);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move.TurnDirection(Direction.UP);
        }
    }
}
