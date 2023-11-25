using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{

    int health;
    int maxHealth = 100;
    bool CanHeal = true;
    

    public void ReceiveHealing()
    {

        if (CanHeal == true && health < 100)
        {

            StartCoroutine(Healing());


        }
        
        IEnumerator Healing()
        {

            CanHeal = false;

            health += 5;
            Debug.Log($"+5 hp for Unit");
            yield return new WaitForSeconds(0.5f);
            health += 5;
            Debug.Log($"+5 hp for Unit");
            yield return new WaitForSeconds(0.5f);
            health += 5;
            Debug.Log($"+5 hp for Unit");
            yield return new WaitForSeconds(0.5f);
            health += 5;
            Debug.Log("+5 hp for Unit");
            yield return new WaitForSeconds(0.5f);
            health += 5;
            Debug.Log($"+5 hp for Unit");
            yield return new WaitForSeconds(0.5f);
            health += 5;

            if (health >= 100)
            {
                health = maxHealth;
            }

            Debug.LogWarning($"+5 hp for Unit, Unit HP = " + health);

            CanHeal = true;


        }
    }
}