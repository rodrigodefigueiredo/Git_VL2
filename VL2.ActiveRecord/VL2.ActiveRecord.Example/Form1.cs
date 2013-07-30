using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VL2.ActiveRecord.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.LimpaTexto();

                ManagerActiveRecord.DataBaseInitialize();
                ActiveRecordStarter.CreateSchema();
                txtScript.Text = "Schema Criado Com Sucesso!";
            }
            catch (Exception ex)
            {
                txtScript.Text = "Erro ao Criar Schema /n" + ex.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.LimpaTexto();
                ManagerActiveRecord.DataBaseInitialize();
                ActiveRecordStarter.GenerateCreationScripts("C:\\Windows\\Temp\\ActiveRecord\\script_bd2_TESTE_oracle_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".sql");
                txtScript.Text = "Arquivo criado na pasta C:\\Windows\\Temp\\ActiveRecord\\ ";
            }
            catch (Exception ex)
            {
                txtScript.Text = "Erro ao Gerar arquivo SQL /n" + ex.ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.LimpaTexto();

                txtScript.Text = ManagerActiveRecord.GenerateUpdateSchema();
                txtScript.AppendText(Environment.NewLine + " Para ver o script sql de mudanca, altera o código , uma propriedade de student por exemplo");
            }
            catch (Exception ex)
            {
                txtScript.Text = "Erro ao gerar script de UPDATE Schema /n" + ex.ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtScript.Clear();
            ManagerActiveRecord.DataBaseInitialize();
            var student = new Student() { DataNascimento = DateTime.Now, Nome = "Rodrigo", SobreNome = "Figueiredo" };
            student.CreateAndFlush();
            txtScript.Text = "Registro Criado";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpaTexto();
            Student.DeleteAll();
            txtScript.Text = "Registros deletados";

        }

        private void LimpaTexto()
        {
            txtScript.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtScript.Clear();
            ManagerActiveRecord.DataBaseInitialize();

            var student = Example.Student.FindFirst();

            txtScript.Text = student.Id + " " + student.Nome;
        }
    }
}
