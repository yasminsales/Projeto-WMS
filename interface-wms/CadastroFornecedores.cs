using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; 

namespace interface_wms
{
    public partial class CadastroFornecedores : Form
    {
        public CadastroFornecedores()
        {
            InitializeComponent();
        }

        private void Consultar(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(Globals.ConnString);
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from g1_tblFornecedores";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable tabelaFornecedores = new DataTable();
            da.Fill(tabelaFornecedores);
            dataGridView1.DataSource = tabelaFornecedores;
            con.Close();
        }

        private void Criar()
        {
            OleDbConnection con = new OleDbConnection(Globals.ConnString);
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO g1_tblFornecedores " +
                    " (CNPJ, razaoSocial, nomeFantasia, telefoneFixo, telefoneCelular, idBanco, " +
                    "agencia, contaCorrente, digitoContaCorrente, idSegmento, idEstado, idCidade," +
                    " idBairro, logradouro, numero, complemento, CEP, email, inscricaoEstadual," +
                    " inscricaoMunicipal, nomeContato, statusCadastro, dadosAdicionais1, " +
                    "dadosAdicionais2, dadosAdicionais3)" +
                    "VALUES " +
                    " (@CNPJ, @razaoSocial, @nomeFantasia, @telefoneFixo, @telefoneCelular, @idBanco, " +
                    "@agencia, @contaCorrente, @digitoContaCorrente, @idSegmento, @idEstado, @idCidade," +
                    " @idBairro, @logradouro, @numero, @complemento, @CEP, @email, @inscricaoEstadual," +
                    " @inscricaoMunicipal, @nomeContato, @statusCadastro, @dadosAdicionais1, " +
                    "@dadosAdicionais2, @dadosAdicionais3);";

            cmd.Parameters.AddWithValue("CNPJ", this.textBox_cnpj.Text);
            cmd.Parameters.AddWithValue("Razão Social", this.textBox_razaoSocial.Text);
            cmd.Parameters.AddWithValue("Nome Fantasia", this.textBox_nomeFantasia.Text);
            cmd.Parameters.AddWithValue("Telefone Fixo", this.textBox_telefoneFixo.Text);
            cmd.Parameters.AddWithValue("Telefone Celular", this.textBox_telefoneCelular.Text);
            cmd.Parameters.AddWithValue("idBanco", this.comboBox_banco.Text);
            cmd.Parameters.AddWithValue("Agencia", this.textBox_agencia.Text);
            cmd.Parameters.AddWithValue("Conta Corrente", this.textBox_contaCorrente.Text);
            cmd.Parameters.AddWithValue("Digito Conta Corrente", this.textBox_contaCorrente.Text);
            cmd.Parameters.AddWithValue("idSegmento", this.comboBox_segmento.Text);
            cmd.Parameters.AddWithValue("idEstado", this.comboBox_estado.Text);
            cmd.Parameters.AddWithValue("idCidade", this.textBox_cidade.Text);
            cmd.Parameters.AddWithValue("idBairro", this.textBox_bairro.Text);
            cmd.Parameters.AddWithValue("Logradouro", this.textBox_logradouro.Text);
            cmd.Parameters.AddWithValue("Numero", this.textBox_numero.Text);
            cmd.Parameters.AddWithValue("Complemento", this.textBox_complemento.Text);
            // CONTINUAR NO CEP 
            cmd.Parameters.AddWithValue("Inscrição municipal", this.textBox_inscricaoMunicipal.Text);



            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Dados inseridos com sucesso");

 
            this.Close();
        }
        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_razaoSocial_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox_telefoneFixo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_telefoneCelular_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Estado_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
