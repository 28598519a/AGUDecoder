using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace AGUDecoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            string selectPath = String.Empty;

            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.InitialFolder = App.Root;

            if (openFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectPath = openFolderDialog.Folder;
                if (!Directory.Exists(selectPath))
                {
                    selectPath = String.Empty;
                    lb_state.Content = "Error: 選擇的路徑不存在";
                }
            }

            lb_state.Content = String.Empty;
            lb_folderpath.Content = Path.GetFileName(selectPath);
            App.SelectFolder = selectPath;
        }

        private void btn_decode_Click(object sender, RoutedEventArgs e)
        {
            string signed = "encode";
            byte[] tmp = new byte[signed.Length];
            int count = 0;

            var result = System.Windows.MessageBox.Show("轉換將會覆蓋掉原始檔案，繼續?", "注意", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.Cancel)
                return;

            List<string> fileList = Directory.GetFiles(App.SelectFolder, "*", SearchOption.AllDirectories).ToList();

            foreach (string file in fileList)
            {
                byte[] data = File.ReadAllBytes(file);
                long data_size = data.Length;

                // File Sign check
                if (data_size < signed.Length) continue;
                Array.Copy(data, tmp, signed.Length);
                string aa = Encoding.UTF8.GetString(tmp);
                if (Encoding.UTF8.GetString(tmp) != signed) continue;

                long v8 = data_size - 7;
                byte[] v9 = new byte[v8];
                byte v10 = data[6];
                long v11 = 0;
                do
                {
                    v9[v11] = (byte)(data[v11 + 7] ^ v10);
                    v11++;
                } while (v8 != v11);

                File.WriteAllBytes(file, v9);
                count++;
            }
            lb_state.Content = $"已轉換 {count} 個檔案";
        }
    }
}
