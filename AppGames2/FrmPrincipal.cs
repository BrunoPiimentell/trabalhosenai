using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGames2
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Games game = new Games();
            List<Games> jogo = game.listagames();
            dgvJogo.DataSource = jogo;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Deseja realmente sair do aplicativo?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" && txtDesenvolvedora.Text =="")
            {
                MessageBox.Show("Preencha o formulário!");
                this.txtNome.Focus();
            }
            else
            {
                Games game = new Games();
                if (game.RegistroRepetido(txtNome.Text) != false)
                {
                    MessageBox.Show("Este jogo já está em nossos Banco de Dados!");
                    this.txtNome.Focus();
                }
                else
                {
                    int nota = Convert.ToInt32(txtNota.Text);
                    game.Inserir(txtNome.Text, txtDesenvolvedora.Text, txtAno.Text, nota);
                    MessageBox.Show("Jogo cadastrado com sucesso!");
                    List<Games> games = game.listagames();
                    dgvJogo.DataSource = games;
                    txtNome.Text = "";
                    txtDesenvolvedora.Text = "";
                    txtAno.Text = "";
                    txtNota.Text = "";
                    this.txtNome.Focus();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            int nota = Convert.ToInt32(txtNota.Text);
            Games game = new Games();
            game.Atualizar(Id, txtNome.Text,txtDesenvolvedora.Text,txtAno.Text, nota);
            MessageBox.Show("Jogo atualizado com sucesso!");
            List<Games> games = game.listagames();
            dgvJogo.DataSource = games;
            txtId.Text = "";
            txtNome.Text = "";
            txtDesenvolvedora.Text = "";
            txtAno.Text = "";
            txtNota.Text = "";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.txtNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Games game = new Games();
            game.Excluir(Id);
            MessageBox.Show("Jogo excluído com sucesso!");
            List<Games> games = game.listagames();
            dgvJogo.DataSource = games;
            txtId.Text = "";
            txtNome.Text = "";
            txtDesenvolvedora.Text = "";
            txtAno.Text = "";
            txtNota.Text = "";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.txtNome.Focus();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Por favor, digite um ID!");
                this.txtId.Focus();
            }
            else
            {
                int Id = Convert.ToInt32(txtId.Text.Trim());
                Games game = new Games();
                game.Localizar(Id);
                txtNome.Text = game.nome;
                txtDesenvolvedora.Text = game.desenvolvedora;
                txtAno.Text = game.ano;
                txtNota.Text = Convert.ToString(game.nota);
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void dgvJogo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvJogo.Rows[e.RowIndex];
                row.Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtDesenvolvedora.Text = row.Cells[2].Value.ToString();
                txtAno.Text = row.Cells[3].Value.ToString();
                txtNota.Text = row.Cells[4].Value.ToString();
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }
    }
}
