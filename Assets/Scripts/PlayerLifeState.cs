using System.Collections;
using UnityEngine;

public class PlayerLifeState : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public int currentHealth;
    public int maxHealth = 3;
    private bool playerIFrame = false;

    [SerializeField] private Material flashMaterial;   
    SpriteRenderer sr;
    Material defaultMaterial;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        defaultMaterial = sr.material;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        playerIFrame = true;
        if (currentHealth == 0)
        {
            CharacterDeath();
        }
        StartCoroutine(Flash());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traps") && playerIFrame == false)
        {
            TakeDamage();
            AudioManager.instance.PlayEffectSound("Hitted");
            StartCoroutine(Knockback(1.5f, rb.transform.position));
            StartCoroutine(Invincible(1.3f));
        }
    }

    private void CharacterDeath()
    {
        rb.velocity = new Vector2(0, 0);
        animator.SetTrigger("characterDeath");
    }

    IEnumerator Invincible(float time)
    {
        yield return new WaitForSeconds(time);
        playerIFrame = false;
    }

    IEnumerator Knockback(float knockbackDuration, Vector3 knockbackDirection)
    {
        float timer = 0;
        if(knockbackDuration > timer)
        {
            timer += Time.deltaTime;

            if(sr.flipX == false)
                rb.AddForce(new Vector3(knockbackDirection.x * -200, knockbackDirection.y, transform.position.z));
            else
                rb.AddForce(new Vector3(knockbackDirection.x * 200, knockbackDirection.y, transform.position.z));
        }

        yield return 0;
    }

    IEnumerator Flash()
    {
        sr.material = flashMaterial;
        yield return new WaitForSeconds(0.12f);
        sr.material = defaultMaterial;
        if (playerIFrame)
        {
            StartCoroutine(KeepFlash());
        }
    }

    IEnumerator KeepFlash()
    {
        yield return new WaitForSeconds(0.12f);
        if (playerIFrame)
        {
            StartCoroutine(Flash());
        }

    }
}
