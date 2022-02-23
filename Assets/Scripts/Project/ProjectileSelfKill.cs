using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSelfKill : MonoBehaviour
{
    [Range(1f, 5f)]
    public float timeToDie = 1.0f;
    [Range(1f, 10f)]
    public float shootSpeed = 1.0f;
    [Range(1f, 10f)]
    public float shootDamage = 1.0f;
    private Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D colided){
        if(colided.gameObject.tag == "Enemy"){
            if(gameObject.tag != "Enemy_Shoot"){
                Destroy(gameObject);
            }else{
                Physics2D.IgnoreCollision(colided.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }else{
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private float upOrDown;
    void Start()
    {
        StartCoroutine(killMyself());
        if(gameObject.tag == "Player_Shoot"){
            upOrDown = 10f;
        }else{
            upOrDown = -10f;
        }
        rb = gameObject.GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(0,upOrDown * shootSpeed);

    }
    private IEnumerator killMyself()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }

}
