using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    
    //Movimentos basicos
    public float moveForce = 10f;
    public float maxSpeed = 15f;
    public float jumpForce = 50f;

    //Movimentos com o estilo verde
    public bool verde = false;
    public bool canPush = false;

    //Movimento com o estilo vermelo

    //Movimento com o estilo amarelo
    


    //Saber se esta no chão e q pode pular
    public BoxCollider2D groundCheck;

    //Saber se pode empurrar
    public BoxCollider2D pushCheck;

    //Aplicar as forças
    public Rigidbody2D body;    
   
    void Awake()
    {        
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        FlipSprite();
    }

    private void Move()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is betweeen -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * moveForce, body.velocity.y);
        body.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(body.velocity.x) > Mathf.Epsilon;

        //TODO - Avaliar o lado em q ele esta olhando

    }

    private void Jump()
    {
        //Verificar em qual layer ele esta encostando
        if (!groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpForce);
            body.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(body.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(body.velocity.x), 1f);
        }
    }

    private void Push()
    {
        if(pushCheck && canPush)
        {
            //Encontrar o boxcollider da caixa e permitir mover
        }
    }


}

