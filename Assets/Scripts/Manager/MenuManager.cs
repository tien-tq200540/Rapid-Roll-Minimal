using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : TienMonoBehaviour
{
    [SerializeField] protected Button startButton;
    [SerializeField] protected Button instructionButton;
    [SerializeField] protected Button highscoreButton;
    [SerializeField] protected Button quitButton;
    [SerializeField] protected GameObject instructionUI;
    [SerializeField] protected GameObject highscoreUI;
    [SerializeField] protected Button backToMainButton;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAllButton();
        LoadAllUI();
    }

    protected virtual void LoadAllUI()
    {
        if (instructionUI == null) instructionUI = transform.Find("InstructionUI").gameObject;
        if (highscoreUI == null) highscoreUI = transform.Find("HighScoreUI").gameObject;
        instructionUI.SetActive(false);
        highscoreUI.SetActive(false);
    }

    protected virtual void LoadAllButton()
    {
        Transform buttonParent = transform.Find("Button");
        if (startButton == null) startButton = buttonParent.Find("StartButton").GetComponent<Button>();
        if (instructionButton == null) instructionButton = buttonParent.Find("InstructionButton").GetComponent<Button>();
        if (highscoreButton == null) highscoreButton = buttonParent.Find("HighScoreButton").GetComponent<Button>();
        if (quitButton == null) quitButton = buttonParent.Find("QuitButton").GetComponent<Button>();
        if (backToMainButton == null) backToMainButton = transform.Find("BackToMainButton").GetComponent<Button>();
        backToMainButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        instructionButton.onClick.AddListener(Instruction);
        highscoreButton.onClick.AddListener(HighScore);
        quitButton.onClick.AddListener(QuitGame);
        backToMainButton.onClick.AddListener(BackToMainButton);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        instructionButton.onClick.RemoveListener(Instruction);
        highscoreButton.onClick.RemoveListener(HighScore);
        quitButton.onClick.RemoveListener(QuitGame);
        backToMainButton.onClick.RemoveListener(BackToMainButton);
    }

    protected virtual void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    protected virtual void Instruction()
    {
        HideButtons();
        instructionUI.SetActive(true);
        backToMainButton.gameObject.SetActive(true);
    }

    protected virtual void HighScore()
    {
        HideButtons();
        highscoreUI.SetActive(true);
        backToMainButton.gameObject.SetActive(true);
    }

    protected virtual void QuitGame()
    {
        Application.Quit();
    }

    protected virtual void BackToMainButton()
    {
        ShowButtons();
        backToMainButton.gameObject.SetActive(false);
        instructionUI.SetActive(false);
        highscoreUI.SetActive(false);
    }

    protected virtual void HideButtons()
    {
        startButton.gameObject.SetActive(false);
        instructionButton.gameObject.SetActive(false);
        highscoreButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    protected virtual void ShowButtons()
    {
        startButton.gameObject.SetActive(true);
        instructionButton.gameObject.SetActive(true);
        highscoreButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }
}
