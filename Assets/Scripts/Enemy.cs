using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0) * _speed * Time.deltaTime);
        if (transform.position.y <= -5f)
        {
            // Respawn the enemy at a random position on the x-axis
            transform.position = new Vector3(Random.Range(-9f, 9f), 13f, 0);
 

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            //Destroy(gameObject);
            transform.position = new Vector3(Random.Range(-9f, 9f), 13f, 0);
            Debug.Log("Hit: " + other.transform.name);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            // The only component in Unity that you  have access to is the Transform of an object
            // If you want another component, you have to use other.transform.GetComponent<YourComponentName>()
            // Best practice is to Null check the component before using it
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            //Destroy(gameObject);
            transform.position = new Vector3(Random.Range(-9f, 9f), 13f, 0);
            Debug.Log("Hit: " + other.transform.name);

        }
    }

}
