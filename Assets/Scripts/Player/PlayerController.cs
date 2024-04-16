using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    int side = 1;
    public Transform corn;

     private Vector2 lastDirection = Vector2.right; // Inicialmente, o jogador está virado para a direita
    private float verticalInput;
    private void Awake() {

        playerControls = new PlayerControls(); // input actions
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>(); // animação do personagem
        mySpriteRender = GetComponent<SpriteRenderer>(); // renderiza o sprite do personagem
    }

    public Vector2 GetLastDirection()
    {
        return lastDirection + Vector2.up * verticalInput;
    }

    private void OnEnable() {
        // "This function is called when the object becomes enabled and active."
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput() {
        
        if (Input.GetKeyDown(KeyCode.B)) {
            Instantiate(corn, transform.position, Quaternion.identity);
        }
        lastDirection = mySpriteRender.flipX ? Vector2.left : Vector2.right;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Atualize o vetor de movimento com base nos controles de entrada
        movement = new Vector2(horizontalInput, verticalInput).normalized;

        // animação do personagem vertical e horizontal
        myAnimator.SetFloat("moveX", movement.x);

        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() {
        // atualiza a posição do usuário
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection() {
        // pega a posição do mouse
        Vector3 mousePos = Input.mousePosition;

        // transforma a posição do espaço do mundo para o espaço da tela
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // se a posição do mouse for menor que a posição do player, 
        // ele vira para a esquerda
         // Se o movimento for para a direita e o sprite estiver virado para a esquerda, ou se o movimento for para a esquerda e o sprite estiver virado para a direita, inverta o sprite
    if ((horizontalInput > 0 && mySpriteRender.flipX) || (horizontalInput < 0 && !mySpriteRender.flipX)) {
        mySpriteRender.flipX = !mySpriteRender.flipX;
    }
    }

}
