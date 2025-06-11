//The game I made is called Chill Hood Guy. The character, Chill Hood Guy, has to jump to avoid the bullet obstacles. The background is set in a sunset building area.  

//I although I could not finish the game, I had a script meant make the character jump:  

using System.Collections; 

using System.Collections.Generic; 

using UnityEngine; 

  

public class CharacterScript : MonoBehaviour 

{ 

    public Rigidbody2D myRigidbody; 

    public float flapStrength; 

    public LogicScript logic; 

    public bool CharacterIsAlive = true; 

  

    void Start() 

    { 

  

        // Assign the Rigidbody2D 

        myRigidbody = GetComponent<Rigidbody2D>(); 

        if (myRigidbody == null) 

        { 

            Debug.LogError("Rigidbody2D component not found! Attach it in the Unity Inspector."); 

        } 

    } 

  

    void Update() 

    { 

        if (Input.GetKeyDown(KeyCode.Space) && CharacterIsAlive) 

        { 

            myRigidbody.velocity = Vector2.up * flapStrength; 

        } 

//If I had more time, I would have also made code for randomizing the bullet locations and spawning, adding character points for dodging bullets, and killing the character for hitting one of the bullets. This is what the code may have looked like. 

public class BulletMoveScript : MonoBehaviour 
{ 
    public float moveSpeed = 5f; 
    public float deadZone = -45f; 
 
    void Update() 
    {        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime; 
 
        if (transform.position.x < deadZone) 
        { 
            Destroy(gameObject); 
        } 
    } 
} 
 
public class BulletSpawnScript : MonoBehaviour 
{ 
    public GameObject Bullet; 
    public float spawnRate = 2f; 
    private float timer = 0f; 
    public float heightOffset = 10f; 
 
    void Start() 
    { 
        InvokeRepeating("spawnBullet", 0f, spawnRate); 
    } 
 
    void spawnBullet() 
    { 
        float lowestPoint = transform.position.y - heightOffset; 
        float highestPoint = transform.position.y + heightOffset; 
 
        Instantiate(Bullet, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation); 
    } 
} 
 
public class BulletMiddleScript : MonoBehaviour 
{ 
    public LogicScript logic; 
 
    void Start() 
    { 
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
    } 
 
    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision.gameObject.CompareTag("Player"))  
        { 
            logic.addScore(1); 
        } 
    } 
} 

 

//The goal of the game is for the Chill Hood Guy to dodge bullets(forever.)
