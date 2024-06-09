using UnityEngine;
public enum Direction
{
    UP,DOWN, LEFT, RIGHT
}
public class Movement : MonoBehaviour
{
    [SerializeField] private float BaseSpeed;
    [SerializeField] private float WallDistance;
    private float PlayerSpeed;
    private Direction CurentDirection = Direction.UP;
    private Direction Pref;

    private void Start()
    {
        PlayerSpeed = BaseSpeed;
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
    }
    private bool CheckTurn()
    {
        switch (Pref)
        {
            case Direction.UP:
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, 1), WallDistance))
                {
                    MakeTurn(Pref, 0);
                    return true;
                }
                break;
            case Direction.RIGHT:
                if (!Physics.Raycast(transform.position, new Vector3(-1, 0, 0), WallDistance))
                {
                    MakeTurn(Pref, 90);
                    return true;
                }
                break;
            case Direction.DOWN:
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, -1), WallDistance))
                {
                    MakeTurn(Pref, 180);
                    return true;
                }
                break;
            case Direction.LEFT:
                if (!Physics.Raycast(transform.position, new Vector3(1, 0, 0), WallDistance))
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
            if (!CheckTurn() && Physics.Raycast(transform.position, transform.forward, WallDistance))
            {
                PlayerSpeed = 0;
            }
        }
    }
}
