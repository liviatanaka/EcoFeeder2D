using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private Knockback knockback;
    private SpriteRenderer mySpriteRender;

    // private AudioManager audioManager;

    private void Awake() {
        base.Awake();
        // set initial position
        transform.position = new Vector3(0, 0, 0);
        playerControls = new PlayerControls(); // input actions
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>(); // animação do personagem
        mySpriteRender = GetComponent<SpriteRenderer>(); // renderiza o sprite do personagem
        knockback = GetComponent<Knockback>();
        // audioManager = GameObject.Find("Audio").GetComponent<AudioManager>();
    }

    
    private void Start(){
        // start the script with the player in the center of the screen

        transform.position = new Vector3(0, 0, 0);

        playerControls.Enable();

    }

    private void OnEnable() {
        // "This function is called when the object becomes enabled and active."
        transform.position = new Vector3(0, 0, 0);

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
        // realiza a leitura do input do usuário
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        // animação do personagem vertical e horizontal
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() {
        if (knockback.GettingKnockedBack) { return; }

        // atualiza a posição do usuário
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection() {
        // pega a posição do mouse
        Vector3 mousePos = Input.mousePosition;

        // transforma a posição do espaço do mundo para o espaço da tela
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        // se a posição do mouse for menor que a posição do player, 
        // ele vira para a esquerda
        if (mousePos.x < playerScreenPoint.x) {
            mySpriteRender.flipX = true;
        } else {
            mySpriteRender.flipX = false;
        }
    }
}
