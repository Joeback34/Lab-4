using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public static float animatorHealth = 4;
    public float maxHealth = 100f;
    public float currentHealth;
    public Animator animator;
    public GameOverManager gameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        if(transform.name == "Player")
        {
            animatorHealth = 4;
            animator.SetFloat("Health", animatorHealth);
        }

    }

   
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (transform.name == "Player" && damage > 0)
        {
            animatorHealth--;
            animator.SetFloat("Health", animatorHealth);
        }
        else if(transform.name == "Player")
        {
            if (animatorHealth < 4)
            {
                animatorHealth++;
            }

            animator.SetFloat("Health", animatorHealth);
        }
        
        if(currentHealth <= 0f)
        {
            Die(); 
        }
        if(currentHealth <=0f && transform.name == "Player")
        {
            gameManager.gameOver();
            Die();
        }
    }   

    

    private void Die()
    {
        if(transform.name != "Player")
        {
            ScoreManager.score++;
        }
            Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
