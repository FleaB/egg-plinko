using UnityEngine;
using DG.Tweening;

public class PlaceEgg : MonoBehaviour
{
    [SerializeField] Transform plinkoMachine;
    [SerializeField] GameObject egg;
    [SerializeField] Vector3[] path;
    [SerializeField] float pathDuration;
    [SerializeField] float[] rotationPoints;

    private Rigidbody2D eggRB;
    bool egging;
    bool placedEgg;
    bool shaking;
    void Awake()
    {
        if (!egging)
        {
            Debug.Log("SpawnEgg");
            NewEgg();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!egging)
            {
                Debug.Log("NewEgg");
                NewEgg();
            }
            else if (!placedEgg)
            {
                Debug.Log("PlaceEgg");
                EggPlace();
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {

            if (placedEgg)
            {
                Debug.Log("SHAKING");
                plinkoMachine.DOShakeRotation(1, 1, 20, 20, true);
                shaking = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (shaking)
            {
                plinkoMachine.DORotate(Vector3.zero, 1);
                shaking = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            plinkoMachine.DORotate(new Vector3(0, 0, 10), 1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            plinkoMachine.DORotate(new Vector3(0, 0, -10), 1);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            plinkoMachine.DORotate(Vector3.zero, 1);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            plinkoMachine.DORotate(Vector3.zero, 1);
        }
    }

    void NewEgg()
    {
        egging = true;
        egg = Instantiate(egg, new Vector3(0, 3.16f), egg.transform.rotation);
        egg.transform.DOPath(path, pathDuration, PathType.Linear, PathMode.Sidescroller2D);
        egg.transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        eggRB = egg.GetComponent<Rigidbody2D>();
        eggRB.freezeRotation = true;
    }
    void EggPlace()
    {
        placedEgg = true;
        eggRB.freezeRotation = false;
        egg.transform.DOKill();
        eggRB.linearVelocity = Vector2.zero;
    }
}
