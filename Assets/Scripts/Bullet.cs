using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour { // Class for bullets

    private Transform target;

    public float speed = 70f; 

    public int damage = 50;
    public float explosionRadius = 0; // The  radius for bullet when exploding.
    public GameObject impactEffect;

    private void Start()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); // Generate impact effect on impact location
        Destroy(effectIns, 5f); // Destroy the effects when finished
    }

    public void Seek (Transform _target)
    {
        target = _target; //set target
    }

    // Update is called once per frame
    void Update () {
        if (target == null)
        {
            Destroy(gameObject); // if target has destroyed, destory the bullet
            return;
        }

        Vector3 dir = target.position - transform.position + new Vector3(0,1,0) ; //Set direction
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)// preventing over-shoot  防止over-shoot
        {
            
            HitTarget(); // Impact + damage
            return;
        }
       
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //move

        transform.LookAt(target); //Always targets the target

    }

    void HitTarget()
    {

        if (explosionRadius > 0f)
        {
            Explode(); 
        }else
        {
            Damage(target);
        }

        
        Destroy(gameObject);

    }

    void  Explode()
    {
        Collider[] colliders =   Physics.OverlapSphere(transform.position, explosionRadius); //破碎 Find the impacted target
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage( Transform enemy)
    {

        Enemy e =  enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage); // Decrese enemy life value
        }

    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
