using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player[] players;
    private int currentPlayer = 0;
    int numberOfPlayers;

    // Start is called before the first frame update
    void Start()
    {
        numberOfPlayers = players.Length;
    }


    public void PlayInCell(PlayCell cell)
    {
        GameObject newToken = Instantiate(players[currentPlayer].tokenPrefab, cell.transform);
        newToken.transform.position = cell.transform.position;
        newToken.GetComponent<Renderer>().material.color = players[currentPlayer].color;
        newToken.GetComponent<Collider>().enabled = false;
        cell.SetToken(newToken);
        NextPlayer();
    }

    void NextPlayer()
    {
        currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        Shader.SetGlobalColor("_CurrentPlayerColor", players[currentPlayer].color);
    }
}