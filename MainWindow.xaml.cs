
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeusTitulosWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

       
        }

  
        private void btnClickBuscar (object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(textEstado.Text);



            if (!string.IsNullOrWhiteSpace(textCep.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())

                    try
                    {
                        var end = ws.consultaCEP(textCep.Text.Trim());
                        textEstado.Text = end.uf;
                        textCidade.Text = end.cidade;
                        textBairro.Text = end.bairro;
                        textRua.Text = end.end;

                    }
                    catch (Exception ex)
                    {
                        textEstado.Text = "";
                        textCidade.Text = "";
                        textBairro.Text = "";
                        textRua.Text = "";

                        MessageBox.Show(ex.Message);
                    }
            }
            else
            {
                textEstado.Text = "";
                textCidade.Text = "";
                textBairro.Text = "";
                textRua.Text = "";
                MessageBox.Show("Informe um CEP válido ! ");
            }


          

        }

        private void btnClickLimpar(object sender, RoutedEventArgs e)
        {

            textEstado.Text = "";
            textCidade.Text = "";
            textBairro.Text = "";
            textRua.Text = "";
           // MessageBox.Show("Clicou em LIMPAR");
        }
        private void btnClickSair(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Clicou em SAIR");
            this.Close();
        }



    }
}
