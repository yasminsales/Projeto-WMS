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

        private int ObterStatusCadastro()
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_cnpj.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_razaoSocial.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_nomeFantasia.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_telefoneFixo.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_telefoneCelular.Text) &&
                    !string.IsNullOrWhiteSpace(this.comboBox_banco.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_agencia.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_contaCorrente.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_contaCorrente.Text) &&
                    !string.IsNullOrWhiteSpace(this.comboBox_segmento.Text) &&
                    !string.IsNullOrWhiteSpace(this.comboBox_estado.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_cidade.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_bairro.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_logradouro.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_numero.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_complemento.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_cep.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_email.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_inscricaoEstadual.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_inscricaoMunicipal.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_nomeContato.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_dadosAdicionais1.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_dadosAdicionais2.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_dadosAdicionais3.Text))
            {
                return 1;
            }

            return 0;
        }

        private void Criar()
        {
            OleDbConnection con = new OleDbConnection(Globals.ConnString);
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO g1_tblFornecedores " +
                    " (CNPJ, razaoSocial, nomeFantasia, telefoneFixo, telefoneCelular, " +
                    //"idBanco, " +
                    "agencia, contaCorrente, " +
                    //"digitoContaCorrente, idSegmento, idEstado, idCidade," +
                    //" idBairro, " +
                    "logradouro, " +
                    //"numero, " +
                    "complemento, CEP, email, inscricaoEstadual," +
                    " inscricaoMunicipal, nomeContato, " +
                    //"statusCadastro, " +
                    "dadosAdicionais1, " +
                    "dadosAdicionais2, dadosAdicionais3)" +
                    "VALUES " +
                    " (@CNPJ, @razaoSocial, @nomeFantasia, @telefoneFixo, @telefoneCelular, " +
                    //"@idBanco, " +
                    "@agencia, @contaCorrente, " +
                    //"@digitoContaCorrente, @idSegmento, @idEstado, @idCidade," +
                    //" @idBairro, " +
                    "@logradouro, " +
                    //"@numero, " +
                    "@complemento, @CEP, @email, @inscricaoEstadual," +
                    " @inscricaoMunicipal, @nomeContato, " +
                    //"@statusCadastro, " +
                    "@dadosAdicionais1, " +
                    "@dadosAdicionais2, @dadosAdicionais3);";

            cmd.Parameters.AddWithValue("CNPJ", this.textBox_cnpj.Text);
            cmd.Parameters.AddWithValue("razaoSocial", this.textBox_razaoSocial.Text);
            cmd.Parameters.AddWithValue("nomeFantasia", this.textBox_nomeFantasia.Text);
            cmd.Parameters.AddWithValue("telefoneFixo", this.textBox_telefoneFixo.Text);
            cmd.Parameters.AddWithValue("telefoneCelular", this.textBox_telefoneCelular.Text);
            //cmd.Parameters.AddWithValue("idBanco", this.comboBox_banco.Text);
            cmd.Parameters.AddWithValue("agencia", this.textBox_agencia.Text);
            cmd.Parameters.AddWithValue("contaCorrente", this.textBox_contaCorrente.Text);
            //cmd.Parameters.AddWithValue("digitoContaCorrente", this.textBox_contaCorrente.Text);
            //cmd.Parameters.AddWithValue("idSegmento", this.comboBox_segmento.Text);
            //cmd.Parameters.AddWithValue("idEstado", this.comboBox_estado.Text);
            //cmd.Parameters.AddWithValue("idCidade", this.textBox_cidade.Text);
            //cmd.Parameters.AddWithValue("idBairro", this.textBox_bairro.Text);
            cmd.Parameters.AddWithValue("Logradouro", this.textBox_logradouro.Text);
            if (!string.IsNullOrWhiteSpace(this.textBox_numero.Text) &&
                int.TryParse(this.textBox_numero.Text, out int numeroInt))
            {
                cmd.Parameters.AddWithValue("Numero", numeroInt);
            }
            cmd.Parameters.AddWithValue("Complemento", this.textBox_complemento.Text);
            cmd.Parameters.AddWithValue("CEP", this.textBox_cep.Text);
            cmd.Parameters.AddWithValue("email", this.textBox_email.Text);
            cmd.Parameters.AddWithValue("inscricaoEstadual", this.textBox_inscricaoEstadual.Text);
            cmd.Parameters.AddWithValue("inscricaoMunicipal", this.textBox_inscricaoMunicipal.Text);
            cmd.Parameters.AddWithValue("nomeContato", this.textBox_nomeContato.Text);

            cmd.Parameters.AddWithValue("dadosAdicionais1", this.textBox_dadosAdicionais1.Text);
            cmd.Parameters.AddWithValue("dadosAdicionais2", this.textBox_dadosAdicionais2.Text);
            cmd.Parameters.AddWithValue("dadosAdicionais3", this.textBox_dadosAdicionais3.Text);
            //cmd.Parameters.AddWithValue("statusCadastro", ObterStatusCadastro());

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Dados inseridos com sucesso");


            this.Close();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Criar();
            Consultar(null, null);
        }
    }
}
