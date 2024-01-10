using System.ComponentModel;

namespace WpfAppDataExample
{
    public class Product
    {
        private int productID;
        public int ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private string modelNumber;
        public string ModelNumber { get { return modelNumber; } set { modelNumber = value; } }

        private string modelName;
        public string ModelName { get { return modelName; } set { modelName = value; } }

        private decimal unitCost;
        public decimal UnitCost { get { return unitCost; } set { unitCost = value; } }

        private string description;
        public string Description { get { return description; } set { description = value; } }

        public Product(int productID, string modelNumber, string modelName, decimal unitCost, string description)
        {
            this.productID = productID;
            this.modelNumber = modelNumber;
            this.modelName = modelName;
            this.unitCost = unitCost;
            this.description = description;
        }
    }
}