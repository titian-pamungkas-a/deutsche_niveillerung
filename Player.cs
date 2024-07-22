using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp;
    private int dmg;
    private int armor;
    private int criticalChance;
    private int criticalDmg;
    private int healChance;
    private int heal;
    private Animator animator;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletPosition;
    private GameObject gameData;
    private MainManager mainManager;
    [SerializeField]
    private EndingScript ending;
    [SerializeField]
    private AudioSource attackSound, hurtSound;

    public int Hp { get => hp; }

    public Player()
    {
        this.hp = 100;
        this.dmg = 20;
        this.armor = 0;
        this.criticalChance = 0;
        this.criticalDmg = 0;
        this.heal = 0;
        this.healChance = 0;
        print("Masuk Initiator PlayerS");
    }

    private void Start()
    {
        gameData = GameObject.Find("MainManager");
        mainManager = gameData.GetComponent<MainManager>();
        this.hp += mainManager.GetCurrentHp().Item1 + mainManager.GetCurrentCharm().Item1[0];
        this.dmg += mainManager.GetCurrentDamage().Item1 + mainManager.GetCurrentCharm().Item1[1];
        this.armor += mainManager.GetCurrentArmor().Item1 + mainManager.GetCurrentCharm().Item1[2];
        this.criticalChance += mainManager.GetCurrentCharm().Item1[4];
        this.criticalDmg += mainManager.GetCurrentCharm().Item1[3];
        this.heal += mainManager.GetCurrentCharm().Item1[5];
        this.healChance += mainManager.GetCurrentCharm().Item1[6];
    }

    private void Die()
    {
        animator.SetTrigger("GoDie");
        StartCoroutine("Disappear");
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
        ending.StartCoroutine("Lose");
    }

    public void TakingDamgage(int enemyDamage)
    {
        this.hp -= (enemyDamage - this.armor);
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetTrigger("GetAttack");
        hurtSound.Play();
        if (this.hp <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetTrigger("GoAttack");
        attackSound.Play();
        StartCoroutine("WaitForAttack");
    }

    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(1.2f);
        int attackDamage = this.dmg;
        int rand1 = Random.Range(0, 100);
        if (rand1 <= this.criticalChance) attackDamage = attackDamage * ((100 + this.criticalDmg) / 100);
        int rand2 = Random.Range(0, 100);
        if (rand2 <= this.healChance) this.hp += this.heal;
        GameObject bulletSpawn = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
        bulletSpawn.GetComponent<Bullet>().Damage = attackDamage;
    }
}
