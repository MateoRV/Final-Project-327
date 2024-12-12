using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Push : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            //Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            Vector3 forceDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            //rigidbody.velocity = forceDirection * forceMagnitude;
            Vector3 collisionPoint = hit.point;
            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, collisionPoint, ForceMode.Impulse);

            /*forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);*/
        }
    }
}
