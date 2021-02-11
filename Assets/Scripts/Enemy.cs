using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float timeLimit;
    float timer=0;
    [SerializeField]
    Vector2 dir = Vector2.right;

    SpriteRenderer spr;

    void Awake(){
        spr=GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        transform.Translate(dir*moveSpeed*Time.deltaTime);
        timer += Time.deltaTime;
        if(timer >= timeLimit){
            timer=0;
            dir.x = dir.x > 0 ? -1 : 1;
            spr.flipX = FlipSprite;
        }
    }

    bool FlipSprite{
        get => dir.x > 0 ? true : false;
    }
}
