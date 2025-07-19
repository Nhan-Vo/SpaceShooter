using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference
    // data type (int, float, bool, string)
    // every variable has a name
    // optional value assigned

    public float speed = 3.5f; // The "f" suffix means float and is required for floating point number variable 

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
        transform.Translate(Vector3.right * speed * Time.deltaTime); // this also mean: transform.Translate(new Vector3(1,0,0) * 5 * Time.deltaTime)
    }
}
