using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject TimerManager;
    [SerializeField] private GameObject PickUp_DropManager;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject[] BackGround;
    [SerializeField] private GameObject[] OptionMenuBackButton;

    public void Awake()
    {
        SetTimeScale(0);
    }

    public void Start()
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
        if (TimerManager.GetComponent<TimerManager>().GetTime() <= 0)
        {
            GameOver();
        }
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
        SetTimeScale(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}