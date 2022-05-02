using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour{

    public int coins;

    private Vector2 targetPos;
    public float speed = 5;
    
    private bool UIActive = false;

    public GameObject UI;
    public Rigidbody2D rb;
    public GameObject player;
    public Animator anim;

    //wumpus spawn
    //im gonna move this to a separate script later if needed
    public Wumpus w;
    public Room r;
    public GameObject wumpus;
    public Instantiate i;
    
    
    void Start(){
        UI.SetActive(!gameObject.activeSelf);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = player.gameObject.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("Assets/Player/Animation/Player.controller") as RuntimeAnimatorController;
        //wumpus spawn
        //i.wumpinit();
        wumpus = GameObject.Find("WumpusPFB");
        Debug.Log(wumpus);
//        wumpus.SetActive(false);
    }
    
    void Update(){
            //debug
        // Debug.Log(UIActive);



        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Movement
        if (Input.GetMouseButton(0) && UIActive == false){
            targetPos = new Vector2(mousePos.x, mousePos.y);
        }

        Vector2 animPos = new Vector2(transform.position.x - targetPos.x, transform.position.y - targetPos.y);

        anim.SetFloat("x", animPos.x);
        anim.SetFloat("y", animPos.y);

        //UI
        if (Input.GetButtonDown("Fire1")){
            //GameObject UI = transform.GetChild(0).gameObject;
            
            if(UIActive == false){
                UI.SetActive(gameObject.activeSelf);
                targetPos = new Vector2(transform.position.x, transform.position.y);
                UIActive = true;
            }else{
                UI.SetActive(!gameObject.activeSelf);
                UIActive = false;

            }
        }
        if(Input.GetKeyDown(KeyCode.P)){
            //wumpus.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.L)){
           // wumpus.GetComponent("WumpUI").enabled = true;
        }
    }

    // Doing movement in this method makes the code smoother, as per the docs.
    void FixedUpdate()
    {
        if (!(targetPos.x == 0 && targetPos.y == 0) && UIActive == false)
        {
            // New GigaChad rigidbody code
            // Using the same vector, just changing to Rigidbody
            rb.MovePosition(Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed));
            // Old transform.position code
            // We need to use Rigidbody to get smooth movement with colliders
            //transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }
    }
}
