using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private Button _playbutton;
    [SerializeField] private GameObject _loginUI;
    private void Awake()
    {
        _playbutton.onClick.AddListener(OnclickPlayButtonEvent);
    }
    private void OnclickPlayButtonEvent()
    {
        gameObject.SetActive(false);
        _loginUI.SetActive(true);
    }
}