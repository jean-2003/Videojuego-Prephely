using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVidaSubjefe : MonoBehaviour
{
    public Animator animador;
    public int vidaSubjefe = 1000;
    public Image barraVida;
    private AudioSource sonidos;
    public AudioClip sonidoMuerte;
    private void Start()
    {
        sonidos = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(vidaSubjefe <= 0)
        {
            animador.Play("Morir");
            //sonidos.PlayOneShot(sonidoMuerte);
            Invoke("pararJuego", 3f);
        }
    }
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.CompareTag("Espada"))
        {
            vidaSubjefe -= 10;
            barraVida.fillAmount -= 0.01f;
            animador.Play("ReaccionarAtaque");
        }
    }
    void pararJuego()
    {
        Time.timeScale = 0;
        sonidos.Stop();
    }
}
