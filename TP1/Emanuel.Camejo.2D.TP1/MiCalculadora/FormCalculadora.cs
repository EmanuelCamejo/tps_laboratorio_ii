using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        
        public void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = -1;
            lstOperaciones.ClearSelected();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando  operando1 = new Operando(numero1);
            Operando  operando2 = new Operando(numero2);
            double resultado = Calculadora.Operar(operando1, operando2, char.Parse(operador));
            return resultado;
        }


        #region Eventos

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            cmbOperador.Items.Add('*');
            cmbOperador.Items.Add('/');
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?","Salir", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = resultado.ToString();
            lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.SelectedItem} {txtNumero2.Text} = {resultado.ToString()}");
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numero1 = new Operando();
            string resultadoDecimalABinario = numero1.DecimalBinario(txtNumero1.Text);
            lblResultado.Text = resultadoDecimalABinario;
            lstOperaciones.Items.Add($"Conversión de {txtNumero1.Text} a Binario: {resultadoDecimalABinario}");
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero1 = new Operando();
            string resultadoBinarioADecimal = numero1.BinarioDecimal(txtNumero1.Text);
            lblResultado.Text = resultadoBinarioADecimal;
            lstOperaciones.Items.Add($"Conversión de {txtNumero1.Text} a Decimal: { resultadoBinarioADecimal}");
        }

        #endregion
    }
}
