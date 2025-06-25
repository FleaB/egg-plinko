using UnityEngine;

public class EggLogic : MonoBehaviour
{
    GameManager gm;
    private void Awake()
    {
        gm = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.CompareTag("Goal"))
        {
            Debug.Log("GOAAAAAAl");
            gm.score += collision.GetComponent<Goals>().scoreToGive;
            Debug.Log($"Goal Points: {collision.GetComponent<Goals>().scoreToGive} Current Score: {gm.score}");
            Destroy(gameObject);
        }
    }
}
