using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    [Header("Player Name")]
    [SerializeField] private string PlayerName = "";
    public TMP_InputField m_inputField;

    [Header ("High Score")]
    public TextMeshProUGUI highScoreText;

    void Start()
    {
       m_inputField = GameObject.Find("PlayerName").GetComponent<TMP_InputField>();
       MainManagerX.Instance.LoadName();
       highScoreText.text = "Best Score : " + MainManagerX.Instance.PlayerName + " : " + MainManagerX.Instance.m_highScore;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void InputPlayerName()
    {
        PlayerName = m_inputField.text;
        Debug.Log(PlayerName);

        MainManagerX.Instance.m_cPlayerName = PlayerName;
    }
}
