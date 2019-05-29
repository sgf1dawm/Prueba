using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio705
{
    class tAlumno
    {
        private string mNombre;
        private string mTelefono;
        private string mDireccion;
        private ArrayList mnotas;

        public tAlumno()
        {
            mnotas = new ArrayList();
        }

        public string Nombre
        {
            get { return mNombre; }
            set { mNombre = value; }
        }

        public string Telefono
        {
            get { return mTelefono; }
            set { mTelefono = value; }
        }
        public string Direccion
        {
            get { return mDireccion; }
            set { mDireccion = value; }
        }

        public void insertarNota(float nota)
        {
            mnotas.Add(nota);
        }

        public float MediaAlumno()
        {
            int i;
            float notas, media;
            notas = 0;
            for (i = 0; i < mnotas.Count; i++)
            {
                notas = notas + (float)mnotas[i];
            }
            media = notas / mnotas.Count;

            return media;
        }

        public string MostrarDatos()
        {
            string texto;
            texto = "";

            texto = mNombre + "\n" + mDireccion + "\n" + mTelefono;
            return texto;
        }

        public string NotasAlumno()
        {
            int i;
            string texto;
            texto = "";

            for (i = 0; i < mnotas.Count; i++)
            {
                texto = texto + "trimestre " + i + ", la nota es: " + mnotas[i] + "\n";
            }
            return texto;
        }
    }
}
