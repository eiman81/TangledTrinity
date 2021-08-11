using UnityEngine;

public class Player : Character
{
    Animator anim;

    [SerializeField]
    private float Speed;

    private bool isRunning = false;

    public PlayerStats stats;

    // Reference the array of abilities
    public Ability[] ability;

    // Array of sound effects to be played for when the abilities are used
    public AudioClip[] sounds;
    public AudioSource source;

     void Awake ()
    {
        // Reference the health, animator, etc
        anim = GetComponent<Animator>();
        currentHealth = stats.health;
        ability = stats.abilities;
        Speed = stats.speed;
    }

    void Update ()
    {
        // Initialise all of the abilities, so that they are ready and have a reference to the player
        ability[0].Use ();
        ability[1].Use ();
        ability[2].Use ();
    }

    // I use fixed update for movement instead of update as it updates more frequently than "void Update()", allowing for more responsive player movement
    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove ()
    {
        //if (!isAttacking)
        if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack1"))
        {
            // "v" is equal to the vertical input axis which is the W, S, Up & down arrow keys. The player can walk forward and backward by pressing these keys
            float v;

            v = Input.GetAxis ("Vertical");

            // Set the animation to run when the player is moving
            anim.SetFloat ("speed", v);
            anim.SetBool ("isRunning", isRunning);


            if (Input.GetKeyDown (KeyCode.LeftShift))
            {
                isRunning = true;
                Speed += 2f;
            }
            if (Input.GetKeyUp (KeyCode.LeftShift))
            {
                isRunning = false;
                Speed -= 2f;
            }

            // Create a vector3 to store the new position of the player
            Vector3 movement = Quaternion.Euler (0, Camera.main.transform.eulerAngles.y, 0) * new Vector3 (0, 0, v * Speed * Time.deltaTime);

            // Add this vector3 to the player's position, to allow for him to move
            transform.position += movement;
        }
    }
}
