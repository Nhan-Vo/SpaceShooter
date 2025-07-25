using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.y >= 14)
        {
            Destroy(gameObject);
        }
    }
}
