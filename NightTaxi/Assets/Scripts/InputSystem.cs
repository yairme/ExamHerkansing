using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Movement Move;
    [SerializeField] private UIManager UI;
    private bool Pause = false;
    void Update()
    {
        if (!Pause)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Move.TurnDirection(Direction.RIGHT);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Move.TurnDirection(Direction.LEFT);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Move.TurnDirection(Direction.DOWN);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Move.TurnDirection(Direction.UP);
            }
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape))
            {
                UI.PauseButton();
                Pause = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape))
            {
                UI.ResumeButton();
                Pause = false;
            }
        }

    }
}
