using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float trampolineJumpForce;
    private PlayerMovement playerJump;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerJump = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isActive", true);
            playerJump.rb.velocity = new Vector2(playerJump.rb.velocity.x, trampolineJumpForce);
            AudioManager.instance.PlayEffectSound("Trampoline");
        }

        StartCoroutine(Delay(0.7f));
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("isActive", false);
    }
}
