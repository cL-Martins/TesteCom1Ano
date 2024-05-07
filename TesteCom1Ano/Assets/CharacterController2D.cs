using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento do personagem
    public float forcaPulo = 10f; // Força do pulo do personagem
    public LayerMask camadaChao; // Camada que representa o chão

    private Rigidbody2D rb; // Referência ao componente Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém a referência ao componente Rigidbody2D
    }

    void Update()
    {
        // Movimentação horizontal do personagem
        float movimentoHorizontal = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(new Vector2(movimentoHorizontal, 0));

        // Pulo do personagem se a tecla de pulo (por exemplo, a barra de espaço) for pressionada
        if (Input.GetButtonDown("Jump") && EstaNoChao())
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
        }
    }

    bool EstaNoChao()
    {
        // Verifica se o personagem está no chão
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, camadaChao);
        return hit.collider != null;
    }
}
