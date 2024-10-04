using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class tictactoescript : MonoBehaviour
{
    Boolean checker;
    
    string currentPlayer = "X";
    // public TMP_Text nextPlayerText; // Text to show the next player

    public TMP_Text btnText1 = null;
    public TMP_Text btnText2 = null;
    public TMP_Text btnText3 = null;
    public TMP_Text btnText4 = null;
    public TMP_Text btnText5 = null;
    public TMP_Text btnText6 = null;
    public TMP_Text btnText7 = null;
    public TMP_Text btnText8 = null;
    public TMP_Text btnText9 = null;
    public TMP_Text msg;

    public Button btnResetGame = null;

    public GameObject horizontalStrikeU;
    public GameObject horizontalStrikeM;
    public GameObject horizontalStrikeD;
    public GameObject verticalStrikeL;
    public GameObject verticalStrikeM;
    public GameObject verticalStrikeR;
    public GameObject CrossStrike1;
    public GameObject CrossStrike2;

    public bool aiEnabled = false; // Toggle AI mode
    public string aiPlayer = "O";  // AI plays as "O"

    void Start()
    {

        ResetGame();
    }
    bool Over =false;

    public void score()
    {
        // X conditions
        if (CheckWin("X"))
        {
            DisplayWinner("X");
            Over = true;
            return;
        }

        // Player O winning conditions
        if (CheckWin("O"))
        {
            DisplayWinner("O");
            Over = true;
            return;
        }
        if (IsBoardFull())
        {
            msg.text = "It's a draw!";
            Over = true;
            return;
        }
        // Display the next player
        SwitchTurns();
    }

    bool IsBoardFull()
    {
        TMP_Text[] allButtons = { btnText1, btnText2, btnText3, btnText4, btnText5, btnText6, btnText7, btnText8, btnText9 };
        foreach ( TMP_Text button in allButtons )
        {
            if (button.text == "") // if there's  button
            {
                return false;
            }
        }
        return false;
    }

    // Check if a player has won
    bool CheckWin(string player)
    {
        if (btnText1.text == player && btnText2.text == player && btnText3.text == player)
        {
            horizontalStrikeU.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        if (btnText4.text == player && btnText5.text == player && btnText6.text == player)
        {
            horizontalStrikeM.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        if (btnText7.text == player && btnText8.text == player && btnText9.text == player)
        {
            horizontalStrikeD.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        if (btnText1.text == player && btnText4.text == player && btnText7.text == player)
        {
            verticalStrikeL.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        if (btnText2.text == player && btnText5.text == player && btnText8.text == player)
        {
            verticalStrikeM.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        if (btnText3.text == player && btnText6.text == player && btnText9.text == player)
        {
            verticalStrikeR.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        if (btnText1.text == player && btnText5.text == player && btnText9.text == player)
        {
            CrossStrike2.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        if (btnText3.text == player && btnText5.text == player && btnText7.text == player)
        {
            CrossStrike1.SetActive(true);
            msg.text ="Player " +player+ " Wins, Flawless victory";
            return true;
        }

        return false;
    }

    // Display the winner and strike the line
    void DisplayWinner(string winner)
    {
       //  nextPlayerText.text = $"{winner} Wins!";
    }

    // Switch turns between X and O players
    void SwitchTurns()
    {
        currentPlayer = (currentPlayer == "X") ? "O" : "X";
        // nextPlayerText.text = $"Next Player: {currentPlayer}";

        // AI Move if enabled and it's AI's turn
        if (aiEnabled && currentPlayer == aiPlayer)
        {
            MakeAIMove();
        }
    }

    // AI 
    void MakeAIMove()
    {
        // Find available empty button
        TMP_Text[] allButtons = { btnText1, btnText2, btnText3, btnText4, btnText5, btnText6, btnText7, btnText8, btnText9 };

        foreach (TMP_Text button in allButtons)
        {
            if (button.text == "")
            {
                button.text = aiPlayer;
                checker = !checker;
                score();
                break;
            }
        }
    }

    // Button click events for each grid button
    public void OnGridButtonClick(TMP_Text buttonText)
    {
        if (buttonText.text == "")
        {
            buttonText.text = currentPlayer;
            score();
        }
    }

    // Reset Game 
    public void ResetGame()
    {
        btnText1.text = "";
        btnText2.text = "";
        btnText3.text = "";
        btnText4.text = "";
        btnText5.text = "";
        btnText6.text = "";
        btnText7.text = "";
        btnText8.text = "";
        btnText9.text = "";
        msg.text ="";
        

        horizontalStrikeU.SetActive(false);
        horizontalStrikeM.SetActive(false);
        horizontalStrikeD.SetActive(false);
        verticalStrikeL.SetActive(false);
        verticalStrikeM.SetActive(false);
        verticalStrikeR.SetActive(false);
        CrossStrike1.SetActive(false);
        CrossStrike2.SetActive(false);
        Over =false;

        checker = false;
        currentPlayer = "X";
       // nextPlayerText.text = $"Next Player: {currentPlayer}";
    }

    // Button clicks for each grid position
    public void btnText1_Click() { OnGridButtonClick(btnText1); }
    public void btnText2_Click() { OnGridButtonClick(btnText2); }
    public void btnText3_Click() { OnGridButtonClick(btnText3); }
    public void btnText4_Click() { OnGridButtonClick(btnText4); }
    public void btnText5_Click() { OnGridButtonClick(btnText5); }
    public void btnText6_Click() { OnGridButtonClick(btnText6); }
    public void btnText7_Click() { OnGridButtonClick(btnText7); }
    public void btnText8_Click() { OnGridButtonClick(btnText8); }
    public void btnText9_Click() { OnGridButtonClick(btnText9); }
}