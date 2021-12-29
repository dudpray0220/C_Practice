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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 라벨 설정
            label5.Text = DataManager.Books.Count.ToString();
            label6.Text = DataManager.Users.Count.ToString();
            label7.Text = DataManager.Books.Where((x) => x.isBorrowed).Count().ToString(); // Where 메서드는 리스트에서 조건에 맞는 대상을 뽑아내는 메서드.
            label8.Text = DataManager.Books.Where((x) =>
            {
                return x.isBorrowed && x.BorrowedAt.AddDays(7) < DateTime.Now;  // 대여기간은 7일. 
            }).Count().ToString();

            // 데이터 그리드 설정
            dataGridView1.DataSource = DataManager.Books;
            dataGridView2.DataSource = DataManager.Users;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            dataGridView2.CurrentCellChanged += DataGridView2_CurrentCellChanged;

            // 버튼 이벤트 설정
            buttonBorrow.Click += ButtonBorrow_Click;
            buttonReturn.Click += ButtonReturn_Click;
        }

        // 그리드의 셀이 선택되면 텍스트 박스에 글자 지정
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
                textBoxIsbn.Text = book.Isbn;
                textBoxBookName.Text = book.Name;
            }
            catch (Exception exception)
            {

            }
        }

        // 그리드의 셀이 선택되면 텍스트 박스에 글자 지정
        private void DataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                User user = dataGridView2.CurrentRow.DataBoundItem as User;
                textBoxUserId.Text = user.Id.ToString();
            }
            catch (Exception exception)
            {

            }
        }
        // 대여 버튼 클릭 로직
        private void ButtonBorrow_Click(object sender, EventArgs e)
        {
            if (textBoxIsbn.Text.Trim() == "")
            {
                MessageBox.Show("Isbn을 입력해주세요!!!");
            }
            else if (textBoxUserId.Text.Trim() == "")
            {
                MessageBox.Show("사용자 ID를 입력해주세요!!!");
            }
            else
            {
                try
                {
                    Book book = DataManager.Books.Single((x) => x.Isbn == textBoxIsbn.Text);
                    if (book.isBorrowed)
                    {
                        MessageBox.Show("이미 대출중인 도서에요");
                    }
                    else
                    {
                        // Single() 메서드는 조건에 맞는 대상 객체 하나를 추출. 조건에 맞는 대상이 없다면 예외가 발생!
                        User user = DataManager.Users.Single((x) => x.Id.ToString() == textBoxUserId.Text);
                        book.UserId = user.Id;
                        book.UserName = user.Name;
                        book.isBorrowed = true;
                        book.BorrowedAt = DateTime.Now;

                        // 그리드를 새로고침하고 XML로 저장하는 코드. 굉장히 자주 반복해서 쓰인다!
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Books;
                        DataManager.Save();

                        MessageBox.Show("\"" + book.Name + "\"이/가\"" + user.Name + "\"님께 대여되었습니다!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("존재하지 않는 도서 또는 사용자입니다.");
                }
            }
        }

        // 반납 버튼 클릭 로직
        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            if (textBoxIsbn.Text.Trim() == "")
            {
                MessageBox.Show("Isbn을 입력해주세요!!!");
            }
            else
            {
                try
                {   // 값을 맞춰주는 로직
                    Book book = DataManager.Books.Single((x) => x.Isbn == textBoxIsbn.Text);
                    if (book.isBorrowed)
                    {
                        User user = DataManager.Users.Single((x) => x.Id.ToString() == book.UserId.ToString());
                        book.UserId = 0;
                        book.UserName = "";
                        book.isBorrowed = false; // 반납버튼 눌렀으니까
                        book.BorrowedAt = new DateTime();

                        // 그리드를 새로고침하고 XML로 저장하는 코드. 굉장히 자주 반복해서 쓰인다!
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Books;
                        DataManager.Save();

                        if (book.BorrowedAt.AddDays(7) > DateTime.Now)
                        {
                            MessageBox.Show("\"" + book.Name + "\"이/가 연체상태로 반납되었습니다...");
                        }
                        else
                        {
                            MessageBox.Show("\"" + book.Name + "\"이/가 반납되었습니다...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("대여상태가 아닙니다!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("존재하지 않는 도서 또는 사용자입니다.");
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog(); // 메뉴를 누르면 새로운 윈도폼을 모달로 출력, 돌아오면 데이터 그리드뷰 새로고침 
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DataManager.Books;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = DataManager.Users;
        }
    }
}
