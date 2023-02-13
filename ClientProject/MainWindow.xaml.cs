using ClientProject.DatabaseService;
using ClientProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ClientProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<UserData> DatabaseUsers { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Read();
        }

        public void Create()
        {
            using (InputDataContext context = new InputDataContext())
            {
                var client = ClientName.Text;
                var department = DepartmentName.Text;
                var purchaseOrder = PurchaseOrder.Text;
                var tinNo = TinNumber.Text;
                var address = Address.Text;
                var type = TypeName.Text;
                var quantity = Quantity.Text;
                var items = Items.Text;
                var unitPrice = UnitPrice.Text;
                var amount = Amount.Text;
                var checkAmount = CheckAmount.Text;
                var withTax = WithholdingTax.Text;
                var officeReceiptNo = ReceiptNumber.Text;
                var datePaid = DatePaid.Text;
                var bir2307 = Bir2307.Text;
                var bir2306 = Bir2306.Text;

                if (client != null && department != null && purchaseOrder != null && tinNo != null
                    && address != null && type != null && quantity != null && items != null && unitPrice != null && 
                    amount != null && checkAmount != null && withTax != null &&  officeReceiptNo != null && 
                    datePaid != null && bir2307 != null && bir2306 != null)
                {
                    context.UserData.Add(new UserData()
                    {
                        ClientName = client,
                        Department = department,
                        PurchaseOrder = purchaseOrder,
                        TinNumber = tinNo,
                        Address = address,
                        Type = type,
                        Quantity = quantity,
                        Items = items,
                        UnitPrice = unitPrice,
                        Amount = amount,
                        CheckAmount = checkAmount,
                        WithTax = withTax,
                        OfficeReceiptNumber = officeReceiptNo,
                        DatePaid = datePaid,
                        Bir2306 = bir2306,
                        Bir2307 = bir2307,
                    });

                    context.SaveChanges();
                }
            }
        }
        public void Read()
        {
            using (InputDataContext context = new InputDataContext())
            {
                DatabaseUsers = context.UserData.ToList();
                ProductListView.ItemsSource = DatabaseUsers;
            }
        }

        public void Update()
        {
            using (InputDataContext context = new InputDataContext())
            {
                UserData? selectedUser = ProductListView.SelectedItem as UserData;

                var client = ClientName.Text;
                var department = DepartmentName.Text;
                var purchaseOrder = PurchaseOrder.Text;
                var tinNo = TinNumber.Text;
                var address = Address.Text;
                var type = TypeName.Text;
                var quantity = Quantity.Text;
                var items = Items.Text;
                var unitPrice = UnitPrice.Text;
                var amount = Amount.Text;
                var checkAmount = CheckAmount.Text;
                var withTax = WithholdingTax.Text;
                var officeReceiptNo = ReceiptNumber.Text;
                var datePaid = DatePaid.Text;
                var bir2307 = Bir2307.Text;
                var bir2306 = Bir2306.Text;

                if (client != null && department != null && purchaseOrder != null && tinNo != null
                    && address != null && type != null && quantity != null && items != null && unitPrice != null &&
                    amount != null && checkAmount != null && withTax != null && officeReceiptNo != null &&
                    datePaid != null && bir2307 != null && bir2306 != null)
                {
                    try {
                        UserData? userdata = context.UserData.Find(selectedUser.ClientId);

                        userdata.ClientName = client;
                        userdata.Department = department;
                        userdata.PurchaseOrder = purchaseOrder;
                        userdata.TinNumber = tinNo;
                        userdata.Address = address;
                        userdata.Type = type;
                        userdata.Quantity = quantity;
                        userdata.Items = items;
                        userdata.UnitPrice = unitPrice;
                        userdata.Amount = amount;
                        userdata.CheckAmount = checkAmount;
                        userdata.WithTax = withTax;
                        userdata.OfficeReceiptNumber = officeReceiptNo;
                        userdata.DatePaid = datePaid;
                        userdata.Bir2307 = bir2307;
                        userdata.Bir2306 = bir2306;


                        context.SaveChanges();
                        Read();
                    }
                    catch (Exception e) { 

                    }
               
                }
            }
        }

        public void Delete()
        {
            using (InputDataContext context = new InputDataContext())
            {
                UserData? selectedUser = ProductListView.SelectedItem as UserData;


                if (selectedUser != null)
                {

                    //UserData userdata = context.UserData.Find(selectedUser.ClientId);
                    try
                    {

                        UserData userdata = context.UserData.Single(x => x.ClientId == selectedUser.ClientId);

                        context.Remove(userdata);
                        context.SaveChanges();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();
        }

        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
             ProductListView.Items.Clear();
            }
            catch(Exception q)
            {
                //MessageBox.Show(q);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (InputDataContext context = new InputDataContext())
            {
                DatabaseUsers = context.UserData.ToList();
                ProductListView.ItemsSource = DatabaseUsers;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ProductListView.ItemsSource);
                view.Filter = item =>
                {
                    UserData uitem = item as UserData;
                    return uitem != null && uitem.ClientName.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                };

                CollectionViewSource.GetDefaultView(ProductListView.ItemsSource).Refresh();
            }
        }
    }
}
