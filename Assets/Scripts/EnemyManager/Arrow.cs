using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private Transform target;
    Vector3 dir;

    public float speed = 50f;
    public int Damage = 10;
    
    //static Vector3 rout;

    public void Seek(Transform _target) {
        target = _target;
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

        //rout = dir;
        //transform.rotation = Quaternion.LookRotation(dir);              //x,y로테이션값만 변경되는중 추후 변경 필요
        dir = target.position - transform.position;
        transform.rotation = Quaternion.Euler(0,0,dir.z);
        float distanceThisFrame = speed * Time.deltaTime;
        
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    public void HitTarget() {
        Destroy(gameObject);
    }
}
