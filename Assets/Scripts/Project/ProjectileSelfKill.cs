using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSelfKill : MonoBehaviour
{
    [Range(1f, 5f)]
    public float timeToDie = 1.0f;
    [Range(1f, 10f)]
    public float shootSpeed = 1.0f;
    private Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D colided){
        if(colided.gameObject.tag !="Player")
        {
            Debug.Log("buum!");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(killMyself());
        rb = gameObject.GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(0,10f * shootSpeed);

    }
    private IEnumerator killMyself()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }

}
