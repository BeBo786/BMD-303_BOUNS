using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _303_Task1
{
    public partial class Form1 : Form
    {
        DATABASE fn = new DATABASE();
        String query;
        string query2;
        DataSet ds;
        DataSet ds2;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                query = "select * from users where lname ='" + txtName.Text + "'";
                query2 = "select * from users where fname ='" + txtName.Text + "'";
                
                ds = fn.GetData(query);
                ds2= fn.GetData(query2);
                if (ds.Tables[0].Rows.Count != 0 )
                {
                    
                    string s = "select datediff(YEAR,DOB, getdate()) from users WHERE lname ='" + txtName.Text + "'";
                   
                    DataSet d2 = fn.GetData(s);

                    lblsta.Text = "found";
                    label5.Text= d2.Tables[0].Rows[0][0].ToString();


                    


                }
                else if (ds2.Tables[0].Rows.Count != 0)
                {
                    string q = "select datediff(YEAR,DOB, getdate()) from users WHERE fname ='" + txtName.Text + "'";
                    DataSet d = fn.GetData(q);
                    lblsta.Text = "found";
                    label5.Text = d.Tables[0].Rows[0][0].ToString();

                }
                else

                {
                    lblsta.Text = "not found";
                    label5.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Enter Name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           

            
        }
    }
}
