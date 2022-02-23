using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : AbsNave
{
    private Rigidbody2D rb;
    private Vector2 moveVect;
    [Range(1f, 10.0f)]
    public float speedMultiply;
    public GameObject projectile;

    public void Start()
    {
        this.vidaBase = 2;
        this.speedBase = 500f;
        this.dmgMultiplyBase = 1f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(shootRoutine());
    }
    private IEnumerator shootRoutine(){
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Shoot();
        }
    } 
    public override void Shoot()
    {
        GameObject proJ = Instantiate(projectile,new Vector3(transform.position.x,transform.position.y - 0.8f,transform.position.z),transform.rotation);
        proJ.GetComponent<ProjectileSelfKill>().shootDamage = proJ.GetComponent<ProjectileSelfKill>().shootDamage * dmgMultiplyBase;
        proJ.tag = "Enemy_Shoot";
    }
    public float sideToGo = 10f;
    private void Update() 
    {
        this.speedMultiplyed = ( speedBase * speedMultiply);
        this.moveVect = new Vector2(sideToGo, 0);

        //speedBase = speedBase * SpeedMultiply;
    }
    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveVect.x * speedMultiplyed * Time.deltaTime, rb.velocity.y);
    }


    void OnCollisionEnter2D(Collision2D colided)
    {
        if(colided.gameObject.tag !="Enemy_Shoot" && colided.gameObject.tag != "Bounds")
        {
            TakeDmg(colided.gameObject.GetComponent<ProjectileSelfKill>().shootDamage);
        }
        else if(colided.gameObject.tag == "Bounds")
        {
            sideToGo = sideToGo * -1;
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
