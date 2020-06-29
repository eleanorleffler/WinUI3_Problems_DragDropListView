using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DragDropListViewWinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            fillListView();
        }

        private void fillListView()
        {
            List<string> list = new List<string>();
            list.Add("Item 1");
            list.Add("Item 2");
            list.Add("Item 3");

            listView.ItemsSource = list;
        }

        private void listView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            draggedItems.Clear();
            foreach (string item in e.Items)
            {
                draggedItems.Add(item);
            }
        }

        private void dropGrid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "Open";
        }

        private void dropGrid_Drop(object sender, DragEventArgs e)
        {
            foreach (string item in draggedItems)
            {
                droppedItemsTextBlock.Text += Environment.NewLine + item;
            }
        }

        private List<string> draggedItems = new List<string>();
    }
}
