using System.Windows.Forms;
using WinFormsApp1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        List<Student> listStudent = new List<Student>();
        Student student;

        string id_student;
        string name_student;
        double score_student;

        int arrayindex = 0;

        bool try_parse_student;
        double[] gpa = { 4.0, 3.5, 3.0, 2.5, 2.0, 1.5, 1.0 };
        double[] all_grade = new double[8];

        int[] n_grade = new int[8];




        public void findmaxscore()
        {
            double maxscore = 0;
            foreach (Student student in listStudent)
            {
                if (student.score > maxscore)
                {
                    maxscore = student.score;
                    textBoxidMax.Text = student.student_ID;
                    textBoxnameMAX.Text = student.name;
                    textBoxscoreMAX.Text = student.score.ToString();
                }



            }
            double min = maxscore;
            foreach (Student student in listStudent)
            {
                if (student.score < min)
                {
                    min = student.score;
                    textBoxMin.Text = student.name;
                    textBoxnamemin.Text = student.student_ID;
                    textBox6.Text = student.score.ToString();
                }
            }


            double sum_list = (double)listStudent.Sum(kku => kku.score);
            textBox7.Text = (sum_list / (double)listStudent.Count).ToString("0.00");

            double current = score_student;
            if (current >= 80 && current <= 100)
            {
                n_grade[0]++;
                //ผลลัพธ์ของคนที่ได้A    ทำการคำนวณค่าน้ำหนักประจำเกรด
                all_grade[0] = (n_grade[0] * gpa[0]);

                textBoxA.Text = n_grade[0].ToString();
            }
            else if (current >= 75 && current <= 79)
            {
                n_grade[1]++;
                //ผลลัพธ์ของคนที่ได้B+    ทำการคำนวณค่าน้ำหนักประจำเกรด
                all_grade[1] = (n_grade[1] * gpa[1]);

                textBoxBPLUS.Text = n_grade[1].ToString();
            }
            else if (current >= 70 && current <= 74)
            {
                n_grade[2]++;
                //ผลลัพธ์ของคนที่ได้B    ทำการคำนวณค่าน้ำหนักประจำเกรด
                all_grade[2] = (n_grade[2] * gpa[2]);
                textBoxB.Text = n_grade[2].ToString();

            }
            else if (current >= 65 && current <= 69)
            {
                n_grade[3]++;
                //ผลลัพธ์ของคนที่ได้C+    ทำการคำนวณค่าน้ำหนักประจำเกรด

                all_grade[3] = (n_grade[3] * gpa[3]);

                textBoxCPLUS.Text = n_grade[3].ToString();
            }
            else if (current >= 60 && current <= 64)
            {
                n_grade[4]++;
                //ผลลัพธ์ของคนที่ได้C    ทำการคำนวณค่าน้ำหนักประจำเกรด

                all_grade[4] = (n_grade[4] * gpa[4]);

                textBoxC.Text = n_grade[4].ToString();
            }
            else if (current >= 55 && current <= 59)
            {
                n_grade[5]++;
                //ผลลัพธ์ของคนที่ได้D+    ทำการคำนวณค่าน้ำหนักประจำเกรด
                all_grade[5] = (n_grade[5] * gpa[5]);

                textBoxDPLUS.Text = n_grade[5].ToString();
            }
            else if (current >= 50 && current <= 54)
            {
                n_grade[6]++;
                //ผลลัพธ์ของคนที่ได้D   ทำการคำนวณค่าน้ำหนักประจำเกรด
                all_grade[6] = (n_grade[6] * gpa[6]);
                textBoxD.Text = n_grade[6].ToString();
            }
            else
            {
                n_grade[7]++;
                //ผลลัพธ์ของคนที่ได้F   ทำการคำนวณค่าน้ำหนักประจำเกรด

                textBoxF.Text = n_grade[7].ToString();

            }
            double Result_gpa = 0.00;
            for (int i = 0; i < all_grade.Length; i++)
            {
                Result_gpa += all_grade[i];
            }
            //ตัวเศษ
            int n_grade_student = listStudent.Count;
            //คำนวณเกรดเฉลี่ย
            double apg = Result_gpa / n_grade_student;
            textBoxGPA.Text = apg.ToString("0.00");
        }


        string inputid;
        string inputname;
        string inputscore;



        private void button1_Click(object sender, EventArgs e) // ปุ่มsave
         {
            inputid = textBoxid.Text;
            inputname = textBoxname.Text;
            inputscore = textBoxscore.Text;

            id_student = inputid;
            name_student = inputname;
            score_student = double.Parse(inputscore);
            arrayindex++;



            Student student = new Student();
            student.name = inputname;
            student.student_ID = inputid;
            student.score = double.Parse(inputscore);

            listStudent.Add(student);


            findmaxscore();


            // คำนวณ GPA
            double gpa = 0;

            double aver = (listStudent.Sum(s => s.score)) / listStudent.Count;
            // แสดงผลลัพธ์
            textBox7.Text = aver.ToString("0.00");
            //textBoxGPA.Text = gpa.ToString("0.00");
        }    
    }
}