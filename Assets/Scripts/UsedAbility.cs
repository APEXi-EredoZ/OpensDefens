using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class UsedAbility : MonoBehaviour {

    public Collider2D Hit;          // 콜라이더 확인 변수
    [HideInInspector]
    public GameObject[] Line;       // 1차원 배열
    //GameObject[] Unit;
    private int i;      // 개수 파악하는 정수형 변수로 설정

    public GameObject WhiteUnit;           // 유닛 오브젝트 받는 변수
    public GameObject BlackUnit;            //유닛 오브젝트를 받는 변수

    //Player ai = new Player();

    //List<GameObject> Up = new List<GameObject>();
    

    private float Ability_Buff;     //버프 값
    private float Ability_Time;     //지속시간

    bool SpeedUp1 = false;      //참 거짓 판별변수
    bool SpeedDown1 = false;
    bool SpwanWhite = false;         //참 거짓 판별변수
    bool SpwanBlack = false;

    bool HealthUp = false;
    bool HealthDown = false;

    //private Vector3 mousePos;

    public void Start()
    {
        //ai = GetComponent<Player>();
        //ai = GetComponent<Player>().AiMoveMent();
        Line[0] = GameObject.Find("Up");        //[0]번 배열에 Up이라는 오브젝트를 찾아서 넣기
        Line[1] = GameObject.Find("Middle");    //[1]번 배열에 Middle이라는 오브젝트를 찾아서 넣기  
        Line[2] = GameObject.Find("Down");      //[2]번 배열에 Down이라는 오브젝트를 찾아서 넣기

        Line[3] = GameObject.Find("Upline");
        Line[4] = GameObject.Find("Middleline");
        Line[5] = GameObject.Find("Downline");
    }
    public void Update()
    {
        if (SpeedUp1 == true){          //속도 스킬 호출시 스피드업1 변수가 참으로 변경 되면서 실행 가능
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {        //마우스 좌클릭시 UI버튼을 누르지 않았을시
                Hit = SingleTon.instance.HitCollider();             //Hit 콜라이더2D에다가 클릭한 오브젝트 대입
                if (Hit != null){           //마우스 클릭한곳이 null(빈공간이 아닐시)
                    if (Hit.gameObject.name == "Up")                    //Hit내에 들어간 게임 오브젝트 이름이 Up일때 동작
                    {
                        //ai.AiMoveMent(Ability_Buff,Ability_Time);
                        for (int i = 0; i < Line[0].GetComponent<Line>().Unit.Count; i++) {                 //Line[0]번 내의 Line코드의 리스트 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                            Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = Ability_Buff;        //버프 값 변경
                            Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = Ability_Time;       //지속 시간 설정
                        }
                        SpeedUp1 = false;       //버튼 초기화
                    }
                    if (Hit.gameObject.name == "Middle")                //Hit내에 들어간 게임 오브젝트 이름이 Middle일때 동작
                    {
                        for (int i = 0; i < Line[1].GetComponent<Line>().Unit.Count; i++)                   //Line[1]번 내의 Line코드의 리스트를 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = Ability_Buff;        //버프 값 변경
                            Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = Ability_Time;       //지속 시간 변경
                        }
                        SpeedUp1 = false;       //버튼 초기화
                    }
                    if (Hit.gameObject.name == "Down")                  //Hit내에 들어간 게임 오브젝트 이름의 Middle일때 동작
                    {
                        for (int i = 0; i < Line[2].GetComponent<Line>().Unit.Count; i++)                   //Line[2]번 내의 Line코드의 리스트를 참조 하여 유닛의 개수를 파악후, i에다가 개수를 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = Ability_Buff;        //버프 값 변경
                            Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = Ability_Time;       //지속 시간 변경
                        }
                        SpeedUp1 = false;       //버튼 초기화
                    }
                }
            }
            //if (Spwan == true){
            //    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            //        Hit = SingleTon.instance.HitCollider();
            //        if (Hit.gameObject.name == "Up")
            //        {
            //            GameObject tmp = Instantiate(gameObject);
            //            tmp.transform.position = new Vector3(-6.25f, 2.69f, 1.0f);
            //            tmp.transform.rotation = new Quaternion(0, 0, 0, 0);
            //            Spwan = false;
            //        }
            //    }
            //}
        }

        if (SpeedDown1 == true)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())        //마우스 좌클릭시 UI버튼을 누르지 않았을시
            {
                Hit = SingleTon.instance.HitCollider();             //Hit 콜라이더2D에다가 클릭한 오브젝트 대입                
                if (Hit != null)           //마우스 클릭한곳이 null(빈공간이 아닐시)
                {
                    if (Hit.gameObject.name == "Up")                    //Hit내에 들어간 게임 오브젝트 이름이 Up일때 동작
                    {
                        for (int i = 0; i < Line[0].GetComponent<Line>().Unit.Count; i++)                 //Line[0]번 내의 Line코드의 리스트 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = Ability_Buff;        //버프 값 변경
                            Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = Ability_Time;       //지속 시간 설정
                        }
                        SpeedDown1 = false;       //버튼 초기화
                    }
                    if (Hit.gameObject.name == "Middle")                    //Hit내에 들어간 게임 오브젝트 이름이 Up일때 동작
                    {
                        for (int i = 0; i < Line[1].GetComponent<Line>().Unit.Count; i++)                 //Line[0]번 내의 Line코드의 리스트 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = Ability_Buff;        //버프 값 변경
                            Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = Ability_Time;       //지속 시간 설정
                        }
                        SpeedDown1 = false;       //버튼 초기화
                    }
                    if (Hit.gameObject.name == "Down")                    //Hit내에 들어간 게임 오브젝트 이름이 Up일때 동작
                    {
                        for (int i = 0; i < Line[2].GetComponent<Line>().Unit.Count; i++)                 //Line[0]번 내의 Line코드의 리스트 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().buff = Ability_Buff;        //버프 값 변경
                            Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().skillTime = Ability_Time;       //지속 시간 설정
                        }
                        SpeedDown1 = false;       //버튼 초기화
                    }
                }
            }
        }

        if (HealthUp == true) {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())        //마우스 좌클릭시 UI버튼을 누르지 않았을시
            {
                Hit = SingleTon.instance.HitCollider();             //Hit 콜라이더2D에다가 클릭한 오브젝트 대입                
                if (Hit != null)           //마우스 클릭한곳이 null(빈공간이 아닐시)
                {
                    if (Hit.gameObject.name == "Up")                    //Hit내에 들어간 게임 오브젝트 이름이 Up일때 동작
                    {
                        for (int i = 0; i < Line[0].GetComponent<Line>().Unit.Count; i++)                 //Line[0]번 내의 Line코드의 리스트 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().HealthPoint += Line[0].GetComponent<Line>().Unit[i].GetComponent<Player>().HealthPoint;        //현재 hp와 같은 값을 증가
                        }
                        HealthUp = false;       //버튼 초기화
                    }
                    if (Hit.gameObject.name == "Middle")                    //Hit내에 들어간 게임 오브젝트 이름이 Up일때 동작
                    {
                        for (int i = 0; i < Line[1].GetComponent<Line>().Unit.Count; i++)                 //Line[0]번 내의 Line코드의 리스트 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().HealthPoint += Line[1].GetComponent<Line>().Unit[i].GetComponent<Player>().HealthPoint;        //버프 값 변경
                        }
                        HealthUp = false;       //버튼 초기화
                    }
                    if (Hit.gameObject.name == "Down")                    //Hit내에 들어간 게임 오브젝트 이름이 Up일때 동작
                    {
                        for (int i = 0; i < Line[2].GetComponent<Line>().Unit.Count; i++)                 //Line[0]번 내의 Line코드의 리스트 참조 하여 유닛의 개수를 파악후, i에다가 개수 대입후, i의 개수 만큼 내용 반복
                        {
                            Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().HealthPoint += Line[2].GetComponent<Line>().Unit[i].GetComponent<Player>().HealthPoint;        //버프 값 변경
                        }
                        HealthUp = false;       //버튼 초기화
                    }
                }
            }
        }

        spwan();            //스폰 함수 호출
        //if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && Hit.tag != "Unit" && Hit.tag != "Player")
        //{
        //    Hit = SingleTon.instance.HitCollider();
        //}
       // if (Hit != null)
        //{
            //if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
           // {

                //Debug.Log("작동중2");
                //Debug.Log(Hit);
                //if (Hit.gameObject.name == "Up")
                //{
                //    Debug.Log("윗라인");
                //    ai.AiMoveMent(Ability_Buff);        //윗라인 선택시 Player클래스 내의 AiMoveMent()함수의 값을 Ability_Buff로 값을 변경
                //}
                //if (Hit.tag == Line[1].name)
                //{
                //    Debug.Log("중앙라인");
                //}
                //if (Hit.tag == Line[2].name)
                //{
                //    Debug.Log("아랫라인");
                //}
           // }
        //}

    }
    public void SpeedUp_skill() {       // 버튼에다가 코드를 실행시킬때 넣는 함수 (속도 증가)
        SpeedUp1 = true;            // 참으로 변경 후 Update에서 실행
        Ability_Buff = 5.0f;        // 버프줄 값을 대입
        Ability_Time = 3.0f;        // 스킬 타임 설정
        
        //      if (Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject())
        //{
        //Hit = SingleTon.instance.HitCollider();
        //if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //{
        //    Debug.Log(Hit.name);
        //}
        //mousePos = SingleTon.instance.MousePosition();
        //}
        //Debug.Log(Hit.name);
        //    if (Hit.GetComponent<Player>().line == Player.Line.Up){
        //        Debug.Log("윗라인");
        //    }
        //    if (Hit.tag == Line[1].name) {
        //        Debug.Log("중앙라인");
        //    }
        //    if (Hit.tag == Line[2].name){
        //        Debug.Log("아랫라인");
        //    }

        //if (Hit != null)
        //{
        //    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //    {
        //        Debug.Log(Hit);
        //        if (Hit.gameObject.name == "Up")
        //        {
        //            Debug.Log("윗라인");
        //            ai.AiMoveMent(Ability_Buff);        //윗라인 선택시 Player클래스 내의 AiMoveMent()함수의 값을 Ability_Buff로 값을 변경
        //        }
        //        if (Hit.tag == Line[1].name)
        //        {
        //            Debug.Log("중앙라인");
        //        }
        //        if (Hit.tag == Line[2].name)
        //        {
        //            Debug.Log("아랫라인");
        //        }
        //    }
        //}
        //if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //{
        //    Debug.Log("작동중2");

        //        //if (Hit.gameObject.name == "UP")
        //        //{
        //        //    Debug.Log("윗라인");
        //        //}
        //        //if (Hit.gameObject.name == "Middle")
        //        //{
        //        //    Debug.Log("중앙라인");
        //        //}
        //        //if (Hit.gameObject.name == "Down")
        //        //{
        //        //    Debug.Log("아랫라인");
        //        //}
        //    }
        
    }

    public void SpeedDown_skill() {
        SpeedDown1 = true;
        Ability_Buff = 0.2f;
        Ability_Time = 5.0f;
    }

    public void HelathUp_skill() {
        HealthUp = true;
    }

    public void spwan()     //소환 함수
    {
        //Spwan = true;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())      //마우스 좌클릭을 하였고, 캔버스 내의 UI버튼을 누르지 않았을시
        {
            Hit = SingleTon.instance.HitCollider();     //클릭한 오브젝트 콜라이더를 hit에 대입

            if (Hit != null)        //마우스 클릭한 곳이 null이 아닐시
            {
                if (Hit.gameObject.name == "Up" && SpwanWhite)           //소환이 가능하고, Hit변수의 콜라이더내의 오브젝트 이름이 Up일때
                {
                    GameObject tmp = Instantiate(WhiteUnit);       // tmp라는 게임 오브젝트 변수를 생성하고, 그 안에 복사 가능한 오브젝트 'WhiteUnit'대입 (인스펙터창에서 변경 가능)후 소환
                    tmp.transform.position = Line[3].transform.position;
                    tmp.transform.rotation = Line[3].transform.rotation;
                    //tmp.transform.position = new Vector3(-8.43f, 0.221f, 3.54f);     // tmp라는 게임오브젝트를 vector3의 x,y,z의 좌표값을 대입
                    //tmp.transform.rotation = new Quaternion(0, 0, 0, 0);        // tmp라는 게임오브젝트를 quaternion의 x,y,z,w의 좌표값을 대입
                    tmp.GetComponent<Player>().GetComponent<SpriteRenderer>().sortingOrder= layerNum;
                    SpwanWhite = false;      //스폰 버튼 초기화
                    //Debug.Log("나는 병신 입니다.");
                }
                if (Hit.gameObject.name == "Middle" && SpwanWhite)           //소환이 가능하고, Hit변수의 콜라이더내의 오브젝트 이름이 Middle일때
                {
                    GameObject tmp = Instantiate(WhiteUnit);       // tmp라는 게임 오브젝트 변수를 생성하고, 그 안에 복사 가능한 오브젝트 'WhiteUnit'대입 (인스펙터창에서 변경 가능)후 소환
                    tmp.transform.position = Line[4].transform.position;
                    tmp.transform.rotation = Line[4].transform.rotation;
                    //tmp.transform.position = new Vector3(-8.43f, -0.85f, 3.54f);     // tmp라는 게임오브젝트를 vector3의 x,y,z의 좌표값을 대입
                    //tmp.transform.rotation = new Quaternion(0, 0, 0, 0);        // tmp라는 게임오브젝트를 quaternion의 x,y,z,w의 좌표값을 대입
                    tmp.GetComponent<Player>().GetComponent<SpriteRenderer>().sortingOrder=layerNum;
                    SpwanWhite = false;      //스폰 버튼 초기화
                    //Debug.Log("나는 병신 입니다.");
                }
                if (Hit.gameObject.name == "Down" && SpwanWhite)           //소환이 가능하고, Hit변수의 콜라이더내의 오브젝트 이름이 Down일때
                {
                    GameObject tmp = Instantiate(WhiteUnit);       // tmp라는 게임 오브젝트 변수를 생성하고, 그 안에 복사 가능한 오브젝트 'WhiteUnit'대입 (인스펙터창에서 변경 가능)후 소환
                    tmp.transform.position = Line[5].transform.position;
                    tmp.transform.rotation = Line[5].transform.rotation;
                    //tmp.transform.position = new Vector3(-8.43f, -1.773f, 3.54f);     // tmp라는 게임오브젝트를 vector3의 x,y,z의 좌표값을 대입
                    //tmp.transform.rotation = new Quaternion(0, 0, 0, 0);        // tmp라는 게임오브젝트를 quaternion의 x,y,z,w의 좌표값을 대입
                    tmp.GetComponent<Player>().GetComponent<SpriteRenderer>().sortingOrder=layerNum;
                    SpwanWhite = false;      //스폰 버튼 초기화
                    //Debug.Log("나는 병신 입니다.");
                }
                if (Hit.gameObject.name == "Up" && SpwanBlack)           //소환이 가능하고, Hit변수의 콜라이더내의 오브젝트 이름이 Up일때
                {
                    GameObject tmp = Instantiate(BlackUnit);       // tmp라는 게임 오브젝트 변수를 생성하고, 그 안에 복사 가능한 오브젝트 'BlackUnit'대입 (인스펙터창에서 변경 가능)후 소환
                    tmp.transform.position = Line[3].transform.position;
                    tmp.transform.rotation = Line[3].transform.rotation;
                    //tmp.transform.position = new Vector3(-8.43f, 0.221f, 3.54f);     // tmp라는 게임오브젝트를 vector3의 x,y,z의 좌표값을 대입
                    //tmp.transform.rotation = new Quaternion(0, 0, 0, 0);        // tmp라는 게임오브젝트를 quaternion의 x,y,z,w의 좌표값을 대입
                    tmp.GetComponent<Player>().GetComponent<SpriteRenderer>().sortingOrder = layerNum;
                    SpwanBlack = false;      //스폰 버튼 초기화
                    //Debug.Log("나는 병신 입니다.");
                }
                if (Hit.gameObject.name == "Middle" && SpwanBlack)           //소환이 가능하고, Hit변수의 콜라이더내의 오브젝트 이름이 Middle일때
                {
                    GameObject tmp = Instantiate(BlackUnit);       // tmp라는 게임 오브젝트 변수를 생성하고, 그 안에 복사 가능한 오브젝트 'BlackUnit'대입 (인스펙터창에서 변경 가능)후 소환
                    tmp.transform.position = Line[4].transform.position;
                    tmp.transform.rotation = Line[4].transform.rotation;
                    //tmp.transform.position = new Vector3(-8.43f, -0.85f, 3.54f);     // tmp라는 게임오브젝트를 vector3의 x,y,z의 좌표값을 대입
                    //tmp.transform.rotation = new Quaternion(0, 0, 0, 0);        // tmp라는 게임오브젝트를 quaternion의 x,y,z,w의 좌표값을 대입
                    tmp.GetComponent<Player>().GetComponent<SpriteRenderer>().sortingOrder =layerNum;
                    SpwanBlack = false;      //스폰 버튼 초기화
                    //Debug.Log("나는 병신 입니다.");
                }
                if (Hit.gameObject.name == "Down" && SpwanBlack)           //소환이 가능하고, Hit변수의 콜라이더내의 오브젝트 이름이 Down일때
                {
                    GameObject tmp = Instantiate(BlackUnit);       // tmp라는 게임 오브젝트 변수를 생성하고, 그 안에 복사 가능한 오브젝트 'BlackUnit'대입 (인스펙터창에서 변경 가능)후 소환
                    tmp.transform.position = Line[5].transform.position;
                    tmp.transform.rotation = Line[5].transform.rotation;
                    //tmp.transform.position = new Vector3(-8.43f, -1.773f, 1.0f);     // tmp라는 게임오브젝트를 vector3의 x,y,z의 좌표값을 대입
                    //tmp.transform.rotation = new Quaternion(0, 0, 0, 0);        // tmp라는 게임오브젝트를 quaternion의 x,y,z,w의 좌표값을 대입
                    tmp.GetComponent<Player>().GetComponent<SpriteRenderer>().sortingOrder = layerNum;
                    SpwanBlack = false;      //스폰 버튼 초기화
                    //Debug.Log("나는 병신 입니다.");
                }
            }
        }
    }
    int layerNum = 0;
    public void spwanWhite() {        // 버튼에다가 코드를 실행 시킬때 넣는 함수 (유닛 소환)
        SpwanWhite = true;       // 참일때 스폰 가능
        layerNum++;
    }

    public void spwanBlack() {
        SpwanBlack = true;
        layerNum++;
    }



    public void Restart() {
        //Application.LoadLevel(Application.loadedLevelName);
    }

    public void Exit()
    {
        
    }
}
