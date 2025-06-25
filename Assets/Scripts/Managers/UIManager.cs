using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public Scene activeScene;
    TMP_Text scoreText;
    GameManager gm;
    void Start()
    {
        gm = GetComponent<GameManager>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    
    void Update()
    {
        scoreText.text = $"SCORE: {gm.score}";
    }
}
