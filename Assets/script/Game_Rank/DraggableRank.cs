using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DraggableRank : MonoBehaviour
{

    public int rankLevel = 1;
    public float dragSpeed = 10f;
    public float snapBackSpeed = 20f;


    public bool isDragging = false;

    public Vector3 originalPosition;

    public GridCell currentCell;

    public Camera mainCamera;
    public Vector3 dragOffset;
    public SpriteRenderer spriteRenderer;
    public GameManager gamemanager;

    private void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gamemanager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging)
        {
            Vector3 targetPosition = GetMouseWoridPosition() * dragSpeed;
            transform.position = Vector3.Lerp(transform.position, targetPosition, dragSpeed * Time.deltaTime);
        }
        else if (transform.position != originalPosition && currentCell != null)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, snapBackSpeed * Time.deltaTime);

        }
    }
    private void OnMouseDown()
    {
        StartDragging();
    }

    private void OnMouseUp()
    {
        if (!isDragging) return;
        StopDragging();
    }

    void StartDragging()
    {
        isDragging = true;
        dragOffset = transform.position - GetMouseWoridPosition();
        spriteRenderer.sortingOrder = 10;

    }

    void StopDragging()
    {
        isDragging = false;
        spriteRenderer.sortingOrder = 1;
        GridCell targetCell = gamemanager.FindClosestCell(transform.position);

        if (targetCell != null)
        {
            if (targetCell.currentRank == null)
            {
                MoveToCell(targetCell);
            }
            else if (targetCell.currentRank != this && targetCell. currentRank.rankLevel == rankLevel) 
            {
                MergeWithCell(targetCell);


            }
            else
            {
                ReturnToOriginamPosition();
                Debug.Log("��");
            }

        }
        else
        {
            ReturnToOriginamPosition();
            Debug.Log("��ȣ");
        }
    }

    public void MoveToCell(GridCell targetCell)
    {
        if(currentCell != null)
        {
            currentCell.currentRank = null;
        }
        currentCell = targetCell;
        targetCell.currentRank = this;
        originalPosition = new Vector3(targetCell.transform.position.x, targetCell.transform.position.y, 0f);
        transform.position = originalPosition;

    }
    public void ReturnToOriginamPosition()
    {
        transform.position = originalPosition;
    }
    public void MergeWithCell(GridCell targetCell)
    {

        if(targetCell.currentRank == null || targetCell.currentRank.rankLevel != rankLevel)
        {

            ReturnToOriginamPosition();
            return;
        }

        if(currentCell != null)
        {

            currentCell.currentRank = null;

        }
        gamemanager.MergeRanks(this, targetCell.currentRank);

    }

    public Vector3 GetMouseWoridPosition()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePos);

    }

    public void SetRankLevel(int level)
    {
        rankLevel = level;

        if(gamemanager != null &&  gamemanager .rankSprites.Length > level -1)
        {

            spriteRenderer.sprite = gamemanager.rankSprites[level - 1];


        }




    }






}
