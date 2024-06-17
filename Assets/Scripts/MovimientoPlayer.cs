using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPlayer : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float axisX, axisY;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isDead)
        {
            Die();
        }

        if (isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        axisX = Input.GetAxisRaw("Horizontal");
        axisY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(axisX, axisY) * speed;

        if (axisX != 0 || axisY != 0)
        {
            anim.SetInteger("State", 1); 

            if (axisX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (axisX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            anim.SetInteger("State", 0);
        }
    }

    void Die()
    {
        anim.SetInteger("State", 2);
        anim.SetTrigger("Die"); 
        isDead = true;
        StartCoroutine(RestartSceneAfterDelay(5f));
    }

    IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



