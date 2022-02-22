using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerNave : AbsNave
{
    private Rigidbody2D rb;
    private Vector2 moveVect;
    [Range(1f, 10.0f)]
    public float speedMultiply;
    public GameObject projectile;
    public MainPlayerNave()
    {
        this.vidaBase = 1;
        this.speedBase = 500f;
    }

    public MainPlayerNave(int vidaBase, float speedBase)
    {
        this.vidaBase = vidaBase;
        this.speedBase = speedBase;
    }

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        this.speedMultiplyed = ( speedBase * speedMultiply);
        this.moveVect = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (Input.GetKeyDown("space")){
            Shoot();
        }

        //speedBase = speedBase * SpeedMultiply;
    }
    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveVect.x * speedMultiplyed * Time.deltaTime, rb.velocity.y);
    }

    public override void Shoot()
    {
        Instantiate(projectile,new Vector3(transform.position.x,transform.position.y + 0.8f,transform.position.z),transform.rotation);
        //Debug.Log( Quaternion.identity);

    }


    public override void TakeDmg()
    {
        Debug.Log("Fuen TakeDmg");
    }
    public override void Die()
    {
        Debug.Log("Fuen Die");
    }
}
