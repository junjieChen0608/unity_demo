
using UnityEngine;

public class BanditsJump : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 4.0f;

    int moveDir = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * moveDir * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bandit bandit = GetComponent<Bandit>();
        if (bandit.getStatus() && collision.gameObject.name == "Wall")
        {
            moveDir = -1;
        }
        else if(bandit.getStatus() && collision.gameObject.name == "Ground")
        {
            moveDir = 0;
        }else if (!bandit.getStatus())
        {
            moveDir *= -1;
        }
    }
}
