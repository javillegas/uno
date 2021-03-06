﻿using UnityEngine;
using System.Collections;

public class Player : Jugador {


    public Carta cartaSeleccionada;

    public override void Juega()
    {
        if (!yaChequeo)
        {
           ComienzoDeTurno();
        }
        else
        {
            if (!tieneCartaQueSirve)
            {
                if (!yaRobo)
                    Roba();
                else
                    FinDeTurno();
                    
            }
            else
            {
                if (cartaSeleccionada != null)
                {
					if (cartaSeleccionada != null && GameManager.manager.cartaEnLaSimaDeLaMesa.esRojo == cartaSeleccionada.esRojo)
                    {
                        Debug.Log(cartaSeleccionada);
                        GameManager.manager.AgregarCartaAlLaMesa(cartaSeleccionada);
                        cantidadCartasActual--;
                        GameManager.manager.FinTurno(true);

                        cartaSeleccionada = null;

                        base.FinDeTurno();
                    }
					if (cartaSeleccionada != null && GameManager.manager.cartaEnLaSimaDeLaMesa.valor == cartaSeleccionada.valor)
                    {
                        Debug.Log(cartaSeleccionada);
                        GameManager.manager.AgregarCartaAlLaMesa(cartaSeleccionada);
                        cantidadCartasActual--;
                        GameManager.manager.FinTurno(true);

                        cartaSeleccionada = null;

                        base.FinDeTurno();
                    }
                }
            }
        }
    }
    public override void Roba()
    {
        Debug.Log("Jugador robo carta");
        GameManager.manager.TomarCartaMazo(true);
        yaRobo = true;
    }

    public override bool CheckTieneCartaCorrectaEnMano()
    {
        bool tieneCarta = false;

        if (cartas.Count <= 0)
            return tieneCarta;

        foreach (Carta c in cartas)
        {
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.esRojo == c.esRojo)
            {
                tieneCarta = true;
            }
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.valor == c.valor)
            {
                tieneCarta = true;
            }
        }

        if (cartaSeleccionada != null)
        {
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.esRojo == cartaSeleccionada.esRojo)
                tieneCarta = true;
            if (GameManager.manager.cartaEnLaSimaDeLaMesa.valor == cartaSeleccionada.valor)
                tieneCarta = true;
        }

        return tieneCarta;
    }

    public override void BuscarCarta(Carta c)
    {
        if (cartas.Contains(c))
        {
            if (cartaSeleccionada != null)
                cartas.Add(cartaSeleccionada);    
            cartaSeleccionada = cartas[cartas.IndexOf(c)];
            cartas.Remove(cartaSeleccionada);
        }
    }
}
