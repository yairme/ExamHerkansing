using UnityEngine;
public enum Direction
{
    UP,DOWN, LEFT, RIGHT
}
public class Movement : MonoBehaviour
{
    [SerializeField] private float BaseSpeed;
    [SerializeField] private float WallDistance;
    [SerializeField] private Direction CurentDirection = Direction.UP;
    private float PlayerSpeed;
    private Vector3 ForwardDir;
    private Direction Pref;

    private void Start()
    {
        PlayerSpeed = BaseSpeed;
        Pref = CurentDirection;
        SetDirection();
    }

    void FixedUpdate()
    {
        transform.Translate(PlayerSpeed * Time.deltaTime * Vector3.forward);
    }

    public void TurnDirection(Direction _Input)
    {
        switch (_Input)
        {
            case Direction.UP:
                if (CurentDirection == Direction.DOWN)
                {
                    MakeTurn(_Input, 0);
                }
                Pref = _Input;
                break;

            case Direction.RIGHT:
                if (CurentDirection == Direction.LEFT)
                {
                    MakeTurn(_Input, 90);
                }
                Pref = _Input;
                break;

            case Direction.DOWN:
                if (CurentDirection == Direction.UP)
                {
                    MakeTurn(_Input, 180);
                }
                Pref = _Input;
                break;

            case Direction.LEFT:
                if (CurentDirection == Direction.RIGHT)
                {
                    MakeTurn(_Input, 270);
                }
                Pref = _Input;
                break;
        }
        if (PlayerSpeed == 0)
        {
            if (CheckTurn())
            {
                PlayerSpeed = BaseSpeed;
            }
        }
    }

    private void MakeTurn(Direction _Direction, int _Degree)
    {
        transform.rotation = Quaternion.Euler(0.0f, _Degree, 0.0f);
        CurentDirection = _Direction;
        PlayerSpeed = BaseSpeed;
        SetDirection();
    }

    private void SetDirection()
    {
        switch (CurentDirection)
        {
            case Direction.UP:
                ForwardDir = new Vector3(0, 0, 1);
                break;
            case Direction.DOWN:
                ForwardDir = new Vector3(0, 0, -1);
                break;
            case Direction.LEFT:
                ForwardDir = new Vector3(-1, 0, 0);
                break;
            case Direction.RIGHT:
                ForwardDir = new Vector3(1, 0, 0);
                break;
        }
    }

    private bool CheckTurn()
    {
        if(Pref == CurentDirection)
        {
            return false;
        }
        switch (Pref)
        {
            case Direction.UP:
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, 1), WallDistance, 6))
                {
                    MakeTurn(Pref, 0);
                    return true;
                }
                break;
            case Direction.RIGHT:
                if (!Physics.Raycast(transform.position, new Vector3(1, 0, 0), WallDistance, 6))
                {
                    MakeTurn(Pref, 90);
                    return true;
                }
                break;
            case Direction.DOWN:
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, -1), WallDistance, 6))
                {
                    MakeTurn(Pref, 180);
                    return true;
                }
                break;
            case Direction.LEFT:
                if (!Physics.Raycast(transform.position, new Vector3(-1, 0, 0), WallDistance, 6))
                {
                    MakeTurn(Pref, 270);
                    return true;
                }
                break;
        }
        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Corner"))
        {
            transform.position = other.transform.position;
            if (CheckTurn())
            {   
                return;
            }
            if (Physics.Raycast(transform.position, ForwardDir, WallDistance))
            {
                PlayerSpeed = 0;
            }
        }
    }
}
