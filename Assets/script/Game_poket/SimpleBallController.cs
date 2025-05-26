using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBallController : MonoBehaviour
{
    [Header("기본 설정")]
    public float power = 10f;
    public Sprite arrowSprite;

    private Rigidbody rb;
    private GameObject arrow;
    private bool isDragging = false;                         //드래그 중인지
    private Vector3 startPos;                               //드래그 시작위치

    //턴관리
    static bool isAnyBallPlaying = false;                       //어떤 공이라도 턴 중인지
    static bool isAnyBallMoveing = false;                       //어떤 공이라도 움직이는지


    // Start is called before the first frame update
    void Start()
    {
        SetupBall();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        UpdateArrow();
    }
    void SetupBall()                                    //공설정하기
    {

        rb = GetComponent<Rigidbody>();                                               //물리컴포넌트 가져오기
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();                //없ㅇ을경우 붙여준다

        rb.mass = 1;
        rb.drag = 1;
    }
    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.2f;


    }

    void HandleInput()
    {
        if (IsMoving()) return;

        if (Input.GetMouseButtonDown(0))
        {

            StartDrag();

        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {

            Shoot();

        }


    }

    void StartDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
         {
            if (hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                startPos = Input.mousePosition;
                CreateArrow();
                Debug.Log("드래그 시작");

            }


        }
    }

    void Shoot()
    {
        Vector3 mouseDelta = Input.mousePosition - startPos;                //마우스 이동거리로 힘 계산
        float force = mouseDelta.magnitude * 0.01f * power;

        if (force < 5) force = 5;                           //최소힘보정

        Vector3 direction = new Vector3(-mouseDelta.x, 0, -mouseDelta.y).normalized;                    //방향계산

        rb.AddForce(direction * force, ForceMode.Impulse);

        isDragging = false;
        Destroy(arrow);
        arrow = null;

        Debug.Log("발사 힘:" + force);

    }
    void CreateArrow()
    {
        if(arrow != null)
        {
            Destroy(arrow);
        }

        arrow = new GameObject("Arrow");
        SpriteRenderer sr = arrow.AddComponent<SpriteRenderer>();

        sr.sprite = arrowSprite;
        sr.color = Color.green;
        sr.sortingOrder = 10;

        arrow.transform.position = transform.position + Vector3.up;
        arrow.transform.localScale = Vector3.one;
    }


    void UpdateArrow()
    {
        if (!isDragging || arrow == null) return;

        Vector3 mouseDelta = Input.mousePosition - startPos;
        float distance = mouseDelta.magnitude;

        float size = Mathf.Clamp(distance * 0.01f, 0.5f, 2f);
        arrow.transform.localScale = Vector3.one * size;

        SpriteRenderer sr = arrow.GetComponent<SpriteRenderer>();
        float colorRatio = Mathf.Clamp01(distance * 0.005f);
        sr.color = Color.Lerp(Color.green, Color.red, colorRatio);

        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

        if(distance > 10f)
        {
            Vector3 direction = new Vector3(-mouseDelta.x, 0, -mouseDelta.y);
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(90, angle, 0);
        }



    }




}
