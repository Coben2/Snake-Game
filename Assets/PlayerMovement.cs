using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private GameObject apple;
    [SerializeField] private GameObject snake;

    private Vector3 previousPosition;
    private Vector3 dir;

    public float offSet = 0.5f;
    private GameObject previousSnakePart;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;

        transform.Translate(move, Space.Self);

        dir = transform.position - previousPosition;
        Debug.Log(dir);
        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "snake")
        {
            
            Destroy(other.gameObject);
            Vector3 range = new Vector3(Random.Range(1, 10), -5.52f, Random.Range(-4, 4));
            Instantiate(apple, range, Quaternion.identity);
            var snakePart = Instantiate(snake);
            previousSnakePart = snakePart;
            //snakePart.transform.position = previousSnakePart.transform.position;
            Vector3 snakePosition = previousSnakePart.transform.position + new Vector3(-dir.x + offSet, -5.52f, -dir.z + offSet);
        
        }


    }






}
