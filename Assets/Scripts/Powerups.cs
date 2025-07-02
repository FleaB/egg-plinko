using DG.Tweening;
using UnityEngine;

public enum PowerupType
{
    Egg,
    ScoreModifier,
    Immunity,
    Repair
}
public class Powerups : MonoBehaviour
{
    public PowerupType pwrType;
    public float scoreModifier;
    public float immunityTimer;
    public float repairAmount;

    GameManager gm;
    void Awake()
    {
        gm = GameObject.Find("Manager").GetComponent<GameManager>();
        // Animation
        transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
    }
}
