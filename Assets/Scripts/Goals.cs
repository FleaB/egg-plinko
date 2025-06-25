using TMPro;
using UnityEngine;

public class Goals : MonoBehaviour
{
    public int scoreToGive;

    [SerializeField]
    public TMP_Text scoreText;

    public void Awake()
    {
        scoreText.text = scoreToGive.ToString();
    }
}
