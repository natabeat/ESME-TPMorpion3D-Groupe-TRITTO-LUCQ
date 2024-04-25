using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private PlayCell currentHoveredCell; //current cell regardée
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //check collision raycast
        if (Physics.Raycast(ray, out hit))
        {
            PlayCell cell = hit.collider.GetComponent<PlayCell>();

            if (cell != null && cell != currentHoveredCell)
            {
                if (currentHoveredCell != null)
                {
                    currentHoveredCell.OnHoverExit();
                }

                currentHoveredCell = cell;
                currentHoveredCell.OnHoverEnter();
            }

            //appelle PlayInCell when clique 
            if (Input.GetMouseButtonDown(0))
            {
                if (gameManager != null && cell != null)
                {
                    gameManager.PlayInCell(cell);
                }
            }
        }
        else
        {
            if (currentHoveredCell != null)
            {
                currentHoveredCell.OnHoverExit();
                currentHoveredCell = null;
            }
        }
    }
}
