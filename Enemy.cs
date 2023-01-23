using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth = 5;

    public EnemyController theEc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(theEc != null)
        {
            theEc.GetShot();
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            AudioManager.instance.PlaySFX(8);
        }
    }

}
