using UnityEngine;
using DG.Tweening;

public class PlaceEgg : MonoBehaviour
{
    [SerializeField] GameObject egg;
    [SerializeField] Vector3[] path;
    [SerializeField] float pathDuration;
    [SerializeField] float[] rotationPoints;

    private Rigidbody2D eggRB;
    bool egging;
    bool placedEgg;
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
            Debug.Log("SPACE");
            if (!egging)
            {
                Debug.Log("NewEgg");
                NewEgg();
            }
            else if(!placedEgg)
            {
                Debug.Log("PlaceEgg");
                EggPlace();
            }
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
