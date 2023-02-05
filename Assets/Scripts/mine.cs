using UnityEditor;
using UnityEngine;

public class mine : MonoBehaviour
{
    public GameObject Player;
    private bool hasTakenDamage = false;
    private Collider[] collider; 
    private void Awake()
    {
        collider = new Collider[1]; 
    }


    private void FixedUpdate()
    {
        var collisions = Physics.OverlapBoxNonAlloc(this.transform.position, new Vector3(5, 5, .9f), collider);
        if (collider[0] != null)
        {
            if (!hasTakenDamage)
            {
                Player.GetComponent<HealthSystem>().TakeDamage();
                this.GetComponent<Animation>().Play();
                Destroy(gameObject.GetComponent<MeshRenderer>());
                Destroy(GetComponent<BoxCollider>());
                hasTakenDamage = true;
                Destroy(gameObject, 1);
            }

        }
    }
}


