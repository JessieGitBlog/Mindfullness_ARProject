using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Button _playbutton;

    [SerializeField] private TMP_Dropdown _dropdown;

    [SerializeField] private GameObject _gameUI;

    [SerializeField] private FollowGyro _followGyro;
    
    private string _selectSimulation;
    private void Awake()
    {
        _playbutton.onClick.AddListener(OnclickPlayButtonEvent);
    }

    private void OnclickPlayButtonEvent()
    {
        gameObject.SetActive(false);
        _gameUI.SetActive(true);
        Debug.Log(_dropdown.options[_dropdown.value].text);
        if (_dropdown.options[_dropdown.value].text == "Archery")
        {
            SceneManager.LoadScene("ArcheryScene");
        }
        _followGyro.enabled = true;
    }
}