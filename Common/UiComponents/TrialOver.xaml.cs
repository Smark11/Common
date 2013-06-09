using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Common.UiComponents
{
    public partial class TrialOver : UserControl
    {
        MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();

        public TrialOver()
        {
            InitializeComponent();
        }

        private void PurchaseHandler(object sender, RoutedEventArgs e)
        {
            _marketPlaceDetailTask.Show();
        }
    }
}
