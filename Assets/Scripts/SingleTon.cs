using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour
{
    private Vector3 mousePos;
    public static SingleTon instance = null;

    void Awake()
    {
        if (instance == null)
        {
            HitCollider();
            MousePosition();
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

    }

    public Collider2D HitCollider() {
        RaycastHit2D mousehit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

        return mousehit.collider;
    }

    public Vector3 MousePosition() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

}
