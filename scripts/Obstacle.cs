using UnityEngine;

public class ObstaculerController : MonoBehaviour
{

    private float minSize = 0.3f;

     private float maxSize = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        transform.localScale = new Vector3(Random.Range(minSize, maxSize), 3, 1);
         Rigidbody2D rb = GetComponent<Rigidbody2D>();
         Transform tf = GetComponent<Transform>();
         Debug.Log(transform == tf);
         rb.AddForce(Vector2.up * 34);


        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
