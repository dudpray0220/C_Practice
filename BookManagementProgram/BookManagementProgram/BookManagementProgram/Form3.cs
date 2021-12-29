using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagementProgram
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            // 데이터 그리드 설정
            dataGridView1.DataSource = DataManager.Users;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            // 추가 버튼 클릭 로직
            buttonAddUser.Click += (sender, e) =>
            {
                try
                {
                    if (DataManager.Users.Exists((x) => x.Id == int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("사용자 ID가 겹쳐!!");
                    }
                    else
                    {
                        User user = new User()
                        {
                            Id = int.Parse(textBox1.Text),
                            Name = textBox2.Text
                        };
                        DataManager.Users.Add(user);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Users;
                        DataManager.Save();
                    }
                }
                catch (Exception)
                {
                }
            };

            // 수정 버튼 클릭 로직
            buttonModifyUser.Click += (sender, e) =>
            {
                try
                {
                    User user = DataManager.Users.Single((x) => x.Id == int.Parse(textBox1.Text));
                    user.Name = textBox2.Text;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Users;
                    DataManager.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("존재하지 않는 사용자야!");
                }
            };

            // 삭제 버튼 클릭 로직
            buttonDeleteUser.Click += (sender, e) =>
            {
                try
                {
                    User user = DataManager.Users.Single((x) => x.Id == int.Parse(textBox1.Text));
                    DataManager.Users.Remove(user);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Users;
                    DataManager.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("존재하지 않는 사용자야!");
                }
            };
        }

        // 그리드의 셀이 선택되면 텍스트 박스에 글자 지정!
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                User user = dataGridView1.CurrentRow.DataBoundItem as User;
                textBox1.Text = user.Id.ToString();
                textBox2.Text = user.Name;
            }
            catch (Exception)
            {

            }
        }
    }
}
