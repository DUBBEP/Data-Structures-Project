using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float sidewaysforce = 100f;
    public float veticalforce = 10f;

    GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") && !manager.instantReplay)
        {
            //Take inputs and send them to command log
            Command moveRight = new MoveRight(rb, sidewaysforce);
            setInvoker(moveRight);
            //Debug.Log("Input : Right");
        }

        if (Input.GetKey("a") && !manager.instantReplay)
        {
            //Take inputs and send them to command log
            Command moveLeft = new MoveLeft(rb, sidewaysforce);
            setInvoker(moveLeft);
            //Debug.Log("Input : Left");
        }

        if (Input.GetKey("w") && !manager.instantReplay)
        {
            Command moveUp = new MoveUp(rb, veticalforce);
            setInvoker(moveUp);
        }
        
        if (rb.position.y < -2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
    private void setInvoker(Command move)
    {
        Invoker invoker = new Invoker();
        invoker.Setcommand(move);
        invoker.ExcuteCommand();
    }
}
