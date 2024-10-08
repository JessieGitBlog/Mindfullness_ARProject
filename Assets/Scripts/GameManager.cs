using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public TMP_Text _timerText;

    private int min;
    private int sec;

    private bool isPlay = false;

    public Button _playButton;

    public TMP_Text CountText;

    public Button _backButton;

    public GameObject _soccerBall;

    public GameObject _spawnPosition;

    public Button _menuButton;

    public GameObject _menuUI;

    private void Start()
    {
        _playButton.onClick.AddListener(OnClickedPlayButton);
        _menuButton.onClick.AddListener(OnClickedMenuButton);
    }

    private void OnDisable()
    {
        _backButton.gameObject.SetActive(false);
        _menuButton.gameObject.SetActive(false);
        CountText.text = "";
        _playButton.GetComponentInChildren<TMP_Text>().text = "PLAY";
    }

    private void OnClickedPlayButton()
    {
        if (isPlay)
        {
            isPlay = false;
            _backButton.gameObject.SetActive(true); // 1
            StopCoroutine(CoTimer());
            _playButton.GetComponentInChildren<TMP_Text>().text = "PLAY";
        }
        else
        {
            isPlay = true;
            _backButton.gameObject.SetActive(false); // 2
            StartCoroutine(CoCounter());
            _playButton.GetComponentInChildren<TMP_Text>().text = "STOP";
        }
    }

    private void OnClickedMenuButton()
    {
        StopCoroutine(CoCounter());
        this.gameObject.SetActive(false);
        _menuUI.SetActive(true);
    }

    IEnumerator CoCounter() //2
    {
        CountText.gameObject.SetActive(true);

        CountText.text = "Starting In";
        yield return new WaitForSeconds(1f);
        CountText.text = "3";
        yield return new WaitForSeconds(1f);
        CountText.text = "2";
        yield return new WaitForSeconds(1f);
        CountText.text = "1";
        yield return new WaitForSeconds(1f);
        CountText.text = "Start!";
        yield return new WaitForSeconds(1f);

        CountText.gameObject.SetActive(false);
        StartCoroutine(CoTimer());
    }

    private int Score = 0;

    IEnumerator CoTimer()
    {
        while (isPlay)
        {
            yield return new WaitForSeconds(1f);
            sec++;

            if (sec == 60)
            {
                min++;
                sec = sec - 60;
            }

            _timerText.text = $"{min:D2}:{sec:D2}";

            if (sec % 3 == 0)
            {
                var spawnPositionZ = _spawnPosition.transform.position.z;
                var spawnScaleS = _spawnPosition.transform.localScale.x / 2;

                Vector3 randPosition = new Vector3(
                    Random.Range(-spawnScaleS, spawnScaleS),
                    Random.Range(-spawnScaleS, spawnScaleS),
                    Random.Range(-spawnScaleS, spawnScaleS) + spawnPositionZ);
                Instantiate(_soccerBall, randPosition, Quaternion.identity);
            }


            if (min == 3)
            {
                isPlay = false;
                CountText.gameObject.SetActive(true);
                CountText.text = $"Game Finish";
                yield return new WaitForSeconds(3f);
                CountText.text = $"Your Score {Score}";
                _backButton.gameObject.SetActive(true); //1
                _playButton.GetComponentInChildren<TMP_Text>().text = "PLAY";
            }
        }

        if (!isPlay)
        {
            min = 0;
            sec = 0;
            _timerText.text = $"{min:D2}:{sec:D2}";
        }
    }

    private void OnDestroy()
    {
        isPlay = false;
        StopCoroutine(CoTimer());
    }
}