using JetBrains.Annotations;
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
    private GameObject _MissilePrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextFire = 0f;
    [SerializeField]
    private int _lives = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Take the current position = new position (0,0,0)
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        CalcMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireMissile();
        }
    }
    void CalcMovement()
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

        // Create player bounds:
        if (transform.position.y >= 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, 0);
        }
        else if (transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.z != 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        // The above bound can be simplified using clamp:
        // transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 2.5f), 0);

        if (transform.position.x >= 10.3f)
        {
            transform.position = new Vector3(-10.25f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10.25f)
        {
            transform.position = new Vector3(10.3f, transform.position.y, 0);
        }

        //Make the spaceship tilting when moving

        if (horizontalInput > 0)
        {
            //transform.rotation = Quaternion.Euler(0, -20, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -20, 0), Time.deltaTime * 5f);
        }
        else if (horizontalInput < 0)
        {
            //transform.rotation = Quaternion.Euler(0, 20, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 20, 0), Time.deltaTime * 5f);
        }
        else
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f);
        }
    }
    void FireMissile()
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_MissilePrefab, new Vector3(transform.position.x, transform.position.y + 1, 0), _MissilePrefab.transform.rotation);
        }
    public void Damage()
    {
        _lives -= 1;
        // check if dead
        if (_lives < 1)
        {
            Destroy(gameObject);
        }

    }
}
