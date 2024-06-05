using UnityEngine;
public enum Direction
{
    UP,DOWN, LEFT, RIGHT
}
public enum Turn
{
    BASE, LEFT, RIGHT
}
public class Movement : MonoBehaviour
{
    [SerializeField] private float BaseSpeed;
    [SerializeField] private float WallDistance;
    private float PlayerSpeed;
    private Direction CurentDirection = Direction.UP;
    private Direction TempDirection;
    private Turn Pref = Turn.BASE;

    private void Start()
    {
        PlayerSpeed = BaseSpeed;
    }

    void FixedUpdate()
    {
        transform.Translate(PlayerSpeed * Time.deltaTime * Vector3.forward);
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
        switch (CurentDirection)
        {
            case Direction.UP:
                Pref = Turn.RIGHT;
                break;
            case Direction.DOWN:
                Pref = Turn.LEFT;
                break;
            case Direction.LEFT:
                Turning(Turn.BASE);
                CurentDirection = Direction.RIGHT;
                return;
            case Direction.RIGHT:
                return;
        }
       TempDirection = Direction.RIGHT;
    }

    private void Left()
    {
        switch (CurentDirection)
        {
            case Direction.UP:
                Pref = Turn.LEFT;
                break;
            case Direction.DOWN:
                Pref = Turn.RIGHT;
                break;
            case Direction.RIGHT:
                Turning(Turn.BASE);
                CurentDirection = Direction.LEFT;
                return;
            case Direction.LEFT:
                return;
        }
        TempDirection = Direction.LEFT;
    }

    private void Down()
    {
        switch (CurentDirection)
        {
            case Direction.UP:
                Turning(Turn.BASE);
                CurentDirection = Direction.DOWN;
                return;
            case Direction.RIGHT:
                Pref = Turn.RIGHT;
                break;
            case Direction.LEFT:
                Pref = Turn.LEFT;
                break;
            case Direction.DOWN:
                return;
        }
        TempDirection = Direction.DOWN;
    }

    private void Up()
    {
        switch (CurentDirection)
        {
            case Direction.DOWN:
                Turning(Turn.BASE);
                CurentDirection = Direction.UP;
                return;
            case Direction.LEFT:
                Pref = Turn.RIGHT;
                break;
            case Direction.RIGHT:
                Pref = Turn.LEFT;
                break;
            case Direction.UP:
                return;
        }
        TempDirection = Direction.UP;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = other.transform.position;
        if (Pref == Turn.LEFT)
        {
            if (!Physics.Raycast(transform.position, Vector3.Cross(transform.forward, transform.up), WallDistance))
            {
                Turning(Turn.LEFT);
            }
        }
        if (Pref == Turn.RIGHT)
        {
            if (Physics.Raycast(transform.position, Vector3.Cross(transform.forward, -transform.up), WallDistance))
            {
                Turning(Turn.RIGHT);
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, WallDistance))
        {
            PlayerSpeed = 0;
        }
    }

    private void Turning(Turn _turn)
    {
        switch (_turn)
        {
            case Turn.BASE:
                transform.Rotate(Vector3.up * -180.0f);
                return;
            case Turn.LEFT:
                transform.Rotate(Vector3.up * -90.0f);
                break;
            case Turn.RIGHT:
                transform.Rotate(Vector3.up * 90.0f);
                break;
            default:
                break;
        }
        CurentDirection = TempDirection;
    }

    //private void StopMovement()
    //{
    //    PlayerSpeed = 0;
    //    //switch (Pref)
    //    //{
    //    //    case Turn.BASE:
    //    //            Physics.Raycast(transform.position, Vector3.right, out RaycastHit _right, 10);
    //    //            if (!_right.collider.CompareTag("Wall"))
    //    //            {
    //    //                Pref = Turn.RIGHT;
    //    //            }
    //    //            Pref = Turn.LEFT;
    //    //        break;

    //    //    case Turn.LEFT:
    //    //        // wait for down or right input
    //    //        break;

    //    //    case Turn.RIGHT:
    //    //        // wait for left or down input
    //    //        break;
    //    //}
    //}
}
