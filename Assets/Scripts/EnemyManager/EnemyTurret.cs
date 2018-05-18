using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {

    /*
    public List<GameObject> enemiesUnit = new List<GameObject>();

    public Transform target;
    public float range = 15f;
    public string UnitTag = "Unit";
    public string PlayerTag = "Player";

    //public string[] UnitTag = new string[2];



    // Use this for initialization
    void Start () {

        //UnitTag[0] = "Unit";
        //UnitTag[1] = "Player";

        InvokeRepeating("UpDateTarget", 0f, 0.5f);
	}


    void UpDateTarget() {
        enemiesUnit.Add(GameObject.FindWithTag(UnitTag));
        //enemiesUnit.Add(GameObject.FindWithTag(PlayerTag));
        //var enemiesUnit = GameObject.FindGameObjectsWithTag(UnitTag).ToList();

        //var enemiesUnit = GameObject.FindGameObjectsWithTag(UnitTag).ToList();
        //enemiesUnit.Add(GameObject.FindGameObjectWithTag(PlayerTag));

        //GameObject[] enemiesUnit = GameObject.FindGameObjectsWithTag(UnitTag[]);
        //GameObject[] enemiesUnit = GameObject.FindGameObjectWithTag(PlayerTag);
        //GameObject.FindGameObjectWithTag(PlayerTag);

        //GameObject[] enemiesUnit = GameObject.FindGameObjectsWithTag(UnitTag[]);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject Enemy in enemiesUnit) {
            float distaceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            if (distaceToEnemy < shortestDistance) {
                shortestDistance = distaceToEnemy;
                nearestEnemy = Enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        }
        
    }

	// Update is called once per frame
	void Update () {
        if (target == null) {
            return;
        }
	}
    */

    //public List<GameObject> EnemyUnit = new List<GameObject>();

    public Transform target;
    public float range = 10f;

    public float FireRate = 1f;
    private float fireCountDown = 0.5f;

    public GameObject ArrowPrefab;
    public Transform firePoint;

    //======자신의 포지션 입력 받을 변수===========//
    private GameObject TurretUp;
    private GameObject TurretMid;
    private GameObject TurretDown;

    //======적 유닛 포지션 입력 받을 변수==========//
    private GameObject Up;
    private GameObject Mid;
    private GameObject Down;

    //public Player player;
    //public string PlayerTag = "Player";

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Unit" || collision.tag == "Player") {
    //        EnemyUnit.Add(collision.gameObject);
    //    }
    //}

    void Target() {

        GameObject[] UnitTag_1 = GameObject.FindGameObjectsWithTag("Unit");             //유닛 태그를 배열로 입력
        GameObject[] UnitTag_2 = GameObject.FindGameObjectsWithTag("Player");           //플레이어 태그를 배열로 입력
        //EnemyUnit.Add();
        GameObject[] enemiesUnit = UnitTag_1.Concat(UnitTag_2).ToArray();
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject Enemy in enemiesUnit) {
            float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy; ;
                nearestEnemy = Enemy;
                //player = Enemy.GetComponent<Player>();
            }
        }
        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        }
    }

    void Start()
    {
        InvokeRepeating("Target", 0f, 0.5f);

        Up = GameObject.Find("Upline");
        Mid = GameObject.Find("Middleline");
        Down = GameObject.Find("Downline");

        TurretUp = GameObject.Find("UpTower");
        TurretMid = GameObject.Find("MidTower");
        TurretDown = GameObject.Find("DownTower");
    }

    void Update()
    {
        if (target != null)
        {
            if (target.position.y == Up.transform.position.y)
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, TurretUp.transform.position.y, this.transform.position.z);
            }
            if (target.position.y == Mid.transform.position.y)
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, TurretMid.transform.position.y, this.transform.position.z);
            }
            if (target.position.y == Down.transform.position.y)
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, TurretDown.transform.position.y, this.transform.position.z);
            }
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / FireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
        else
            target = null;



    }

    void Shoot() {
        GameObject ArrowGO = (GameObject)Instantiate(ArrowPrefab, firePoint.position, firePoint.rotation);           //복사 생성
        Arrow arrow = ArrowGO.GetComponent<Arrow>();



        if (arrow != null) {
            arrow.Seek(target);
        }
        //Instantiate(ArrowPrefab, firePoint.position, firePoint.rotation);           //복사 생성
        //Debug.Log("Shoot");
    }


private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }
    
    
}
