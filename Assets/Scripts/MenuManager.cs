using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_Text BestScoreText;
    public TMP_InputField PlayerNameInput;
    // Start is called before the first frame update
    private void Awake() {
        BestScoreText.text = "Best Score: " + Persistance.Instance.b_playerName + ": " + Persistance.Instance.b_score;
    }
    
    public void StartGame() {
        Persistance.Instance.c_playerName = PlayerNameInput.text;
        SceneManager.LoadScene("game");
    }
}
