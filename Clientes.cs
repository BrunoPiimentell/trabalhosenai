using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBruno
{
    public partial class FrmPessoa : Form
    {
        public FrmPessoa()
        {
            InitializeComponent();
        }

        private void FrmPessoa_Load(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void dgvPessoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPessoa.Rows[e.RowIndex];
                row.Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCidade.Text = row.Cells[2].Value.ToString();
                txtEndereco.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
                txtDN.Text = row.Cells[5].Value.ToString();
                txtCelular.Text = row.Cells[6].Value.ToString();

            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Por favor digite um ID válido!!!");
                this.txtId.Focus();
            }
            else
            {
                int Id = Convert.ToInt32(txtId.Text.Trim());
                Pessoa pessoa = new Pessoa();
                pessoa.Localizar(Id);
                txtNome.Text = pessoa.nome;
                txtCidade.Text = pessoa.cidade;
                txtEndereco.Text = pessoa.endereco;
                txtEmail.Text = pessoa.email;
                txtDN.Text = pessoa.data;
                txtCelular.Text = pessoa.celular;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void btnInserir_Click_1(object sender, EventArgs e)
        {
            if (txtNome.Text == "" && txtCidade.Text == "" && txtEndereco.Text == "" && txtEmail.Text == "" && txtDN.Text == "" && txtCelular.Text == "")
            {
                MessageBox.Show("Não existem dados para cadastrar, por favor preencha o formulário", "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNome.Focus();
            }
            else
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Inserir(txtNome.Text, txtCidade.Text, txtEndereco.Text, txtEmail.Text, txtDN.Text, txtCelular.Text);
                MessageBox.Show("Pessoa cadastrada com sucesso!");
                List<Pessoa> pessoas = pessoa.listapessoa();
                dgvPessoa.DataSource = pessoas;
                txtId.Text = "";
                txtNome.Text = "";
                txtCidade.Text = "";
                txtEndereco.Text = "";
                txtEmail.Text = "";
                txtDN.Text = "";
                txtCelular.Text = "";
                this.txtNome.Focus();
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Atualizar(Id, txtNome.Text, txtCidade.Text, txtEndereco.Text, txtEmail.Text, txtDN.Text, txtCelular.Text);
            MessageBox.Show("Pessoa atualizada com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            txtId.Text = "";
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEndereco.Text = "";
            txtEmail.Text = "";
            txtDN.Text = "";
            txtCelular.Text = "";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.txtNome.Focus();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Excluir(Id);
            MessageBox.Show("Pessoa excluída com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            txtId.Text = "";
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEndereco.Text = "";
            txtEmail.Text = "";
            txtDN.Text = "";
            txtCelular.Text = "";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.txtNome.Focus();
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Deseja realmente sair", "Sair do aplicativo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
