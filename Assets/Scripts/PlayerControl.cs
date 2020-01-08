using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Status controlaStatus;

    private bool pulando, estaVivo;

    [Header("Ground Check")]
    [SerializeField]
    private LayerMask camadaDoChao;
    [SerializeField]
    private Transform sensorDeContato;
    [SerializeField]
    private bool estaNoChao;
    [SerializeField]
    private float raioDoSensor = 0f;

    [Header("Atributos de Movimentação")]
    [SerializeField]
    private float velocidadeDeMovimentacao = 0f;
    [SerializeField]
    private float forcaDoPulo = 0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controlaStatus = GetComponent<Status>();
    }

    void Update()
    {
        estaVivo = controlaStatus.EstaVivo();
        estaNoChao = Physics2D.OverlapCircle(sensorDeContato.position, raioDoSensor, camadaDoChao);

        if (pulando && estaVivo && estaNoChao)
            rb2d.AddForce(new Vector2(0, forcaDoPulo));
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if(estaVivo)
            rb2d.velocity = new Vector2(move * velocidadeDeMovimentacao, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump"))
            pulando = true;
        else
            pulando = false;
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "MorteSubita")
            controlaStatus.Morte();
    }
}
