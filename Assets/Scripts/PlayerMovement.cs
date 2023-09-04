using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    Vector2 speed;
    public float hiz;
    public float hizlanma;
    public float yavaslama;
    public float jumpForce;
    public float jumpLimit = 2;
    public float jumpCount;
    Joystick joystick;
    JoystickButton joystickButton;
    bool jumping;
    //bool isGround = false;
    //public float jumpForce;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindAnyObjectByType<Joystick>(); //sahneden joystick tipindeki objeyi bul ve degiskene ata
        joystickButton = FindAnyObjectByType<JoystickButton>();
    }


    void Update()
    {
#if UNITY_EDITOR //eger Unity editorde isek klavye kontrol fonk calisir
        KeyboardControl();
#else //eger unity disinde bir yerde isem alttaki fonk calisir
             JoyistickControl();
#endif //kapamak zorundasin boyle
        //MovementEray();
    }
    //private void OnCollisionEnter2D(Collision2D collision)                      // kendim denedim 
    //    //bu codun olmasisin nedeni havadayken space basip ucmamasi icin 
    //    // eger platform ile temasi varsa startJump i baslatabilir ama yoksa kullanamaz 
    //{
    //    if (collision.gameObject.tag == "Platform")
    //    {
    //        isGround = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)                      //kendim denedim 
    //{
    //    if (collision.gameObject.tag == "Platform")
    //    {
    //        isGround = false;
    //    }
    //}
    void MovementEray()
    {
        Vector2 scale = transform.localScale;
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 vec = new Vector2(horizontal, 0);
        if (Input.GetKeyDown(KeyCode.Space))/* && isGround*/
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up, ForceMode2D.Impulse); // * jumpforce
            //rb2d.velocity = Vector3.up * jumpForce;
            //vec.y = Mathf.MoveTowards(vec.y,hiz, hizlanma * Time.deltaTime);
        }
        if (horizontal > 0)
        {
            animator.SetBool("Walk", true);
            vec.x = Mathf.MoveTowards(vec.x, horizontal * hiz, hizlanma * Time.deltaTime);
            scale.x = 0.3f;
        }
        else if (horizontal < 0) // sola gidis
        {

            animator.SetBool("Walk", true);
            vec.x = Mathf.MoveTowards(vec.x, horizontal * hiz, hizlanma * Time.deltaTime);
            scale.x = -0.3f;
        }
        else //klavyeden elimi cektigimde durmasi icin
        {
            animator.SetBool("Walk", false);
        }
        //transform.position = Vector2.MoveTowards(transform.position, vec, hiz * Time.deltaTime);
        //transform.Translate(vec * hiz * Time.deltaTime
        //rb2d.AddForce(vec * hiz);
        rb2d.velocity = new Vector2(vec.x * hiz, rb2d.velocity.y); // y de bir kuvvet varsa ellesme takilsin anlamina geliyor
        transform.localScale = scale;

    }                                                     // kendim denedim 
    void KeyboardControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 scale = transform.localScale; //sola donerken scale i - yaparsam karakterin yuzu sola doner o yuzden bu sekilde kullandik
        if (horizontal > 0) // saga gidis 
        {
            speed.x = Mathf.MoveTowards(speed.x, horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;

        }
        else if (horizontal < 0) // sola gidis
        {
            speed.x = Mathf.MoveTowards(speed.x, horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;


        }
        else //klavyeden elimi cektigimde durmasi icin
        {
            speed.x = Mathf.MoveTowards(speed.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(speed * Time.deltaTime);
        if (Input.GetKeyDown("space"))
        {
            startJump();
        }
        if (Input.GetKeyUp("space"))
        {
            stopJump();
        }
    }
    void JoyistickControl()
    {
        float horizontal = joystick.Horizontal;
        Vector2 scale = transform.localScale; //sola donerken scale i - yaparsam karakterin yuzu sola doner o yuzden bu sekilde kullandik
        if (horizontal > 0) // saga gidis 
        {
            speed.x = Mathf.MoveTowards(speed.x, horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;

        }
        else if (horizontal < 0) // sola gidis
        {
            speed.x = Mathf.MoveTowards(speed.x, horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;


        }
        else //klavyeden elimi cektigimde durmasi icin
        {
            speed.x = Mathf.MoveTowards(speed.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(speed * Time.deltaTime);
        if (joystickButton.pressKey == true && jumping == false)
        {
            jumping = true;
            startJump();
        }
        if (joystickButton.pressKey == false && jumping == true)
        {
            jumping = false;
            stopJump();
        }
    }
    void startJump()
    {
        if (jumpCount < jumpLimit) //playerin havada maks 2 kere ziplmasini saglar
        {
            FindObjectOfType<SoundControl>().ZiplamaSes();
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
        }

    }
    void stopJump()
    {
        animator.SetBool("Jump", false);
        jumpCount++;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);

    }
    public void ResetJump() //platforma temas edince limiti 0 lar
    {
        jumpCount = 0;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            FindAnyObjectByType<GameControl>().GameOver();
        }
    }
    public void GameOver()
    {
        Destroy(gameObject);
    }
}
