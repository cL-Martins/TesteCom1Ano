using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento do personagem
    public float forcaPulo = 10f; // For�a do pulo do personagem
    public LayerMask camadaChao; // Camada que representa o ch�o

    private Rigidbody2D rb; // Refer�ncia ao componente Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obt�m a refer�ncia ao componente Rigidbody2D
    }

    void Update()
    {
        // Movimenta��o horizontal do personagem
        float movimentoHorizontal = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(new Vector2(movimentoHorizontal, 0));

        // Pulo do personagem se a tecla de pulo (por exemplo, a barra de espa�o) for pressionada
        if (Input.GetButtonDown("Jump") && EstaNoChao())
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
        }
    }

    bool EstaNoChao()
    {
        // Verifica se o personagem est� no ch�o
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, camadaChao);
        return hit.collider != null;
    }
}
