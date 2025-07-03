using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int finalScore;
    public int eggAmount = 1;
    public float scoreModifier = 1;
    [SerializeField] Transform[] powerupSpawns;
    [SerializeField] GameObject[] powerups;

    public void SpawnPowerup()
    {
        int randomSpawn = Random.Range(0, powerupSpawns.Length);
        Instantiate(powerups[Random.Range(0, powerups.Length)], powerupSpawns[randomSpawn].position, powerupSpawns[randomSpawn].rotation);
    }
    public void Score()
    {
        float calcScore = score * scoreModifier;

        finalScore += (int)calcScore;
        score = 0;
        scoreModifier = 1;
    }

    public void DestroyEgg()
    {
        GetComponent<PlaceEgg>().egging = false;
        GetComponent<PlaceEgg>().hasPlacedEgg = false;
        Destroy(GetComponent<PlaceEgg>().newEgg);
    }
}
