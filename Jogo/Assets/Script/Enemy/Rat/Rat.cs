using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [Header("Moviment")]
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int nextId = 0 ;
    [SerializeField] private List<Transform> points;
    private int idChangeValue = 1;

    [Header("damage")]
    [SerializeField] private int baseDamage = 10;

    public int BaseDamage { get => baseDamage; set => baseDamage = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        MoveToNextPoint();
    }

    public void MoveToNextPoint(){
        Transform goalPoint = points[nextId];

        if(goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed);

        if(Vector2.Distance(transform.position, goalPoint.position) < 1f){
            if(nextId == points.Count -1 ){
                idChangeValue -=1;
            }

            if(nextId == 0){
                idChangeValue =1;
            }

            nextId += idChangeValue;
        }
    }
}
