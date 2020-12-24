using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allotok
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        String URL = "http://localhost/sop/php/index.php";
        String ROUTE = "index.php";



       

        private void delete_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = "index.php/{id}";
            var request = new RestRequest(ROUTE, Method.DELETE);
            request.AddParameter("id", textBox_id.Text);
            IRestResponse response = client.Execute(request);
        }

        private void pull_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.GET);

            IRestResponse<List<Employee>> response = client.Execute<List<Employee>>(request);
            foreach (Employee emp in response.Data)
            {

                string temp;
                string temp2;

                if (emp.lovechrismas == 1)
                {
                    temp = "Igen";
                }
                else
                {
                    temp = "Nem";
                }
                if (emp.lovewinter == 1)
                {
                    temp2 = "Igen";
                }
                else
                {
                    temp2 = "Nem";
                }

                try
                {

                    listBox2.Items.Add("Név: " + char.ToUpper(emp.name[0]) + emp.name.Substring(1) + " --- Osztálya: " + char.ToUpper(emp.classs[0]) + emp.classs.Substring(1) + " --- Szereti a telet: " + temp2 + " --- Szereti a karácsonyt: " + temp + " --- id: " + emp.Id);

                }
                catch (Exception)
                {
                    
                    
                }
   
               
            }

            
        }

        private void pull_id_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = "index.php" + "?id=" + textBox3.Text;
            var request = new RestRequest(ROUTE, Method.GET);

            
            
            
            IRestResponse<List<Employee>> response = client.Execute<List<Employee>>(request);
            foreach (Employee emp in response.Data)
            {
                string temp;
                string temp2;
                
                if (emp.lovechrismas==1)
                {
                    temp = "Igen";
                }
                else
                {
                    temp = "Nem";
                }
                if (emp.lovewinter==1)
                {
                    temp2 = "Igen";
                }
                else
                {
                    temp2 = "Nem";
                }

                try
                {
                    listBox2.Items.Add("Név: " + char.ToUpper(emp.name[0]) + emp.name.Substring(1) + " --- Osztálya: " + char.ToUpper(emp.classs[0]) + emp.classs.Substring(1) + " --- Szereti a telet: " + temp2 + " --- Szereti a karácsonyt: " + temp + " --- id: " + emp.Id);

                }
                catch (Exception)
                {

                    
                }
            }
           
        }

        [Obsolete]
        private void update_Click(object sender, EventArgs e)
        {

            /*
             request.AddBody(new
                        {

                            name = name,
                            classs = classs,
                            lovechrismas = int.Parse(tmp),
                            lovewinter = int.Parse(tmp2)

                        });
             */

            var client = new RestClient(URL);
            String ROUTE = "index.php" + "?id=" + textBox_id.Text;
            var request = new RestRequest(ROUTE, Method.PUT);  //index is kellett mögé
            request.RequestFormat = DataFormat.Json;
            string tmp = textBox_lovechrismas.Text.ToUpper();
            string tmp2 = textBox_lovewinter.Text.ToUpper();
            string name = textBox_name.Text;
            string classs = textBox_classs.Text;

            if (tmp == "IGEN" || tmp == "IGAZ" || tmp == "SZERETI" || tmp == "TRUE" || tmp == "1")
            {

                if (tmp2 == "IGEN" || tmp2 == "IGAZ" || tmp2 == "SZERETI" || tmp2 == "TRUE" || tmp2 == "1")
                {


                    request.AddBody(new
                    {

                        name = name,
                        classs = classs,
                        lovechrismas = 1,
                        lovewinter =1

                    });

                }
                else
                {

                    if (tmp2 == "NEM" || tmp2 == "HAMIS" || tmp2 == "NEM SZERETI" || tmp2 == "FALSE" || tmp2 == "0")
                    {

                        request.AddBody(new
                        {

                            name = name,
                            classs = classs,
                            lovechrismas = 1,
                            lovewinter = 0

                        });



                    }
                    else
                    {
                        MessageBox.Show("Hibás érték! \n Értékek lehetnek:'IGEN','IGAZ' , 'SZERETI' , 'TRUE' ,'NEM', 'HAMIS' , 'NEM SZERETI' , 'FALSE' , '0'\n Nem kis/nagy betű érzékeny \n(TÉL)");


                    }

                }


            }
            else
            {
                if (tmp == "NEM" || tmp == "HAMIS" || tmp == "NEM SZERETI" || tmp == "FALSE" || tmp == "0")
                {

                    if (tmp2 == "IGEN" || tmp2 == "IGAZ" || tmp2 == "SZERETI" || tmp2 == "TRUE" || tmp2 == "1")
                    {

                        request.AddBody(new
                        {

                            name = name,
                            classs = classs,
                            lovechrismas = 0,
                            lovewinter = 1

                        });

                    }
                    else
                    {

                        if (tmp2 == "NEM" || tmp2 == "HAMIS" || tmp2 == "NEM SZERETI" || tmp2 == "FALSE" || tmp2 == "0")
                        {
                            request.AddBody(new
                            {

                                name = name,
                                classs = classs,
                                lovechrismas = 0,
                                lovewinter = 0

                            });
                        }
                        else
                        {

                            MessageBox.Show("Hibás érték! \n Értékek lehetnek:'IGEN','IGAZ' , 'SZERETI' , 'TRUE' ,'NEM', 'HAMIS' , 'NEM SZERETI' , 'FALSE' , '0'\n Nem kis/nagy betű érzékeny \n(TÉL)");

                        }


                    }

                }


                else
                {

                    MessageBox.Show("Hibás érték! \n Értékek lehetnek:'IGEN','IGAZ' , 'SZERETI' , 'TRUE' ,'NEM', 'HAMIS' , 'NEM SZERETI' , 'FALSE' , '0'\n Nem kis/nagy betű érzékeny \n(Karácsony)");

                }


            }


            IRestResponse response = client.Execute(request);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void add_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.POST);  //index is kellett mögé
            request.RequestFormat = DataFormat.Json;
            string tmp = textBox_lovechrismas.Text.ToUpper();
            string tmp2= textBox_lovewinter.Text.ToUpper();
            string name = textBox_name.Text;
            string classs = textBox_classs.Text;



            
             
             /*
             request.AddBody(new
                        {

                            name = name,
                            classs = classs,
                            lovechrismas = int.Parse(tmp),
                            lovewinter = int.Parse(tmp2)

                        });
             */
             

            if (tmp == "IGEN" || tmp =="IGAZ"||tmp=="SZERETI"||tmp=="TRUE" || tmp == "1")
            {
                
                if (tmp2 == "IGEN" || tmp2 == "IGAZ" || tmp2 == "SZERETI" || tmp2 == "TRUE"||tmp2 == "1")
                {


                    request.AddBody(new
                    {

                        name = name,
                        classs = classs,
                        lovechrismas = 1,
                        lovewinter = 1

                    });

                }
                else
                {

                    if (tmp2 == "NEM" || tmp2 == "HAMIS" || tmp2 == "NEM SZERETI" || tmp2 == "FALSE" || tmp2 == "0")
                    {

                        request.AddBody(new
                        {

                            name = name,
                            classs = classs,
                            lovechrismas = 1,
                            lovewinter = 0

                        });



                    }
                    else
                    {
                        MessageBox.Show("Hibás érték! \n Értékek lehetnek:'IGEN','IGAZ' , 'SZERETI' , 'TRUE' ,'NEM', 'HAMIS' , 'NEM SZERETI' , 'FALSE' , '0'\n Nem kis/nagy betű érzékeny \n(TÉL)");


                    }

                }


            }
            else
            {
                if (tmp == "NEM" || tmp == "HAMIS" || tmp == "NEM SZERETI" || tmp == "FALSE"|| tmp == "0")
                {

                    if (tmp2 == "IGEN" || tmp2 == "IGAZ" || tmp2 == "SZERETI" || tmp2 == "TRUE"|| tmp2 == "1")
                    {

                        request.AddBody(new
                        {

                            name = name,
                            classs = classs,
                            lovechrismas = 0,
                            lovewinter = 1

                        });

                    }
                    else
                    {

                        if (tmp2 == "NEM" || tmp2 == "HAMIS" || tmp2 == "NEM SZERETI" || tmp2 == "FALSE" || tmp2 == "0")
                        {
                            request.AddBody(new
                            {

                                name = name,
                                classs = classs,
                                lovechrismas = 0,
                                lovewinter = 0

                            });
                        }
                        else
                        {

                            MessageBox.Show("Hibás érték! \n Értékek lehetnek:'IGEN','IGAZ' , 'SZERETI' , 'TRUE' ,'NEM', 'HAMIS' , 'NEM SZERETI' , 'FALSE' , '0'\n Nem kis/nagy betű érzékeny \n(TÉL)");
                            
                        }


                    }

                }


                else
                {

                    MessageBox.Show("Hibás érték! \n Értékek lehetnek:'IGEN','IGAZ' , 'SZERETI' , 'TRUE' ,'NEM', 'HAMIS' , 'NEM SZERETI' , 'FALSE' , '0'\n Nem kis/nagy betű érzékeny \n(Karácsony)");

                }


            }

            


            IRestResponse response = client.Execute(request);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        
    }
    public class Employee
    {
        public String Id { get; set; }
        public string name { get; set; }
        public string classs { get; set; }

        public byte lovewinter { get; set; }
        public byte lovechrismas { get; set; }
    }
}
