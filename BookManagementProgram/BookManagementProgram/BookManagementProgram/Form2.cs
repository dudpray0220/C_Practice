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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // 데이터 그리드 설정
            dataGridView1.DataSource = DataManager.Books;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            // 추가 버튼 클릭 로직
            buttonAdd.Click += (sender, e) => // 람다
            {
                try
                {
                    if (DataManager.Books.Exists((x) => x.Isbn == textBox1.Text))
                    {
                        MessageBox.Show("이미 존재하는 도서입니다!");
                    }
                    else
                    {
                        Book book = new Book() // 클래스로 객체 생성
                        {
                            Isbn = textBox1.Text,
                            Name = textBox2.Text,
                            Publisher = textBox3.Text,
                            Page = int.Parse(textBox4.Text)
                        };
                        DataManager.Books.Add(book);

                        // 새로고침
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Books;
                        DataManager.Save();
                    }
                }
                catch (Exception)
                {
                }
            };

            // 수정 버튼 클릭 로직
            buttonModify.Click += (sender, e) =>
            {
                try
                {
                    Book book = DataManager.Books.Single((x) => x.Isbn == textBox1.Text);
                    book.Name = textBox2.Text;
                    book.Publisher = textBox3.Text;
                    book.Page = int.Parse(textBox4.Text);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Books;
                    DataManager.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("존재하지 않는 도서입니다!");
                }
            };

            // 삭제 버튼 클릭 로직
            buttonDelete.Click += (sender, e) =>
            {
                try
                {
                    Book book = DataManager.Books.Single((x) => x.Isbn == textBox1.Text);
                    DataManager.Books.Remove(book);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Books;
                    DataManager.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("존재하지 않는 도서입니다!");
                }
            };
        }

        // 데이터 그리드의 셀이 선택되면 텍스트 박스에 글자 지정
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
                textBox1.Text = book.Isbn;
                textBox2.Text = book.Name;
                textBox3.Text = book.Publisher;
                textBox4.Text = book.Page.ToString();
            }
            catch (Exception exception)
            {

            }
        }

    }
}
