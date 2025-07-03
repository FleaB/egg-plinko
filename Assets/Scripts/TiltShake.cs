using UnityEngine;
using DG.Tweening;

public class TiltShake : MonoBehaviour
{
    [SerializeField] Transform plinkoMachine;
    [HideInInspector] public GameObject theEgg;

    PlaceEgg eggPlacer;
    bool shaking;
    void Start()
    {
        eggPlacer = GetComponent<PlaceEgg>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (eggPlacer.hasPlacedEgg)
            {
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

        if (eggPlacer.hasPlacedEgg)
        {
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
    }
}
