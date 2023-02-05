using UnityEditor;
using UnityEngine;

public class mine : MonoBehaviour
{
    public GameObject Player;
    private bool hasTakenDamage = false;
    private Collider[] collider ; 
    private void Awake()
    {
        collider = new Collider[1]; 
    }


    private void FixedUpdate()
    {
        var collisions=Physics.OverlapBoxNonAlloc(this.transform.position, new Vector3(5, 5, .9f), collider);
        if (collider[0] !=null)
        {
            if (!hasTakenDamage)
            {                
                Player.GetComponent<HealthSystem>().TakeDamage();
                gameObject.GetComponent<Animator>().SetBool("BombHit", true);
                hasTakenDamage = true;
                Destroy(GetComponent<BoxCollider>());
                Destroy(gameObject, 1);
            }

        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(this.transform.position, new Vector3(15, 15, 3));
    }
}


