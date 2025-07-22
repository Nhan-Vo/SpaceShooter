using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference (If it's public, the outside world can communicate with the variable, other scripts or game object can know that this variable exist.
    // If it is private, only the player know this variable exists)
    // data type (int, float, bool, string)
    // optional value assigned

    public float speed = 10f; // The "f" suffix means float and is required for floating point number variable 
    private string _private_variable = "The _ symbol is usually used for private variable";

    [SerializeField] // Make the private variable appear in the editor while maintaining that other objects cannot interact with this variable
    private float _privateSpeed = 5f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Take the current position = new position (0,0,0)
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // move Player to the right for 1 meter per second (If you want to move 5 meter per second, just times 5 to it)
        // Time.deltatime is real time
        // 1st method:
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime); // this also mean: transform.Translate(new Vector3(1,0,0) * horizontalInput * 5 * Time.deltaTime)
        //transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        // 2nd method:
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y >= 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, 0);
        }
        else if (transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

    }
}
