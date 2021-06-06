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

        private IEnumerable<SelectItem> ObterItensSelect(string tabela, string colunaDesc, string colunaId)
        {
            OleDbConnection con = new OleDbConnection(Globals.ConnString);
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = $"Select {colunaId}, {colunaDesc} from {tabela}";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable itensDataTable = new DataTable();
            da.Fill(itensDataTable);
            con.Close();

            foreach (DataRow item in itensDataTable.Rows)
            {
                yield return new SelectItem
                {
                    Id = (int)item[colunaId],
                    Label = (string)item[colunaDesc]
                };
            }
        }

        private int ObterStatusCadastro()
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_cnpj.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_razaoSocial.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_nomeFantasia.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_telefoneFixo.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_telefoneCelular.Text) &&
                    comboBox_banco.SelectedItem != null &&
                    !string.IsNullOrWhiteSpace(this.textBox_agencia.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_contaCorrente.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_contaCorrente.Text) &&
                    !string.IsNullOrWhiteSpace(this.comboBox_segmento.Text) &&
                    comboBox_estado.SelectedItem != null &&
                    comboBox_cidade.SelectedItem != null &&
                    comboBox_bairro.SelectedItem != null &&
                    !string.IsNullOrWhiteSpace(this.textBox_logradouro.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_numero.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_complemento.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_cep.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_email.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_inscricaoEstadual.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_inscricaoMunicipal.Text) &&
                    comboBox_regimetTributacao.SelectedItem != null &&
                    comboBox_situacaoIcms.SelectedItem != null &&
                    comboBox_segmento.SelectedItem != null &&
                    !string.IsNullOrWhiteSpace(this.textBox_nomeContato.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_dadosAdicionais1.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_dadosAdicionais2.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_dadosAdicionais3.Text))
            {
                return 2;
            }

            return 1;
        }

        private int ObterValorSelecionado(ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null && comboBox.SelectedItem is SelectItem)
            {
                return ((SelectItem)comboBox.SelectedItem).Id;
            }

            return -1;
        }

        private void Criar()
        {
            OleDbConnection con = new OleDbConnection(Globals.ConnString);
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            int digitoInt = 0;
            if (!string.IsNullOrWhiteSpace(this.textBox_numero.Text))
            {
                int.TryParse(this.textBox_digitoContaCorrente.Text, out digitoInt);
            }

            int numeroInt = 0;
            if (!string.IsNullOrWhiteSpace(this.textBox_numero.Text))
            {
                int.TryParse(this.textBox_numero.Text, out numeroInt);
            }

            cmd.CommandText = "INSERT INTO g1_tblFornecedores " +
            /*1*/        " ( CNPJ, " +
                        "razaoSocial, " +
                        "nomeFantasia, " +
                        "telefoneFixo, " +
            /*5*/            "telefoneCelular, " +
                        "idBanco, " +
                        "agencia, " +
                        "contaCorrente, " +
                        "digitoContaCorrente, " +
              /*10*/          "idSegmento, " +
                        "idEstado, " +
                        "idCidade," +
                        " idBairro, " +
                        "logradouro, " +
               /*15*/         "numero, " +
                        "complemento, " +
                        "CEP, " +
                        "email, " +
                        "inscricaoEstadual," +
               /*20*/         " inscricaoMunicipal, " +
                        "nomeContato, " +
                        "statusCadastro, " +
                        "dadosAdicionais1, " +
                        "dadosAdicionais2, " +
                /*25*/        "dadosAdicionais3)" +
                    "VALUES " +
               /*1*/         $" ('{this.textBox_cnpj.Text}', " +
                            $"'{textBox_razaoSocial.Text}', " +
                            $"'{textBox_nomeFantasia.Text}', " +
                            $"'{textBox_telefoneFixo.Text}', " +
                /*5*/       $"'{textBox_telefoneCelular.Text}'," +
                            $"{ObterValorSelecionado(comboBox_banco)}," +
                            $"'{textBox_agencia.Text}'," +
                            $"'{textBox_contaCorrente.Text}', " +
                            $"{digitoInt}, " +
                 /*10*/     $"{ObterValorSelecionado(comboBox_segmento)}, " +
                            $"{ObterValorSelecionado(comboBox_estado)}," +
                            $"{ObterValorSelecionado(comboBox_cidade)}, " +
                            $"{ObterValorSelecionado(comboBox_bairro)}, " +
                            $"'{textBox_logradouro.Text}', " +
                   /*15*/   $"{numeroInt}, " +
                            $"'{textBox_complemento.Text}', " +
                            $"'{textBox_cep.Text}', " +
                            $"'{textBox_email.Text}', " +
                            $"'{textBox_inscricaoEstadual.Text}'," +
                     /*20*/ $"'{textBox_inscricaoMunicipal.Text}', " +
                            $"'{textBox_nomeContato.Text}', " +
                            $"{ObterStatusCadastro()}, " +
                            $"'{textBox_dadosAdicionais1.Text}', " +
                            $"'{textBox_dadosAdicionais2.Text}', " +
                      /*25*/$"'{textBox_dadosAdicionais3.Text}');";

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Dados inseridos com sucesso");
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Criar();
                Consultar(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar, forneça mais informações e tente novamente. " + ex.Message);
            }
        }

        private void PreencherSelects()
        {
            comboBox_bairro.Items.AddRange(ObterItensSelect("g1_tblBairro", "descBairro", "idBairro").ToArray());
            comboBox_banco.Items.AddRange(ObterItensSelect("g1_tblBanco", "codBanco", "idBanco").ToArray());
            comboBox_cidade.Items.AddRange(ObterItensSelect("g1_tblCidade", "descCidade", "idCidade").ToArray());
            comboBox_estado.Items.AddRange(ObterItensSelect("g1_tblEstado", "siglaEstado", "idEstado").ToArray());
            //comboBox_regimetTributacao.Items.AddRange(ObterItensSelect("g1_tblBairro", "descBairro", "idBairro").ToArray());
            comboBox_segmento.Items.AddRange(ObterItensSelect("g1_tblSegmento", "descSegmento", "idSegmento").ToArray());
            //comboBox_situacaoIcms.Items.AddRange(ObterItensSelect("g1_tblTipoTributo", "descSituacaoTributo", "idTipoTributo").ToArray());
        }

        private void CadastroFornecedores_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void CadastroFornecedores_Load(object sender, EventArgs e)
        {
            PreencherSelects();
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            var selectedCells = this.dataGridView1.SelectedCells;
            if (selectedCells.Count == 0)
            {
                MessageBox.Show("Uma linha deve ser selecionada.");
                return;
            }

            OleDbConnection con = new OleDbConnection(Globals.ConnString);
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            
            var selectedRowIndex = selectedCells[0].RowIndex;
            var rowData = this.dataGridView1.Rows[selectedRowIndex];
            var id = (int)rowData.Cells[0].Value;
            cmd.CommandText = "DELETE from g1_tblFornecedores WHERE idFornecedores = " + id;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected == 0)
            {
                MessageBox.Show("Nenhuma linha encontrada.");
            }
            else
            {
                MessageBox.Show("Dados excluidos com sucesso");
            }

            Consultar(null, null);
            con.Close();
        }
    }
}
