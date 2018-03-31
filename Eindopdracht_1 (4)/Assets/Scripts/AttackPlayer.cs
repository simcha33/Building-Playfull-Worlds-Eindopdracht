using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    public int PlayerHealth = 100;
    int damage = 20;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    

    void Start()
    {
        print(PlayerHealth); 
    }

    void OnCollisionEnter(Collision Attack)
    {
        if (Attack.gameObject.tag == "Monster1")
        {
            PlayerHealth = PlayerHealth - damage;
            print("attacked" + PlayerHealth);
            if (PlayerHealth <= 0)
            {
                player.transform.position = respawnPoint.position; 
                print("Died"); 
            }
        }
    }

    public void Die()
    {
        
    }

}
    
        
    



