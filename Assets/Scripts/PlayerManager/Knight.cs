using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour {

    private bool WallCheck = false;         //벽을 부딛혔는지에 대한 확인 변수

    public bool EnemyAllDie;            //모든 적을 다 처지 했는지 확인 변수

    public Image HealthGage;            // HP게이지 이미지를 받아 오는 변수

    public Text LevelText;              //레벨을 표시 하기 위한 변수

    //===========['레벨'+1시 '체력'과 '공격력' +20%, '이동속도' '공격속도' 10% 상승]
    public float firstHealth;       //설정된 체력값 1번만 작동

    public float HealthPoint;        //체력

    private int AttackPower;        //공격력

    private int Level;      //레벨


    [SerializeField]
    private float MoveSpeed;        //이동 속도

    private float AttackSpeed;      //공격 속도


    //======================================================================//

    public GameObject Crown;        //게임 오브젝트

    private GameObject Up;          //포지션 오브젝트

    private GameObject Mid;         //포지션 오브젝트

    private GameObject Down;        //포지션 오브젝트

    [SerializeField]
    private GameObject ButtonObject;        //버튼매니저 관련 값 받아오기 위한 변수


    private Vector2 AnyWhere;           //방향 설정 변수

    private float Timecount = 0;            //시간에 따라 레벨업에 변화를 주는 변수

    private float t = 0;            //시간 초기화

    private float AttackDelay;          // 공격 지연 설정 시간

    private float attackDelay_Reset;        //공격 지연시간 초기화

    [HideInInspector]
    public float skillTime = 0;         //다목적 값 시간을 설정 하는 변수, 시작 시간은 무조건 0으로
    [HideInInspector]
    public float buff = 1;             // 다목적 값 상,하양 할수 있는 변수, 버프 값은 무조건 1로 초기화 (0으로 해버리면 곱셈할때 0이 되버릴수도 있음)

    EnemyWall enemyWall;            // 성벽 클래스

    ButtonManager buttonManager;        //버튼 매니저 클래스

    void OnTriggerEnter2D(Collider2D collision)             //충돌이 입력 되었을시
    {
        if (collision.gameObject.tag == "Arrow")
        {
            HealthPoint -= collision.GetComponent<Arrow>().Damage;
        }

        if (collision.gameObject.tag == "EnemyWall")            //Tag가 EnemyWall일시 작동
        {
            WallCheck = true;               //벽 충돌 확인 변수를 참으로 변경
            enemyWall = collision.GetComponent<EnemyWall>();            //성벽 클래스에 성벽에 대한 컴포넌트
        }
    }

    void Start()
    {
        //=========오브젝트 태그를 이용해 오브젝트를 찾기==============//
        Up = GameObject.FindGameObjectWithTag("Up");
        Mid = GameObject.FindGameObjectWithTag("Middle");
        Down = GameObject.FindGameObjectWithTag("Down");


        //=======오브젝트 이름을 이용해 오브젝트를 찾은뒤 컴포넌트=======//
        ButtonObject = GameObject.Find("ButtonManager");
        buttonManager = ButtonObject.GetComponent<ButtonManager>();



        AttackDelay = 2f;           //공격 지연 시간
        attackDelay_Reset = AttackDelay;        //공격 지연시간 초기화 값 대입
        //HealthPoint = 30;
        AttackPower = 10;

        Level = 1;                  //시작 플레이어 레벨은 무조건 1

        Crown.SetActive(false);     //왕관 오프라인

        firstHealth = HealthPoint;      //시작 체력을 받아 넘김
    }

    void Update()
    {
        HealthGage.fillAmount = HealthPoint / firstHealth;          //현재 체력에서 초기 체력값을 나눈뒤 값을 fillAmout값으로 변경

        //=======플레이어 태그 일시 동작 하는 조건문==============//
        if (gameObject.tag == "Player")
        {       //태그 변경시 사용 가능
            PlayerMove();
            GetInput();
            LevelUp();
            Crown.SetActive(true);
            GetComponent<SpriteRenderer>().sortingLayerName = "PlayerPos";
            GetComponent<SpriteRenderer>().sortingOrder = 100;
            buttonManager.OnButton(Level);
            LevelText.text = Level.ToString();
        }


        if (gameObject.tag == "Unit")
        {     //AI매커니즘

            if (WallCheck == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                if (AttackDelay <= 0)
                {
                    Attack();
                    AttackDelay = attackDelay_Reset;
                }
                AttackDelay -= Time.deltaTime;
                EnemyAllDie = enemyWall.DieTrue;
            }
            else
            {
                AiMoveMent(buff, skillTime);
            }


        }


        if (transform.position.x >= 9.86f)
        {        //지정 좌표값보다 크거나 같을때
            Destroy(gameObject);            //게임오브젝트 파괴
        }

        DieObject();

        if (EnemyAllDie)
        {
            Time.timeScale = 0;
        }
    }

    //===========칼든 병사와 활 병사의 차이점을 둔다=================//
    public void Attack()
    {
        enemyWall.Health -= AttackPower;
    }

    public void PlayerMove()
    {
        transform.Translate(AnyWhere * MoveSpeed * Time.deltaTime);     //이동방향*이동속도*실시간
    }

    public int LevelUp()
    {         //시간에 따라 레벨업
        Debug.Log(Level);
        Timecount += Time.deltaTime;
        if (Timecount >= 5 * Level)
        {      //시간이 레벨*5(초)만큼 흐를때 레벨 동작
            Level++;        //레벨 1증가

            //체력과 공격력, 20% 증가
            HealthPoint += (HealthPoint / 10) * 2;
            AttackPower += (AttackPower / 10) * 2;

            //이동속도와 공격속도 10%증가
            MoveSpeed += MoveSpeed / 10;
            AttackSpeed += AttackSpeed / 10;

            Timecount = 0;
        }
        return Level; //레벨 업
    }

    public void DieObject()
    {
        if (HealthPoint <= 0)
        {         //HP가 0이하로 떨어졌을때
            buttonManager.OffButton();
            Destroy(gameObject);       //게임 오브젝트 제거

        }
    }

    public void AiMoveMent(float buff, float skillTime)
    {            //AI이동 함수 float형 버프 값, float형 스킬 시간
        if (skillTime != 0)
        {
            t += Time.deltaTime;
        }
        if (t <= skillTime)            //스킬 설정 시간 보다 작거나 같을 동안 버프 실행
        {
            transform.Translate(Vector2.right * (MoveSpeed * buff) * Time.deltaTime);      //우측으로 기본 속도(인스펙터 창 선언)
                                                                                           //Debug.Log();

        }
        else
        {
            t = 0;
            this.buff = 1;
            this.skillTime = 0;
        }

    }

    private void GetInput()
    {
        AnyWhere = Vector2.zero;     //좌 우위치값

        if (Input.GetKey(KeyCode.LeftArrow))
        {      //왼쪽 방향키
            AnyWhere += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {      //오른쪽 방향키
            AnyWhere += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {        //위쪽 방향키를 누르고 떼었을때
            if (transform.position.y == Down.GetComponent<Transform>().position.y)      //맨 아래쪽에 있을때
            {
                transform.position = new Vector2(transform.position.x, Mid.GetComponent<Transform>().position.y);       //새로 벡터2의 값을 잡고 현재 포지션에 대입 (현재 진행되고 있는 x값, 좌표로 잡아둔 y값)

            }
            else if (transform.position.y == Mid.GetComponent<Transform>().position.y)
            {        //중앙에 위치해있을때

                transform.position = new Vector2(transform.position.x, Up.GetComponent<Transform>().position.y);        ////새로 벡터2의 값을 잡고 현재 포지션에 대입 (현재 진행되고 있는 x값, 좌표로 잡아둔 y값)

            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {      //아래쪽 방향키를 누르고 떼었을때
            if (transform.position.y == Up.GetComponent<Transform>().position.y)
            {
                transform.position = new Vector2(transform.position.x, Mid.GetComponent<Transform>().position.y);       ////새로 벡터2의 값을 잡고 현재 포지션에 대입 (현재 진행되고 있는 x값, 좌표로 잡아둔 y값)


            }
            else if (transform.position.y == Mid.GetComponent<Transform>().position.y)
            {

                transform.position = new Vector2(transform.position.x, Down.GetComponent<Transform>().position.y);      ////새로 벡터2의 값을 잡고 현재 포지션에 대입 (현재 진행되고 있는 x값, 좌표로 잡아둔 y값)

            }

        }
        if (Input.GetKey(KeyCode.Space))
        {          //공격 키

        }
    }
}