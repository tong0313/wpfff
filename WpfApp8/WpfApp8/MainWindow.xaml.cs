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

namespace WpfApp8
{
    /// <summary>

    /// </summary>
    public partial class MainWindow : Window
    {
        //儲存路徑
        string filePath = "";
        //判斷是否要儲存 
        string savedtext = "";


        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextArea.Text != savedtext)
            {
                if (MessageBox.Show("要儲存嗎?", "YES or NO", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    save();
                    open();
                }
                else
                {
                    open();
                }

            }
            else
            {
                open();
            }

        }

        // 存檔按鈕 
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            save();
            savedtext = TextArea.Text;
        }

        // 快速存檔 
        private void QuickSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fileTitle.Text == filePath)
            {
                System.IO.File.WriteAllText(filePath, TextArea.Text);
                savedtext = TextArea.Text;
            }
            else
            {
                save();
                savedtext = TextArea.Text;
            }

        }

        //新開檔案 
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedtext != TextArea.Text)
            {
                if (MessageBox.Show("要儲存嗎?", "YES or NO", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    save();
                }
                else
                {

                    //清空文字
                    TextArea.Text = "";

                    //判斷是否儲存過
                    savedtext = TextArea.Text;
                }
            }
            else
            {
                //設定案名為NEW 用作Save的判斷
                fileTitle.Text = "New";

                //清空文字方格
                TextArea.Text = "";

                //設定判斷是否儲存過
                savedtext = TextArea.Text;
            }
        }
        void save()
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                //檔案路徑 
                filePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(filePath, TextArea.Text);

                ////設定判斷是否儲存過
                savedtext = TextArea.Text;

                //設定是否需要另存的判斷
                fileTitle.Text = filePath;

            }
        }

        void open()
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 檔案路徑 
                filePath = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(filePath);

                //設定判斷是否儲存過
                savedtext = TextArea.Text;

                //判斷是否需要另存
                fileTitle.Text = filePath;
            }
        }
        //設定字體大小
        private void Front12_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 12;
        }
        //設定字體大小
        private void Front18_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 18;
        }
        //設定字體大小
        private void Front24_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 24;
        }
        //放大視窗
        private void Max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        

       
        //縮小視窗
      

        private void Max_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
       //關閉視窗
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (savedtext != TextArea.Text)
            {
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    save();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Min_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

  
    }
}
