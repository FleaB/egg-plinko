using UnityEngine;
using DG.Tweening;

public class TiltShake : MonoBehaviour
{
    [SerializeField] Transform plinkoMachine;

    PlaceEgg eggPlacer;
    bool shaking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eggPlacer = GetComponent<PlaceEgg>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            if (eggPlacer.placedEgg)
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
}
