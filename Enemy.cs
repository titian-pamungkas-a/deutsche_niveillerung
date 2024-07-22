using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int hp, damage, armor;
    private Animator animator;
    [SerializeField]
    private GameObject bulletPosition;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private EndingScript ending;
    [SerializeField]
    private AudioSource attackSound, hurtSound;

    public int Hp { get => hp; }

    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakingDamage(int playerDamage)
    {
        this.hp -= (playerDamage-this.armor);
        animator.SetTrigger("GetAttack");
        hurtSound.Play();
        if (this.hp <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("GoAttack");
        StartCoroutine("AttackAnimation");
        
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.8f);
        attackSound.Play();
        GameObject go = Instantiate(bulletPrefab, bulletPosition.transform.position, bulletPosition.transform.rotation);
        go.GetComponent<BulletEnemy>().Damage = this.damage;
    }

    private void Die()
    {
        animator.SetTrigger("GoDie");
        StartCoroutine("Disappear");
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        ending.StartCoroutine("Win");
    }
}
