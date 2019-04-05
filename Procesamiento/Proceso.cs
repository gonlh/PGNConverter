using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Modelo;
using System.Text.RegularExpressions;

namespace Procesamiento
{
    public class Proceso
    {
        private string pathArchivo;

        public Proceso(){}
        public Proceso(string pathArchivo)
        {
            this.pathArchivo = pathArchivo;
        }

        public void Procesar()
        {
            Variante lineaPrincipal = new Variante(1);
            Jugada primerJugada = new Jugada(1);
           

            List<string> wordsList = new List<string>();

            StreamReader sr = new StreamReader(pathArchivo);
            
            string line = sr.ReadToEnd();                
            var words = line.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);  
            sr.Close();  

            int palabrasProcesadas = CargarVariante(0, words,ref lineaPrincipal, primerJugada);


        }

        private int CargarVariante(int posicionArray, string[] words, ref Variante variante, Jugada jugada)
        {
            var word = words[posicionArray];
            

            if(EsJugadaBlanca(word))
            {
                jugada.JugadaBlanco = ExtraerJugada(word);
                jugada.Estado = Estado.JugadaBlancaCargada;
            }
            else if(EsJugadaNegra(word))
            {
                jugada.JugadaNegro = ExtraerJugada(word);
                jugada.Estado = Estado.JugadaNegraCargada; 
                variante.Jugadas.Add(jugada);
            }
            else if(EsComentario(word))
            {
                switch(jugada.Estado)
                {
                    case Estado.JugadaBlancaSinCargar : 
                    {
                        jugada.ComentarioPrevioBlanco += " "+ word;
                        break;
                    }

                    case Estado.JugadaBlancaCargada: 
                    {
                        jugada.ComentarioPosteriorBlanco += " "+ word;
                        break;
                    }  
                    case Estado.JugadaNegraCargada:
                    {
                        jugada.ComentarioPosteriorNegro += " " + word; 
                        break;
                    }                  
                }
            }
            
            if(AbreVariante(word, jugada, variante.NumeroJugadaInicio))
            {
                Variante nuevaVariante = new  Variante(jugada.NumeroJugada);
                Jugada jugadaDeVariante = new Jugada(jugada.NumeroJugada);
                jugadaDeVariante.Estado = jugada.Estado;
                words[posicionArray] = EliminarAbridorVariante(word);

                int posicionesAvanzadas = CargarVariante(posicionArray, words, ref nuevaVariante, jugadaDeVariante);
                if(jugada.Estado == Estado.JugadaBlancaCargada)
                {
                    if(jugada.VariantesBlanco != null)
                    {
                        jugada.VariantesBlanco.Add(nuevaVariante);
                    }
                }
                posicionArray = posicionesAvanzadas;
               
            }
            if (CierraVariante(word))
            {
                posicionArray ++;
                return posicionArray;
            }

            if(jugada.Estado == Estado.JugadaNegraCargada)
            {
                return CargarVariante(posicionArray++, words,ref variante, new Jugada(jugada.NumeroJugada+1));
            }
            else
            {
                return CargarVariante(posicionArray++, words,ref variante, jugada);
            }
        }

        private bool CierraVariante(string word)
        {
            throw new NotImplementedException();
        }

        private string EliminarAbridorVariante(string word)
        {
            throw new NotImplementedException();
        }

        private bool AbreVariante(string word, Jugada jugada, int numeroJugadaInicio)
        {
            throw new NotImplementedException();
        }

        private bool EsComentario(string word)
        {
            throw new NotImplementedException();
        }

         

        private bool EsJugadaBlanca(string word)
        {
            var regex = new Regex(@"\d{1,3}[.][\s]?[a-h][1-8]|\d{1,3}[.][\s]?[a-h][x]?[a-h][1-8]
            |\d{1,3}[.][\s]?[TCARD][a-h]?[1-8]?[x]?[a-h][1-8]");
            return regex.IsMatch(word);
            
        }

        private bool EsJugadaNegra(string word)
        {
            var regex = new Regex(@"\d{1,3}[.]{3,3}[\s]?[a-h][1-8]|\d{1,3}[.]{3,3}[\s]?[a-h][x]?[a-h][1-8]
            |\d{1,3}[.]{3,3}[\s]?[TCARD][a-h]?[1-8]?[x]?[a-h][1-8]");
            return regex.IsMatch(word);

        }

        private int ExtraerNumeroJugada(string word)
        {            
            Match m = Regex.Match(word, "(\\d+)");
            string num = string.Empty;

            if (m.Success)
            {
                num = m.Value;
            }
            int numeroJugada = 0;
            Int32.TryParse(num, out numeroJugada);
            return numeroJugada;
        }

        private bool EsResultado(string word)
        {
            return false;    //Todo        
        }

        private bool  EsCorteVariante(string word)
        {
            return false; //Todo
        }
        private bool EsCorteEInicioDeNuevaVariante(string word)
        {
            return false; //Todo
        }
        private string ExtraerJugada(string word)
        {
            return string.Empty; //TODO
        }




        
    }
}
