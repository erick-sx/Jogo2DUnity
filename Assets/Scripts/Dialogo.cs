using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Dialogo 
{
    [SerializeField]
    private TextoDialogo[] _frases;

    [SerializeField]
    private string _nomeNPC;

    public TextoDialogo[] GetFrases(){
        return _frases;
    }

    public string GetNomeNPC(){
        return _nomeNPC;
    }
}
