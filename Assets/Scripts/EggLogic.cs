using System;
using UnityEngine;
using UnityEngine.Rendering;

public class EggLogic : MonoBehaviour
{
    GameManager gm;
    private float speed;
    private float durability;
    public Rigidbody2D rb;

    private void Awake()
    {
        gm = GameObject.Find("Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        durability = 10f;
    }

    private void Update()
    {
        speed = Vector3.Magnitude(rb.linearVelocity);
        if (durability <= 0)
        {
            Debug.Log("Egg has broken!");
            gm.DestroyEgg();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            Debug.Log("GOAAAAAAl");
            gm.score += collision.GetComponent<Goals>().scoreToGive;
            Debug.Log($"Goal Points: {collision.GetComponent<Goals>().scoreToGive} Current Score: {gm.score}");
            gm.DestroyEgg();
        }
        if (collision.CompareTag("Powerup"))
        {
            Powerups powerup = collision.GetComponent<Powerups>();
            Debug.Log("PowerupCollision");
            switch (powerup.pwrType)
            {
                case PowerupType.Egg:
                    gm.eggAmount++;
                    break;
                case PowerupType.ScoreModifier:
                    gm.scoreModifier = powerup.scoreModifier;
                    break;
                case PowerupType.Immunity:
                    Immunity(powerup.immunityTimer);
                    break;
                case PowerupType.Repair:
                    Repair(powerup.repairAmount);
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision at speed: " + speed);
        if (speed < 3)
        {
            durability -= (float)0.5;
            Debug.Log($"Took 0.5 damage, Durability at {durability} out of 10");
        }
        else if (speed < 4)
        {
            durability -= (float)1.0;
            Debug.Log($"Took 1.0 damage, Durability at {durability} out of 10");

        }
        else
        {
            durability -= (float)2.0;
            Debug.Log($"Took 2.0 damage, Durability at {durability} out of 10");
        }
    }

    public void Immunity(float immuneTime)
    {
        throw new NotImplementedException();
    }

    public void Repair(float repairAmnt)
    {
        throw new NotImplementedException();
    }
}
