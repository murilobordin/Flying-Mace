using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    private enum STATUS { VIVO, MORTO}
    private STATUS statusDoPersonagem;

    private void Start()
    {
        statusDoPersonagem = STATUS.VIVO;
    }

    public void Morte()
    {
        statusDoPersonagem = STATUS.MORTO;
    }

    public bool EstaVivo()
    {
        return statusDoPersonagem == STATUS.VIVO;
    }
    
}
