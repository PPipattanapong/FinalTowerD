using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackDamage = 10f;
    public float cooldownTime = 1f; // Cooldown time in seconds
    private bool canAttack = true; // Flag to check if tower can attack
    [SerializeField] private GameObject vfx; // Reference to the VFX prefab
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        // Check if tower can attack (not in cooldown)
        if (canAttack)
        {
            // Check for enemies within range
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

            // If there are enemies in range, attack them and play VFX
             // ในคลาส Tower
            foreach (Collider col in hitColliders)
            {
                VFX();
                HPEnemy enemy = col.GetComponent<HPEnemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
                    enemy.SetAttacked(); // Set the attacked flag of the enemy
                }
            }


            // Start cooldown
            StartCoroutine(Cooldown());
        }
    }

    // Cooldown coroutine
    IEnumerator Cooldown()
    {
        // Set flag to prevent further attacks during cooldown
        canAttack = false;

        // Wait for cooldown time
        yield return new WaitForSeconds(cooldownTime);

        // Reset flag to allow attacking again
        canAttack = true;
    }

    // Debug visualization of attack range in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Function to play VFX
    private void VFX()
    {
        if (vfx != null)
        {
            Instantiate(vfx, transform.position, transform.rotation);
        }
    }
}
