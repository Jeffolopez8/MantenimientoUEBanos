using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MantenimientoUEBanos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRequipos : ContentPage
    {
        ZXingBarcodeImageView qr;
        public QRequipos(int id,string descripcion, string informacion)
        {
            InitializeComponent();
            lblNombreMascota.Text = "Código Qr para equipo: " + descripcion;
            txtValorQR.Text = "*Codigo:" + id + "*  No serie de equipo: " + descripcion + "  Informacion del equipo: " + informacion;

            generaAutoQR();
        }
        public void generaAutoQR()
        {
            qr = new ZXingBarcodeImageView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = txtValorQR.Text;
            stkQR.Children.Add(qr);



        }
    }
}