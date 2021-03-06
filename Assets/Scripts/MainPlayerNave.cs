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
        this.vidaBase = 2;
        this.speedBase = 500f;
        this.dmgMultiplyBase = 1f;
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
        if (Input.GetKeyDown("z")){
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
        GameObject proJ = Instantiate(projectile,new Vector3(transform.position.x,transform.position.y + 0.7f,transform.position.z),transform.rotation);
        proJ.GetComponent<ProjectileSelfKill>().shootDamage = proJ.GetComponent<ProjectileSelfKill>().shootDamage * dmgMultiplyBase;
        proJ.tag = "Player_Shoot";
    }

    void OnCollisionEnter2D(Collision2D colided)
    {
        if(colided.gameObject.tag !="Player_Shoot" && colided.gameObject.tag != "Bounds"){
            TakeDmg(colided.gameObject.GetComponent<ProjectileSelfKill>().shootDamage);
        }

    }
    public override void TakeDmg(float dmgToTake)
    {
        vidaBase = vidaBase - dmgToTake;
        if(vidaBase <= 0)
        {
            Die();
            Destroy(gameObject);
        }else
        {
            Debug.Log(vidaBase);
        }
    }
    public override void Die()
    {
        Debug.Log("Fuen Die");
    }
}
