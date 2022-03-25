using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace exeApotek1_20200140001
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CreateTable();
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=FATCHULFAJRI\\FATCHULFAJRI;database=Apotek1;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("create table Apotek (ID_apotek char(8) PRIMARY KEY,nama_apotek varchar(15) NOT NULL, alamat_apotek varchar(30) NOT NULL,telepon_apotek int NOT NULL)", con); 
                SqlCommand cm2 = new SqlCommand("create table Supplier (ID_supplier char(8) PRIMARY KEY, nama_supplier varchar(15) NOT NULL, alamat_supplier varchar(30) NOT NULL, telepon_supplier int NOT NULL)", con);
                SqlCommand cm3 = new SqlCommand("create table Karyawan (ID_karyawan char(8) PRIMARY KEY, nama_karyawan varchar(15) NOT NULL, jk_karyawan char(1) constraint ck_jk check(jk_karyawan IN('L', 'P')), alamat_karyawan varchar(30) NOT NULL, ID_apotek char(8) FOREIGN KEY(ID_apotek) REFERENCES Apotek(ID_apotek))", con);
                SqlCommand cm4 = new SqlCommand("create table Pelanggan (ID_pelanggan char(8) PRIMARY KEY, nama_pelanggan varchar(15) NOT NULL)", con);
                SqlCommand cm5 = new SqlCommand("create table Obat (ID_obat char(8) PRIMARY KEY, nama_obat varchar(30) NOT NULL, jenis_obat varchar(15) NOT NULL, harga_obat money NOT NULL, stok_obat int NOT NULL, letak_rak char(3) NOT NULL, ID_supplier char(8) FOREIGN KEY(ID_supplier) REFERENCES Supplier(ID_supplier))", con);
                SqlCommand cm6 = new SqlCommand("create table Transaksi (ID_Transaksi char(12) PRIMARY KEY, ID_pelanggan char(8) FOREIGN KEY(ID_pelanggan) REFERENCES Pelanggan(ID_pelanggan), ID_karyawan char(8) FOREIGN KEY(ID_karyawan) REFERENCES Karyawan(ID_karyawan), tanggal_trx Date NOT NULL, waktu_trx Time NOT NULL, ID_Obat char(8) FOREIGN KEY(ID_obat) REFERENCES Obat(ID_obat), qty int NOT NULL, harga_obat money NOT NULL, total_harga money NOT NULL)", con);

                cm.ExecuteNonQuery();
                cm2.ExecuteNonQuery();
                cm3.ExecuteNonQuery();
                cm4.ExecuteNonQuery();
                cm5.ExecuteNonQuery();
                cm6.ExecuteNonQuery();

                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
