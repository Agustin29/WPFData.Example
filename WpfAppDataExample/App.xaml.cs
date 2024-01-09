using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfAppDataExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //GENERAMOS UNA INSTANCIA DE NUESTRA CLASE (STOREDB->debe ser public)
        private static StoreDB storeDB = new StoreDB();
        //CREAMOS UNA PROPIEDAD
        public static StoreDB StoreDB
        {
            get { return storeDB; }
        }

    }

}
