﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResponderPregunta : MonoBehaviour {

	public Text canva_puntos;
    public int puntosPorRespuesta;
	//public GameObject activadorPregunta;
	public GameObject Pregunta;
	public AudioClip Correcto;
    public AudioClip inCorrecto;
	private AudioSource sonido;
	private Color verdeColor = Color.green;
	private Color rojoColor= Color.red;
    public Botones botones;

    public logicaVidaSubjefes Subjefe;  // CAMBIAR
    public GameObject SubjefeObj;
    public logicaVidaPrephely VidaPrifely;
    public GameObject VidaPrifelyObj;
    public ActivadorPregunta activarPregunta;
    // public logicateoria teoria;
    public GameObject objetoCanvas;
    public int VidaEnemigo;

    private float seg;
   
    public static int contador;
    public static int puntos;

	void Start (){
      //  teoria = FindObjectOfType<logicateoria>();
        objetoCanvas = GameObject.Find("CanvasPreguntas");

        activarPregunta = FindObjectOfType<ActivadorPregunta>();

        SubjefeObj =GameObject.Find("Subjefe Pigman");
        Subjefe = SubjefeObj.GetComponent<logicaVidaSubjefes>();  // CAMBIAR

        VidaPrifelyObj = GameObject.Find("Prephely");
        VidaPrifely = VidaPrifelyObj.GetComponent<logicaVidaPrephely>();

        VidaEnemigo = Subjefe.vidaSubjefe;
        botones = GetComponentInParent<Botones>();

        canva_puntos.text = "puntos: " + puntos;

        sonido = GetComponent<AudioSource>();

        if (puntosPorRespuesta == 1)
        {
           sonido.clip = Correcto;
        }
        else
		{
            sonido.clip = inCorrecto;
        }


    }
    public void Update()
    {
          if(Subjefe.vidaSubjefe <= 0 | VidaPrifely.vidaPrephely <= 0 )
        {
            seg += Time.deltaTime;
            if (seg > 2)
            {
                Destroy(objetoCanvas.transform.GetChild(1).gameObject);
            }
        }

        if (contador == activarPregunta.NumTeoria)
        {
            seg += Time.deltaTime;
            if (seg > 1)
            {
                Destroy(objetoCanvas.transform.GetChild(2).gameObject);
            }
        }
        

    }

	public void Preguntas(){
		contador += 1;
        puntos +=puntosPorRespuesta;
		StartCoroutine (res_correcta ());
	}

	IEnumerator res_correcta(){


        if (puntosPorRespuesta == 1)
        {
            gameObject.GetComponent<Image>().color = verdeColor;
            Subjefe.vidaSubjefe = Subjefe.vidaSubjefe - 250;

        }
        if (puntosPorRespuesta == -1)
        {
            gameObject.GetComponent<Image>().color = rojoColor;
            VidaPrifely.vidaPrephely = VidaPrifely.vidaPrephely - 50;
        }

        sonido.Play();
		canva_puntos.text = "puntos: " + puntos;
   
        botones.verifyIsPressed(false);
        yield return new WaitForSeconds (2f);
		canva_puntos.text = "puntos: " + puntos;
       
        Destroy (Pregunta);

        //Destroy(SubjefeObj);
       

      //  Enemigo.GetComponent<CapsuleCollider> ().enabled = false;
	}

    

}
