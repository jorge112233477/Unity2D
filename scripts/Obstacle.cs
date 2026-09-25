using System.Drawing;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class ObstaculerController : MonoBehaviour
{
[SerializeField]
    private float minSize = 0.3f;

    [SerializeField]
     private float maxSize = 2f;

     [SerializeField]
     private float minForce = 10f;

     [SerializeField]
     private float maxForce = 20f;

     [SerializeField]
     private float minTorque = 10f;
     [SerializeField]
        private float maxTorque = 20f;
    
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float size = 
        Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size,size , 1);
         Rigidbody2D rb = GetComponent<Rigidbody2D>();
         Transform tf = GetComponent<Transform>();
         Debug.Log(transform == tf);
         Vector2 randomDirection = Random.insideUnitCircle;
         rb.AddForce(randomDirection * 34);
         float Torque = Random.Range(minTorque, maxTorque);
         rb.AddTorque(Torque);


                float force = Random.Range(minForce, maxForce);
                rb.AddForce(randomDirection * force);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
