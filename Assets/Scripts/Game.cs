using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    public Button[] buttons;
    bool isWin;

    bool timerActive = false;
    float currentTime;
    public Text timeDisplay;

    public Text counterDisplay;
    int clickCounter;

    public Button startButton;
    public Button resetButton;
    public Button playAgainButton;

    public Text winAnnouncement;

    private void Start()
    {
        currentTime = 0;
        clickCounter = 0;
        disableGameBoard();
        playAgainButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        int minutes = time.Minutes;
        int seconds = time.Seconds;
        string displayMinutes;
        string displaySeconds;
        if (minutes < 10)
        {
            displayMinutes = "0" + minutes.ToString();
        }
        else
        {
            displayMinutes = minutes.ToString();
        }

        if (seconds < 10)
        {
            displaySeconds = "0" + seconds.ToString();
        }
        else
        {
            displaySeconds = seconds.ToString();
        }

        timeDisplay.text = displayMinutes + ":" + displaySeconds;
        counterDisplay.text = clickCounter.ToString();
    }

    public void startGame()
    {
        // Initiate board via random triggers of buttons.
        for (int i = 0; i < 5; i++)
        {
            int randomVal = UnityEngine.Random.Range(0, 25);
            print(randomVal);
            Button randButton = buttons[randomVal];
            buttonClick(randButton);
        }
        startTimer();
        enableGameBoard();
        startButton.interactable = false;

    }

    public void resetGame()
    {
        stopTimer();
        resetTimer();
        clickCounter = 0;
        resetGameBoard();

        disableGameBoard();
        winAnnouncement.text = "";
        startButton.interactable = true;
        playAgainButton.gameObject.SetActive(false);
    }


    public void buttonClick(Button button)
    {

        string targetButton = button.name;
        switch (targetButton)
        {
            case "0":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[1].GetComponent<Image>());
                toggleColor(buttons[5].GetComponent<Image>());
                break;
            case "1":
                toggleColor(buttons[0].GetComponent<Image>());
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[2].GetComponent<Image>());
                toggleColor(buttons[6].GetComponent<Image>());
                break;
            case "2":
                toggleColor(buttons[1].GetComponent<Image>());
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[3].GetComponent<Image>());
                toggleColor(buttons[7].GetComponent<Image>());
                break;
            case "3":
                toggleColor(buttons[2].GetComponent<Image>());
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[4].GetComponent<Image>());
                toggleColor(buttons[8].GetComponent<Image>());
                break;
            case "4":
                toggleColor(buttons[3].GetComponent<Image>());
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[9].GetComponent<Image>());
                break;
            case "5":
                toggleColor(buttons[0].GetComponent<Image>());
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[6].GetComponent<Image>());
                toggleColor(buttons[10].GetComponent<Image>());
                break;
            case "6":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[1].GetComponent<Image>());
                toggleColor(buttons[5].GetComponent<Image>());
                toggleColor(buttons[7].GetComponent<Image>());
                toggleColor(buttons[11].GetComponent<Image>());
                break;
            case "7":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[2].GetComponent<Image>());
                toggleColor(buttons[6].GetComponent<Image>());
                toggleColor(buttons[8].GetComponent<Image>());
                toggleColor(buttons[12].GetComponent<Image>());
                break;
            case "8":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[3].GetComponent<Image>());
                toggleColor(buttons[7].GetComponent<Image>());
                toggleColor(buttons[9].GetComponent<Image>());
                toggleColor(buttons[13].GetComponent<Image>());
                break;
            case "9":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[4].GetComponent<Image>());
                toggleColor(buttons[8].GetComponent<Image>());
                toggleColor(buttons[14].GetComponent<Image>());
                break;
            case "10":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[5].GetComponent<Image>());
                toggleColor(buttons[11].GetComponent<Image>());
                toggleColor(buttons[15].GetComponent<Image>());
                break;
            case "11":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[6].GetComponent<Image>());
                toggleColor(buttons[10].GetComponent<Image>());
                toggleColor(buttons[12].GetComponent<Image>());
                toggleColor(buttons[16].GetComponent<Image>());
                break;
            case "12":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[7].GetComponent<Image>());
                toggleColor(buttons[11].GetComponent<Image>());
                toggleColor(buttons[13].GetComponent<Image>());
                toggleColor(buttons[17].GetComponent<Image>());
                break;
            case "13":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[8].GetComponent<Image>());
                toggleColor(buttons[12].GetComponent<Image>());
                toggleColor(buttons[14].GetComponent<Image>());
                toggleColor(buttons[18].GetComponent<Image>());
                break;
            case "14":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[9].GetComponent<Image>());
                toggleColor(buttons[13].GetComponent<Image>());
                toggleColor(buttons[19].GetComponent<Image>());
                break;
            case "15":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[10].GetComponent<Image>());
                toggleColor(buttons[16].GetComponent<Image>());
                toggleColor(buttons[20].GetComponent<Image>());
                break;
            case "16":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[11].GetComponent<Image>());
                toggleColor(buttons[15].GetComponent<Image>());
                toggleColor(buttons[17].GetComponent<Image>());
                toggleColor(buttons[21].GetComponent<Image>());
                break;
            case "17":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[12].GetComponent<Image>());
                toggleColor(buttons[16].GetComponent<Image>());
                toggleColor(buttons[18].GetComponent<Image>());
                toggleColor(buttons[22].GetComponent<Image>());
                break;
            case "18":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[13].GetComponent<Image>());
                toggleColor(buttons[17].GetComponent<Image>());
                toggleColor(buttons[19].GetComponent<Image>());
                toggleColor(buttons[23].GetComponent<Image>());
                break;
            case "19":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[14].GetComponent<Image>());
                toggleColor(buttons[18].GetComponent<Image>());
                toggleColor(buttons[24].GetComponent<Image>());
                break;
            case "20":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[15].GetComponent<Image>());
                toggleColor(buttons[21].GetComponent<Image>());
                break;
            case "21":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[16].GetComponent<Image>());
                toggleColor(buttons[20].GetComponent<Image>());
                toggleColor(buttons[22].GetComponent<Image>());
                break;
            case "22":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[17].GetComponent<Image>());
                toggleColor(buttons[21].GetComponent<Image>());
                toggleColor(buttons[23].GetComponent<Image>());
                break;
            case "23":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[18].GetComponent<Image>());
                toggleColor(buttons[22].GetComponent<Image>());
                toggleColor(buttons[24].GetComponent<Image>());
                break;
            case "24":
                toggleColor(button.GetComponent<Image>());
                toggleColor(buttons[19].GetComponent<Image>());
                toggleColor(buttons[23].GetComponent<Image>());
                break;
            default:
                break;
        }

        checkForWin();
        if(buttons[1].interactable == true)
        {
            clickCounter++;
        }
        
    }

    private void toggleColor(Image image)
    {
        if(image.color == Color.red)
        {
            image.color = Color.white;
        } else
        {
            image.color = Color.red;
        }
    }

    private void checkForWin()
    {
        isWin = true;
        foreach (Button button in buttons)
        {
            if (button.GetComponent<Image>().color == Color.red)
            {
                isWin = false;
            }
        }
        if (isWin == true)
        {
            Debug.Log("Win!");
            stopTimer();
            winAnnouncement.text = "You win!";
            playAgainButton.gameObject.SetActive(true);
        }
    }

    private void startTimer()
    {
        timerActive = true;
    }

    private void stopTimer()
    {
        timerActive = false;
    }

    private void resetTimer()
    {
        currentTime = 0;
    }

    private void disableGameBoard()
    {
        foreach(Button button in buttons)
        {
            button.interactable = false;
        }
    }

    private void enableGameBoard()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    private void resetGameBoard()
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }

}
