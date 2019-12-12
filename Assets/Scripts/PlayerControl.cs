using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private bool pulando;

    [Header("Atributos de Movimentação")]
    [SerializeField]
    private float velocidadeDeMovimentacao;
    [SerializeField]
    private float forcaDoPulo;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (pulando)
            rb2d.AddForce(new Vector2(0, forcaDoPulo));
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(move * velocidadeDeMovimentacao, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump"))
            pulando = true;
        else
            pulando = false;
    }
}
