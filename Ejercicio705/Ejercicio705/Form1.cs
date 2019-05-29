using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Ejercicio705
{
    public partial class Form1 : Form
    {
        private static string InputBox(string texto) { InputBoxDialog ib = new InputBoxDialog(); ib.FormPrompt = texto; ib.DefaultValue = ""; ib.ShowDialog(); string s = ib.InputResponse; ib.Close(); return s; }

        ArrayList lAlumnos = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private float NotaMediaClase()
        {
            
            float media;
            media = 0;

            foreach (tAlumno al in lAlumnos)
            {
                media = media + al.MediaAlumno();
            }
            media = media / lAlumnos.Count;

            return media;
        }

        private int buscarAlumno(string nombre)
        {
            int pos, i;
            bool encontrado;
            tAlumno al;

            encontrado = false;
            pos = -1;
            i = 0;

            while (i < lAlumnos.Count && !encontrado)
            {
                al = (tAlumno)lAlumnos[i];
                if (al.Nombre == nombre)
                {
                    pos = i;
                    encontrado = true;
                }
                else
                    i++;
            }

            return pos;
        }

            private void button1_Click(object sender, EventArgs e)
        {
            float nota1, nota2, nota3;
            tAlumno alumno;
            alumno = new tAlumno();
            alumno.Nombre = InputBox("Introduzca el nombre: ");
            alumno.Telefono = InputBox("Introduzca el numero de telefono: ");
            alumno.Direccion = InputBox("Introduzca la dirección: ");

            nota1 = int.Parse(InputBox("Inserte nota 1: "));
            nota2 = int.Parse(InputBox("Inserte nota 2: "));
            nota3 = int.Parse(InputBox("Inserte nota 3: "));
            alumno.insertarNota(nota1);
            alumno.insertarNota(nota2);
            alumno.insertarNota(nota3);

            lAlumnos.Add(alumno);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            string texto;
            texto = "";

            for (i = 0; i < lAlumnos.Count; i++)
            {
                texto = texto + ((tAlumno)lAlumnos[i]).MostrarDatos() + "\n";
                texto = texto + ((tAlumno)lAlumnos[i]).NotasAlumno() + "\n" + "\n";

            }
            MessageBox.Show(texto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            float notaAlumno, notaClase;
            string texto;
            texto = "";
            notaAlumno = 0;
            notaClase = 0;

            notaClase = (float)NotaMediaClase();

            for (i = 0; i < lAlumnos.Count; i++)
            {
                notaAlumno = ((tAlumno)lAlumnos[i]).MediaAlumno();

                if (notaAlumno > notaClase)
                {
                    texto = texto + ((tAlumno)lAlumnos[i]).Nombre + " y su nota media es: " + ((tAlumno)lAlumnos[i]).MediaAlumno() + "\n";
                }
            }
            MessageBox.Show(texto);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string texto;
            texto = "";

            foreach (tAlumno al in lAlumnos)
            {
                if((float)al.MediaAlumno() >= 5)
                {
                    texto = texto + al.Nombre + " y su nota media es: " + al.MediaAlumno() + "\n";
                }
                
            }
            foreach (tAlumno al in lAlumnos)
            {
                if ((float)al.MediaAlumno() < 5)
                {
                    texto = texto + al.Nombre + " y su nota media es: " + al.MediaAlumno() + "\n";
                }

            }

            MessageBox.Show(texto);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i, j;
            tAlumno aux;


            for (i = 0; i < lAlumnos.Count; i++)
            {

                for (j = i + 1; j < lAlumnos.Count; j++)
                {
                    
                    if (String.Compare(((tAlumno)lAlumnos[i]).Nombre, ((tAlumno)lAlumnos[j]).Nombre) > 0)
                    {
                        aux = (tAlumno)lAlumnos[i];
                        lAlumnos[i] = (tAlumno)lAlumnos[j];
                        lAlumnos[j] = aux;
                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i, j;
            tAlumno aux;


            for (i = 0; i < lAlumnos.Count; i++)
            {

                for (j = i + 1; j < lAlumnos.Count; j++)
                {
                    aux = (tAlumno)lAlumnos[i];
                    if (((tAlumno)lAlumnos[i]).MediaAlumno() < ((tAlumno)lAlumnos[j]).MediaAlumno())
                    {

                        lAlumnos[i] = (tAlumno)lAlumnos[j];
                        lAlumnos[j] = aux;
                    }
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string texto;
            int pos;
            texto = InputBox("Introduzca el nombre que quiera borrar: ");
            if(buscarAlumno(texto) != -1)
            {
                pos = buscarAlumno(texto);
                lAlumnos.RemoveAt(pos);
            }
            else
                MessageBox.Show("No se ha encontrado");
        }
    }
}
