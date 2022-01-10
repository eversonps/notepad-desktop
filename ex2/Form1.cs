using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ex2
{
    public partial class frmPrincipal : Form
    {
        // declaração de variaveis.
        bool v, v2;
        public frmSeg a = new frmSeg();
        string diretorio, texto;
        int cont=0, contb=0;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utilizado para salvar por cima do arquivo salvado como.
            // Caso seja a primeira vez que ele clicou, ele salvará como...

            v2 = true;
            if (cont <= 0)
            {
                save();
            }
            else
            {
                foreach (Form mdiChildForm in MdiChildren)
                {
                    if (mdiChildForm.GetType() == typeof(frmSeg))
                    {
                        v2 = false;
                    }
                }

                if (v2 == true)
                {
                    MessageBox.Show("Erro! não tem nenhum arquivo de texto aberto para ser salvo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    texto = a.rchNotepad.Text;
                    File.WriteAllText(diretorio, texto);
                    a.Text = Path.GetFileName(diretorio).Replace(".txt", "");
                }
            }
        }
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // código utilizado para criar um novo arquivo.

            cont = 0;

            if (!System.IO.File.Exists(diretorio) && a.rchNotepad.Text != "")
            {
                if (MessageBox.Show("tem certeza que deseja criar um novo arquivo sem salvar o arquivo atual?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Form mdiChildForm in MdiChildren)
                    {
                       mdiChildForm.Close();
                    }

                    a = new frmSeg();
                    a.MdiParent = this;
                    a.Show();
                    contb++;
                }
            }
            else          
            {
                foreach (Form mdiChildForm in MdiChildren)
                {
                    mdiChildForm.Close();
                }

                a = new frmSeg();
                a.MdiParent = this;
                a.Show();
                contb++;
            }
               
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sair do formulário.
            Application.Exit();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // código utilizado para abrir um arquivo de texto.

            foreach (Form mdiChildForm in MdiChildren)
            {
                if (mdiChildForm.GetType() == typeof(frmSeg))
                {
                    mdiChildForm.Close();
                }
            }

            OpenFileDialog abrir = new OpenFileDialog();

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                a = new frmSeg();
                a.MdiParent = this;
                string Arquivo = abrir.FileName;
                a.rchNotepad.Text = File.ReadAllText(Arquivo);
                a.Text = abrir.SafeFileName.Replace(".txt", "");
                a.Show();
            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utilizado para salvar como...
            save();            
        }

        public void save()
        {
            // método utilizado para salvar um arquivo.

            v = true;
            texto = a.rchNotepad.Text;
            SaveFileDialog salvar = new SaveFileDialog();

            foreach (Form mdiChildForm in MdiChildren)
            {
                if (mdiChildForm.GetType() == typeof(frmSeg))
                {
                    v = false;
                    if (salvar.ShowDialog() == DialogResult.OK)
                    {
                        diretorio = salvar.FileName;
                        diretorio += ".txt";
                        File.WriteAllText(diretorio, texto);
                        a.Text = Path.GetFileName(diretorio).Replace(".txt", "");
                        cont++;                       
                    }
                }
            }

            if(v == true)
                MessageBox.Show("Erro! não tem nenhum arquivo de texto aberto para ser salvo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
