using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RunGame : MonoBehaviour {

    public GameObject XScoreCounter;
    public GameObject OScoreCounter;
    public GameObject drawScoreCounter;
    private int XScore;
    private int OScore;
    private int drawScore;

    public GameObject winScreen;
    private List<GameObject> tiles = new List<GameObject>();

    private int currentTurn;
    public int gameState;
    private int moves;
    public int win;
    public static bool halt;


    void Awake ()
    {
        moves = 0;
        XScore = 0;
        OScore = 0;
        drawScore = 0;
        updateScores();
        currentTurn = 0;
        gameState = 0;
        tiles.Add(GameObject.Find("Tile1"));
        tiles.Add(GameObject.Find("Tile2"));
        tiles.Add(GameObject.Find("Tile3"));
        tiles.Add(GameObject.Find("Tile4"));
        tiles.Add(GameObject.Find("Tile5"));
        tiles.Add(GameObject.Find("Tile6"));
        tiles.Add(GameObject.Find("Tile7"));
        tiles.Add(GameObject.Find("Tile8"));
        tiles.Add(GameObject.Find("Tile9"));


    }


    private void resetBoard()
    {
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<SpaceInteract>().clearTile();
        }
    }

    public int getTurn()
    {
        return currentTurn;
    }

    public void updateGameState(GameObject passed)
    {
        if (currentTurn == 0)
        {
            switch (passed.name)
            {
                case "Tile1":
                    gameState += 1;
                    break;
                case "Tile2":
                    gameState += 2;
                    break;
                case "Tile3":
                    gameState += 4;
                    break;
                case "Tile4":
                    gameState += 8;
                    break;
                case "Tile5":
                    gameState += 16;
                    break;
                case "Tile6":
                    gameState += 32;
                    break;
                case "Tile7":
                    gameState += 64;
                    break;
                case "Tile8":
                    gameState += 128;
                    break;
                case "Tile9":
                    gameState += 256;
                    break;
            }
        }
        else if (currentTurn == 1)
        {
            switch (passed.name)
            {
                case "Tile1":
                    gameState += 512;
                    break;
                case "Tile2":
                    gameState += 1024;
                    break;
                case "Tile3":
                    gameState += 2048;
                    break;
                case "Tile4":
                    gameState += 4096;
                    break;
                case "Tile5":
                    gameState += 8192;
                    break;
                case "Tile6":
                    gameState += 16384;
                    break;
                case "Tile7":
                    gameState += 32768;
                    break;
                case "Tile8":
                    gameState += 65536;
                    break;
                case "Tile9":
                    gameState += 131072;
                    break;
            }
        }
        if (currentTurn == 1) currentTurn = 0;
        else if (currentTurn == 0) currentTurn = 1;
        moves++;
        checkWinConditions();
    }

    private void checkWinConditions()
    {
        if ((gameState & 7) == 7 || (gameState & 56) == 56 || (gameState & 448) == 448 ||
            (gameState & 73) == 73 || (gameState & 146) == 146 || (gameState & 292) == 292 ||
            (gameState & 273) == 273 || (gameState & 84) == 84)
        {
            win=1;
            endGame();
        }
        else if((gameState & 3584) == 3584 || (gameState & 28672) == 28672 || (gameState & 229376) == 229376 ||
            (gameState & 37376) == 37376 || (gameState & 74752) == 74752 || (gameState & 149504) == 149504 ||
            (gameState & 139776) == 139776 || (gameState & 43008) == 43008)
        {
            win = 2;
            endGame();
        }
        else if(moves == 9)
        {
            win = 3;
            endGame();
            
        }
    }

    private void endGame()
    {
        halt = true;
        winScreen.GetComponent<WinScript>().showWinScreen(win);
    }

    private void winner(int value)
    {
        switch (value)
        {
            case 1:
                XScore++;
                break;
            case 2:
                OScore++;
                break;
            case 3:
                drawScore++;
                break;
        }
        updateScores();
    }


    public void restartGame()
    {
        winner(win);
        win = 0;
        moves = 0;
        currentTurn = 0;
        moves = 0;
        gameState = 0;
        halt = false;
        resetBoard();

    }



    private void updateScores()
    {
        XScoreCounter.GetComponent<Text>().text = XScore.ToString();
        OScoreCounter.GetComponent<Text>().text = OScore.ToString();
        drawScoreCounter.GetComponent<Text>().text = drawScore.ToString();
    }

    private void update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
