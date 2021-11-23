using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    private void Start()
    {
        if (Thrown)
        {
            var direction = -transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, (ForceMode2D)ForceMode.Impulse);
        }
        transform.Translate(LaunchOffset);

        Destroy(gameObject, 5);
    }

    public void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }
        Destroy(gameObject);
    }
}
