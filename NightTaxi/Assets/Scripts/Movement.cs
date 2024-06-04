using UnityEngine;

public enum State
{
    UP,DOWN, LEFT, RIGHT
}
public enum Direction
{
    BASE, LEFT, RIGHT
}
public class Movement : MonoBehaviour
{
    [SerializeField]private float BaseSpeed;
    private float PlayerSpeed;
    private State Stating = State.DOWN;
    private Direction Pref = Direction.BASE;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * PlayerSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rigth();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Down();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Up();
        }
    }
    private void Rigth()
    {
        switch (Stating)
        {
            case State.UP:
                Pref = Direction.RIGHT;
                break;
            case State.DOWN:
                Pref = Direction.LEFT;
                break;
            case State.LEFT:
                transform.Rotate(Vector3.up * 180.0f);
                PlayerSpeed = BaseSpeed;
                break;
            case State.RIGHT:
                return;
        }
        Stating = State.RIGHT;
    }
    private void Left()
    {
        switch (Stating)
        {
            case State.UP:
                Pref = Direction.LEFT;
                break;
            case State.DOWN:
                Pref = Direction.RIGHT;
                break;
            case State.RIGHT:
                transform.Rotate(Vector3.up * 180.0f);
                PlayerSpeed = BaseSpeed;
                break;
            case State.LEFT:
                return;
        }
        Stating = State.LEFT;
    }
    private void Down()
    {
        switch (Stating)
        {
            case State.UP:
                transform.Rotate(Vector3.up * 180.0f);
                PlayerSpeed = BaseSpeed;
                break;
            case State.RIGHT:
                Pref = Direction.RIGHT;
                break;
            case State.LEFT:
                Pref = Direction.LEFT;
                break;
            case State.DOWN:
                return;
        }
        Stating = State.DOWN;
    }
    private void Up()
    {
        switch (Stating)
        {
            case State.DOWN:
                transform.Rotate(Vector3.up * -180.0f);
                PlayerSpeed = BaseSpeed;
                break;
            case State.LEFT:
                Pref = Direction.RIGHT;
                break;
            case State.RIGHT:
                Pref = Direction.LEFT;
                break;
            case State.UP:
                break;
        }
        Stating = State.UP;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hitInfo, 10))
        {
            PlayerSpeed = 0;
            // call function
        }

        if (Pref == Direction.LEFT)
        {
            if(!Physics.Raycast(transform.position, Vector3.left, out RaycastHit hitInf, 10))
            {
                transform.Rotate(Vector3.up * -90.0f);
            }
        }
        if (Pref == Direction.RIGHT)
        {
            if (!Physics.Raycast(transform.position, Vector3.right, out RaycastHit hitIn, 10))
            {
                transform.Rotate(Vector3.up * 90.0f);
            }
        }
    }
}
