using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private Transform target;
    Player player;

    public float speed = 50f;
    public int Damage = 1;
    

    public void Seek(Transform _target) {
        target = _target;
        player = target.GetComponent<Player>();
    }

    void Start()
    {
    }

    void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(dir);              //x,y로테이션값만 변경되는중 추후 변경 필요
        transform.rotation = Quaternion.Euler(0, 0, dir.z);
        float distanceThisFrame = speed * Time.deltaTime;
        
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            //gameObject.GetComponent<Player>().HealthPoint -= Damage;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    public void HitTarget() {
        player.HealthPoint -= Damage;
        //player.HealthPoint -= Damage;
        Destroy(gameObject);
    }
}
