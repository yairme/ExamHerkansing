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

    public void TurnDirection(Direction Input)
    {
        switch (Input)
        {
            case Direction.UP:
                if (CurentDirection == Direction.DOWN)
                {
                    // rotate naar boven
                    CurentDirection = Input;
                    PlayerSpeed = BaseSpeed;
                }
                Pref = Input;
                break;

            case Direction.DOWN:
                if (CurentDirection == Direction.UP)
                {
                    // rotate naar beneden
                    CurentDirection = Input;
                    PlayerSpeed = BaseSpeed;
                }
                Pref = Input;
                break;

            case Direction.LEFT:
                if (CurentDirection == Direction.RIGHT)
                {
                    // rotate naar links
                    CurentDirection = Input;
                    PlayerSpeed = BaseSpeed;
                }
                Pref = Input;
                break;

            case Direction.RIGHT:
                if (CurentDirection == Direction.LEFT)
                {
                    // rotate naar rechts
                    CurentDirection = Input;
                    PlayerSpeed = BaseSpeed;
                }
                Pref = Input;
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
    private bool CheckTurn()
    {
        switch (Pref) // alles nog ff laten draaien
        {
            case Direction.UP:
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, 1), WallDistance))
                {
                    CurentDirection = Pref;
                    return true;
                }
                break;
            case Direction.DOWN:
                if (!Physics.Raycast(transform.position, new Vector3(0, 0, -1), WallDistance))
                {
                    CurentDirection = Pref;
                    return true;
                }
                break;
            case Direction.LEFT:
                if (!Physics.Raycast(transform.position, new Vector3(1, 0, 0), WallDistance))
                {
                    CurentDirection = Pref;
                    return true;
                }
                break;
            case Direction.RIGHT:
                if (!Physics.Raycast(transform.position, new Vector3(-1, 0, 0), WallDistance))
                {
                    CurentDirection = Pref;
                    return true;
                }
                break;
        }
        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.position = other.transform.position;
        if (!CheckTurn() && Physics.Raycast(transform.position, transform.forward, WallDistance))
        {
            PlayerSpeed = 0;
        }
        //if (Pref == Turn.LEFT)
        //{
        //    if (!Physics.Raycast(transform.position, new Vector3(0,0,1), WallDistance))
        //    {
        //        Turning(Turn.LEFT);
        //    }
        //}
        //if (Pref == Turn.RIGHT)
        //{
        //    if (Physics.Raycast(transform.position, Vector3.Cross(transform.forward, -transform.up), WallDistance))
        //    {
        //        Turning(Turn.RIGHT);
        //    }
        //}
    }
    //private void Rigth()
    //{
    //    switch (CurentDirection)
    //    {
    //        case Direction.UP:
    //            Pref = Turn.RIGHT;
    //            break;
    //        case Direction.DOWN:
    //            Pref = Turn.LEFT;
    //            break;
    //        case Direction.LEFT:
    //            Turning(Turn.BASE);
    //            CurentDirection = Direction.RIGHT;
    //            return;
    //        case Direction.RIGHT:
    //            return;
    //    }
    //   TempDirection = Direction.RIGHT;
    //}

    //private void Left()
    //{
    //    switch (CurentDirection)
    //    {
    //        case Direction.UP:
    //            Pref = Turn.LEFT;
    //            break;
    //        case Direction.DOWN:
    //            Pref = Turn.RIGHT;
    //            break;
    //        case Direction.RIGHT:
    //            Turning(Turn.BASE);
    //            CurentDirection = Direction.LEFT;
    //            return;
    //        case Direction.LEFT:
    //            return;
    //    }
    //    TempDirection = Direction.LEFT;
    //}

    //private void Down()
    //{
    //    switch (CurentDirection)
    //    {
    //        case Direction.UP:
    //            Turning(Turn.BASE);
    //            CurentDirection = Direction.DOWN;
    //            return;
    //        case Direction.RIGHT:
    //            Pref = Turn.RIGHT;
    //            break;
    //        case Direction.LEFT:
    //            Pref = Turn.LEFT;
    //            break;
    //        case Direction.DOWN:
    //            return;
    //    }
    //    TempDirection = Direction.DOWN;
    //}

    //private void Up()
    //{
    //    switch (CurentDirection)
    //    {
    //        case Direction.DOWN:
    //            Turning(Turn.BASE);
    //            CurentDirection = Direction.UP;
    //            return;
    //        case Direction.LEFT:
    //            Pref = Turn.RIGHT;
    //            break;
    //        case Direction.RIGHT:
    //            Pref = Turn.LEFT;
    //            break;
    //        case Direction.UP:
    //            return;
    //    }
    //    TempDirection = Direction.UP;
    //}


    //private void Turning(Turn _turn)
    //{
    //    switch (_turn)
    //    {
    //        case Turn.BASE:
    //            transform.Rotate(Vector3.up * -180.0f);
    //            return;
    //        case Turn.LEFT:
    //            transform.Rotate(Vector3.up * -90.0f);
    //            break;
    //        case Turn.RIGHT:
    //            transform.Rotate(Vector3.up * 90.0f);
    //            break;
    //        default:
    //            break;
    //    }
    //    CurentDirection = TempDirection;
    //}

}
