using UnityEngine;
using DG.Tweening;

public class PlaceEgg : MonoBehaviour
{
    [SerializeField] Transform plinkoMachine;
    [SerializeField] GameObject egg;
    [SerializeField] Vector3[] path;
    [SerializeField] float pathDuration;
    [SerializeField] float[] rotationPoints;

    TiltShake tiltShake;

    GameObject newEgg;
    Rigidbody2D eggRB;

    public bool egging;
    public bool hasPlacedEgg;
    void Awake()
    {
        tiltShake = GetComponent<TiltShake>();
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
            else if (!hasPlacedEgg)
            {
                Debug.Log("PlaceEgg");
                EggPlace();
            }
        }
    }

    void NewEgg()
    {
        egging = true;
        newEgg = Instantiate(egg, new Vector3(0, 3.16f), egg.transform.rotation);
        newEgg.transform.DOPath(path, pathDuration, PathType.Linear, PathMode.Sidescroller2D);
        newEgg.transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        eggRB = newEgg.GetComponent<Rigidbody2D>();
        eggRB.freezeRotation = true;
        tiltShake.theEgg = newEgg;
    }
    void EggPlace()
    {
        hasPlacedEgg = true;
        eggRB.freezeRotation = false;
        newEgg.transform.DOKill();
        eggRB.linearVelocity = Vector2.zero;
    }
}
