using onthi05.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

namespace onthi05
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
        QuanLyBenhNhanDBContext db = new QuanLyBenhNhanDBContext();

        private void txtmabenhnhan_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HienThiDuLieu()
        {
            var query = from bn in db.BenhNhans
                        orderby bn.SoNgayNamVien descending
                        let VienPhi = string.Format(new CultureInfo("Vi-VN"), "{0:#,##0}", bn.SoNgayNamVien * 200000)
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            bn.MaKhoa,
                            bn.SoNgayNamVien,
                            VienPhi
                        };
            dgvbenhnhan.ItemsSource = query.ToList();
        }

        private void HienThiCB()
        {
            var query = from khoa in db.Khoas select khoa;
            cbokhoa.ItemsSource = query.ToList();
            cbokhoa.DisplayMemberPath = "BenhNhan";
            cbokhoa.SelectedValuePath = "MaKhoa";
            cbokhoa.SelectedIndex = 0;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
            HienThiCB();
        }

        private void dgvbenhnhan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgvbenhnhan.SelectedItem != null)
            {
                try
                {
                    Type t = dgvbenhnhan.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtmabenhnhan.Text = p[0].GetValue(dgvbenhnhan.SelectedValue).ToString();
                    txthoten.Text = p[1].GetValue(dgvbenhnhan.SelectedValue).ToString();
                    cbokhoa.SelectedValue = p[2].GetValue(dgvbenhnhan.SelectedValue).ToString();
                    txtsongaynamvien.Text = p[3].GetValue(dgvbenhnhan.SelectedValue).ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra",ex.Message);
                }
            }
        }

        private bool checkMaBenhNhan(int ma)
        {
            var query = db.BenhNhans.SingleOrDefault(bn => bn.MaBn.Equals(ma));
            if(query == null)
                return false;
            return true;
        }

        private bool checkDL()
        {
            if (txtmabenhnhan.Text == "" || txthoten.Text == "" || txtsongaynamvien.Text == "")
                return false;
            if(!Regex.IsMatch(txtmabenhnhan.Text,@"\d+"))
                return false;
            if(!Regex.IsMatch(txthoten.Text,@"\w+"))
                return false;
            if(!Regex.IsMatch(txtsongaynamvien.Text,@"\d+"))
                return false;
            else
            {
                int soNgay;
                    if(!int.TryParse(txtsongaynamvien.Text, out soNgay))
                        return false;
                    else
                    {
                        if(soNgay < 1)
                            return false;
                    }
            }
            return true;
        }

        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            if(checkDL())
            {
                try
                {
                    if(!checkMaBenhNhan(int.Parse(txtmabenhnhan.Text)))
                    {
                        BenhNhan bn = new BenhNhan();
                        bn.MaBn = int.Parse(txtmabenhnhan.Text);
                        bn.HoTen = txthoten.Text;
                        bn.SoNgayNamVien = int.Parse(txtsongaynamvien.Text);
                        Khoa khoa = (Khoa)cbokhoa.SelectedItem;
                        bn.MaKhoa = khoa.MaKhoa;
                        db.BenhNhans.Add(bn);
                        db.SaveChanges();
                        MessageBox.Show("Thêm nhân viên thành công");
                        HienThiDuLieu();
                    }
                    else
                    {
                        MessageBox.Show("Mã bệnh nhân đã tồn tại");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm "+ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra dữ liệu !");
            }
        }

        private void btntim_Click(object sender, RoutedEventArgs e)
        {
            //var query = db.BenhNhans.OrderByDescending(bn => bn.VienPhi).FirstOrDefault();
            var query = from bn in db.BenhNhans where bn.MaKhoa == 1 select bn;
            Window2 show = new Window2();
            show.dgv2.ItemsSource = query.Select(query => new
            {
                MaBn = query.MaBn,
                HoTen = query.HoTen,
                MaKhoa = query.MaKhoaNavigation.BenhNhan,
                SoNgayNamVien = query.SoNgayNamVien,
                VienPhi = string.Format(new CultureInfo("Vi-VN"), "{0:#,##0}", query.SoNgayNamVien * 200000) 
            }).ToList();
            show.Show();
        }
    }
}
