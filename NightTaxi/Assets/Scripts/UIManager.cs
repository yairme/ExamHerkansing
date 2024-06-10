using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject TimerManager;
    [SerializeField] private GameObject PickUpAndDropManager;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject GameOverMenuScore;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject SoundFX;
    [SerializeField] private GameObject Music;
    [SerializeField] private GameObject[] InGameUIText;
    [SerializeField] private GameObject[] BackGround;
    [SerializeField] private GameObject[] OptionMenuBackButton;
    private bool TimeStarted = false;

    private void Awake()
    {
        SetTimeScale(0);
    }

    private void Start()
    {
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        InGameUI.SetActive(false);
        BackGround[1].SetActive(false);
        BackGround[0].SetActive(true);
        StartMenu.SetActive(true);
    }

    private void Update()
    {
        if (TimerManager.GetComponent<Timer>().TimeRemaining < 0 && TimeStarted)
        {
            GameOver();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
        InGameUIText[0].GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + PickUpAndDropManager.GetComponent<PickUpAndDropManager>().getScore;
        InGameUIText[1].GetComponent<TMPro.TextMeshProUGUI>().text = "Passengers: " + PickUpAndDropManager.GetComponent<PickUpAndDropManager>().getPassengers;
        TimerManager.GetComponent<TimeDisplay>().DisplayTime(InGameUIText[2].GetComponent<TMPro.TextMeshProUGUI>(), TimerManager.GetComponent<Timer>());
    }
    private void SetTimeScale(float _timeScale)
    {
        Time.timeScale = _timeScale;
    }

    public void StartGame()
    {
        StartMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        InGameUI.SetActive(true);
        foreach (GameObject bg in BackGround)
        {
            bg.SetActive(false);
        }
        TimeStarted = true;
        SetTimeScale(1);
    }

    public void StartMenuOptions()
    {
        StartMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(true);
        InGameUI.SetActive(false);
        BackGround[0].SetActive(true);
        BackGround[1].SetActive(false);
        OptionMenuBackButton[0].SetActive(true);
        OptionMenuBackButton[1].SetActive(false);
    }

    public void PauseButton()
    {
        StartMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(true);
        InGameUI.SetActive(false);
        BackGround[0].SetActive(false);
        BackGround[1].SetActive(true);
        OptionMenuBackButton[0].SetActive(false);
        OptionMenuBackButton[1].SetActive(true);
        SetTimeScale(0);
    }

    public void ResumeButton()
    {
        StartMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        InGameUI.SetActive(true);
        BackGround[0].SetActive(false);
        BackGround[1].SetActive(false);
        SetTimeScale(1);
    }

    public void OptionsBackButton()
    {
        StartMenu.SetActive(true);
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        InGameUI.SetActive(false);
        BackGround[0].SetActive(true);
        BackGround[1].SetActive(false);
    }

    public void GameOver()
    {
        StartMenu.SetActive(false);
        GameOverMenu.SetActive(true);
        PauseMenu.SetActive(false);
        InGameUI.SetActive(false);
        BackGround[0].SetActive(false);
        BackGround[1].SetActive(true);
        GameOverMenuScore.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + PickUpAndDropManager.GetComponent<PickUpAndDropManager>().getScore;
        SetTimeScale(0);
    }

    public void MainMenu()
    {
        StartMenu.SetActive(true);
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        InGameUI.SetActive(false);
        BackGround[0].SetActive(true);
        BackGround[1].SetActive(false);
        PickUpAndDropManager.GetComponent<PickUpAndDropManager>().ResetScore();
        TimerManager.GetComponent<Timer>().TimerReset();
        TimeStarted = false;
        SetTimeScale(0);
    }

    public void MusicToggle(bool _toggle)
    {
        if (_toggle)
        {
            Music.SetActive(true);
        }
        else
        {
            Music.SetActive(false);
        }
    }

    public void SFX(bool _toggle)
    {
        if (_toggle)
        {
            SoundFX.SetActive(true);
        }
        else
        {
            SoundFX.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}