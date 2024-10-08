using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text PlayTimeText;

    public Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(OnClickCloseButton);
    }

    private void OnClickCloseButton()
    {
        gameObject.SetActive(false);
    }
}