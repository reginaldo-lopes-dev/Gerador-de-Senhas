using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Gerador_de_Senhas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            btnSenha.Clicked += Btn_clicked;
            btnCopy.Clicked += Btn_copy;
        }

        private void NumbersToo(object sender, CheckedChangedEventArgs e)
        {

        }

        private void UpperToo(object sender, CheckedChangedEventArgs e)
        {

        }
        private void SymbolsToo(object sender, CheckedChangedEventArgs e)
        {

        }
        async private void Btn_copy(object sender, EventArgs e)
        {
            await DisplayAlert("Sucesso!", "Copiado para a área de transferência", "OK");
            string copy = lblsenha.Text;
            await Clipboard.SetTextAsync(copy);
        }

        public void Btn_clicked(object sender, EventArgs e)
        {
            try
            {
                string letters = "abcdefghijklmnopqrstuvwxyz";
                if (cb_numbers.IsChecked)
                {
                    letters += "0123456789";

                }
                if (cb_symbols.IsChecked)
                {
                    letters += "_.-@";
                }
                if (cb_upper.IsChecked)
                {
                    letters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                }
                StringBuilder senha = new StringBuilder();
                Random rnd = new Random();
                int tamsenha = Int32.Parse(tamanho.Text);
                while (0 < tamsenha--)
                {
                    senha.Append(letters[rnd.Next(letters.Length)]);
                }
                lblsenha.IsVisible = true;
                lblsenha.IsEnabled = true;
                lblsenha.Text = senha.ToString();
                btnCopy.IsVisible = true;
            }
            catch
            {
                lblsenha.IsVisible = true;
                lblsenha.IsEnabled = true;
                lblsenha.Text = "Por favor, insira o tamanho da senha";
            }




        }
    }
}
