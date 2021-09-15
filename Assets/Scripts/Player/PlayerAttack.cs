using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayer;
    public Transform attackPoint;
    public float attackRange;
    
    public AudioSource punchSound;
    public AudioSource whiffSound;
    
    GameObject punch;
    
    void Start() {
        punch = transform.GetChild(1).gameObject;
    }

    void Update()  {
        if(Input.GetKeyDown(KeyCode.F)){
            Attack();
        }
    }
    
    public void Attack() {
        whiffSound.Play();
        
        punch.SetActive(true);
        Invoke("PunchFinished", .4f);
        
        Collider2D[] enemyCol = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        foreach(Collider2D enemy in enemyCol){
            enemy.GetComponent<Enemy>().Die();
            punchSound.Play();
        }
    }
    
    void OnDrawGizmosSelected(){
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
    void PunchFinished(){
        punch.SetActive(false);
    }
}
