using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    public int x, y;
    public DraggableRank currentRank;

    public SpriteRenderer cellrenderers;


    private void Awake()
    {
        cellrenderers = GetComponent<SpriteRenderer>();
    }



    public void Initalize(int gridX, int gridY)
    {

        x = gridX;
        y = gridY;
        name = "Cell_" + x + "_" + y;

    }
    public bool IsEmpty()
    {
        return currentRank == null;


    }



    public bool ContainPosition(Vector3 position)
    {
        Bounds bounds = cellrenderers.bounds;
        return bounds.Contains(position);

    }

   public void SetRank(DraggableRank rank)
    {
        currentRank = rank;

        if(rank != null)
        {

            rank.currentCell = this;            ///계급장에 현재 칸 정보 알려주기

        }

        rank.originalPosition = new Vector3(transform.position.x, transform.position.y, 0);
        rank.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
