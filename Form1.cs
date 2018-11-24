using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        float teste;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void validaMatriz(TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "1";
            }
            else
            {
                if (!float.TryParse(t.Text, out teste))
                {
                    MessageBox.Show("Valor não suportado");
                    this.ActiveControl = t;
                }
            }

        }

        //MUDAR COISAS AQUI
        private float[] calculaMatriz(float[,] mat, float[] res)
        {
            float[] n = { 0, 0, 0 }; // atual
            float[] nMenos1 = { 0, 0, 0 }; // 
            for (int k = 0; k < res.Length; k++)
            {
                nMenos1[k] = 0;
            }

            float paradaConv = 0.001F; //critério de parada de convergencia
            float maxInteracoes = 1000; //critério de parada por interação
            int numInteracoes = 0; //contador de interações
            bool continuar = true;

           
                for (var i = 0; i < res.Length; i++)
                {
                    float soma = 0;
                    for (var j2 = 0; j2 < i; j2++)
                    {
                        soma = soma + mat[i, j2] * n[j2];
                    }
                    for (var j1 = i + 1; j1 < res.Length; j1++)
                    {
                        soma = soma + mat[i, j1] * nMenos1[j1];
                    }
                    n[i] = (res[i] - soma) / mat[i, i];
                }
            
            return n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[,] mat = {{float.Parse(x1.Text), float.Parse(y1.Text), float.Parse(z1.Text)},
                            {float.Parse(x2.Text), float.Parse(y2.Text), float.Parse(z2.Text)},
                            {float.Parse(x3.Text), float.Parse(y3.Text), float.Parse(z3.Text)}};
            float[] res = {float.Parse(r1.Text), float.Parse(r2.Text), float.Parse(r3.Text)};
            float[] resMat = calculaMatriz(mat, res);
            Result1.Text = resMat[0].ToString();
            Result2.Text = resMat[1].ToString();
            Result3.Text = resMat[2].ToString();

        }

        private float modulus(float t)
        {
            float n;
            if(t < 0)
            {
                n = t * -1;
            }
            else
            {
                n = t;
            }
            return n;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            validaMatriz(x1);
            validaMatriz(x2);
            validaMatriz(x3);
            validaMatriz(y1);
            validaMatriz(y2);
            validaMatriz(y3);
            validaMatriz(z1);
            validaMatriz(z2);
            validaMatriz(z3);

            //arrumar - critérios estão incorretos
     //       if (!(float.Parse(x1.Text) > modulus(float.Parse(y1.Text))) && !(float.Parse(x1.Text) > modulus(float.Parse(z1.Text))))
       //     {
         //       MessageBox.Show("Impossível gerar uma solução.");
     //       }
       //     if (!(float.Parse(y2.Text) > modulus(float.Parse(x2.Text))) && !(float.Parse(y2.Text) > modulus(float.Parse(z2.Text))))
         //   {
           //     MessageBox.Show("Impossível gerar uma solução");
     //       }
       //     if (!(float.Parse(z3.Text) > modulus(float.Parse(x3.Text))) && !(float.Parse(z3.Text) > modulus(float.Parse(y3.Text))))
         //   {
           //     MessageBox.Show("Impossível gerar uma solução");
     //       }

            button1.Enabled = true;
        }

        private void x1_Leave(object sender, EventArgs e)
        {
            validaMatriz(x1);
        }
        private void x2_Leave(object sender, EventArgs e)
        {
            validaMatriz(x2);
        }
        private void x3_Leave(object sender, EventArgs e)
        {
            validaMatriz(x3);
        }
        private void y1_Leave(object sender, EventArgs e)
        {
            validaMatriz(y1);
        }
        private void y2_Leave(object sender, EventArgs e)
        {
            validaMatriz(y2);
        }
        private void y3_Leave(object sender, EventArgs e)
        {
            validaMatriz(y3);
        }
        private void z1_Leave(object sender, EventArgs e)
        {
            validaMatriz(z1);
        }
        private void z2_Leave(object sender, EventArgs e)
        {
            validaMatriz(z2);
        }
        private void z3_Leave(object sender, EventArgs e)
        {
            validaMatriz(z3);
        }
        private void r1_Leave(object sender, EventArgs e)
        {
            validaMatriz(r1);
        }
        private void r2_Leave(object sender, EventArgs e)
        {
            validaMatriz(r2);
        }
        private void r3_Leave(object sender, EventArgs e)
        {
            validaMatriz(r3);
        }

    }
}
