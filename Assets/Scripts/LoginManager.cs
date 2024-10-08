using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField Id;
    public TMP_InputField PassWord;

    public Button LoginBtn;

    public Button CreateBtn;

    public TMP_InputField CreateID;
    public TMP_InputField CreatePW;

    public Button SaveBtn;
    public Button CancleBtn;

    public GameObject LoginInfo;

    public GameObject messagePopup;
    public TMP_Text message;
    public Button messagePopupClose;

    public GameObject menuUI;

    private void Awake()
    {
        LoginInfo.SetActive(false);
        messagePopup.SetActive(false);
        LoginBtn.onClick.AddListener(OnClickLoginButton);
        CreateBtn.onClick.AddListener(OnClickCreateButton);
        SaveBtn.onClick.AddListener(OnClickSaveButton);
        CancleBtn.onClick.AddListener(OnClickCancleButton);
        messagePopupClose.onClick.AddListener(OnClickMessagePopupCloseButton);
    }

    private void OnClickCreateButton()
    {
        LoginInfo.SetActive(true);
    }

    private void OnClickLoginButton()
    {
        if (Id.text != PlayerPrefs.GetString("ID"))
        {
            messagePopup.SetActive(true);
            message.text = "id is not registered or invalid";
        }
        else if (PassWord.text != PlayerPrefs.GetString("PW"))
        {
            messagePopup.SetActive(true);
            message.text = "pw is invalid";
        }
        else
        {
            menuUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void OnClickSaveButton()
    {
        PlayerPrefs.SetString("ID", CreateID.text);
        PlayerPrefs.SetString("PW", CreatePW.text);
        LoginInfo.SetActive(false);
    }


    private void OnClickCancleButton()
    {
        LoginInfo.SetActive(false);
    }

    private void OnClickMessagePopupCloseButton()
    {
        messagePopup.SetActive(false);
        message.text = "";
    }
}