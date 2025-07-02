using UnityEngine;
using DG.Tweening;

public class PlaceEgg : MonoBehaviour
{
    [SerializeField] Transform plinkoMachine;
    [SerializeField] GameObject egg;
    [SerializeField] Vector3[] path;
    [SerializeField] float pathDuration;
    [SerializeField] float[] rotationPoints;
    [SerializeField] int powerupChance;

    TiltShake tiltShake;
    GameManager gm;

    Rigidbody2D eggRB;

    [HideInInspector] public GameObject newEgg;

    public bool egging;
    public bool hasPlacedEgg;
    void Awake()
    {
        gm = GetComponent<GameManager>();
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
            if (!egging && gm.eggAmount > 0)
            {
                Debug.Log("NewEgg");
                NewEgg();
                if (Random.Range(0, powerupChance+1) == powerupChance)
                {
                    gm.SpawnPowerup();
                }
                gm.eggAmount--;
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
