using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookManagementProgram
{
    class DataManager
    {
        // 모든 클래스에서 접근할 수 있게 static으로 데이터리스트 만듬. 이렇게 데이터를 모든 클래스에서 접근할 수 있게 만든 리스트를 Static 저장소(Storage) 기술이라고 함.
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();

        static DataManager()
        {
            Load();
        }

        private static void Load()
        {
            try
            {   // 도서 XML을 읽고 파싱
                string booksOutput = File.ReadAllText(@"./Books.xml");
                XElement booksXElement = XElement.Parse(booksOutput);
                Books = (from item in booksXElement.Descendants("book")
                         select new Book()
                         {
                             Isbn = item.Element("isbn").Value,
                             Name = item.Element("name").Value,
                             Publisher = item.Element("publisher").Value,
                             Page = int.Parse(item.Element("page").Value),
                             BorrowedAt = DateTime.Parse(item.Element("borrowedAt").Value),
                             isBorrowed = item.Element("isBorrowed").Value != "0" ? true : false, // 삼항연산자 
                             UserId = int.Parse(item.Element("userId").Value),
                             UserName = item.Element("userName").Value
                         }).ToList<Book>(); // 리스트에 담아준다.

                // 사용자 XML을 읽고 파싱
                string usersOutput = File.ReadAllText(@"./Users.xml");
                XElement usersXElement = XElement.Parse(usersOutput);
                Users = (from item in usersXElement.Descendants("user")
                         select new User()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Name = item.Element("name").Value
                         }).ToList<User>(); // 리스트에 넣어준다.
            }
            catch (FileNotFoundException exception) // 예외 객체, 처음 실행시 Books.xml, Users.xml이 없음. Save() 메서드를 호출해서 빈 XML 파일을 2개 만들어준다.
            {
                Save();
            }
        }

        private static void Save()
        {
            // 도서 정보를 XML로 만듬. (코드 보면 그냥 태그 만들어 주는 것)
            string booksOutput = "";
            booksOutput += "<books>\n";
            foreach (var item in Books) // 리스트 안에서 돌면서
            {
                booksOutput += "<book>\n";
                booksOutput += "    <isbn>" + item.Isbn + "</isbn>\n";
                booksOutput += "    <name>" + item.Name + "</name>\n";
                booksOutput += "    <publisher>" + item.Publisher + "</publisher>\n";
                booksOutput += "    <page>" + item.Page + "</page>\n";
                booksOutput += "    <borrowedAt>" + item.BorrowedAt.ToLongDateString() + "</borrowedAt>\n";
                booksOutput += "    <isBorrowed>" + (item.isBorrowed ? 1 : 0) + "</isBorrowed>\n"; // 삼항연산자 사용
                booksOutput += "    <userId>" + item.UserId + "</userId>\n";
                booksOutput += "    <userName>" + item.UserName + "</userName>\n";
                booksOutput += "</book>\n";
            }
            booksOutput += "</books>";

            // 유저 정보를 XML로 만듬
            string usersOutput = "";
            usersOutput += "<users>\n";
            foreach (var item in Users)
            {
                usersOutput += "<user>\n";
                usersOutput += "    <id>" + item.Id + "</id>\n";
                usersOutput += "    <name>" + item.Name + "</name>\n";
                usersOutput += "</user>\n";
            }
            usersOutput += "</users>";

            // 만든 XML파일을 저장한다.
            File.WriteAllText(@"./Books.xml", booksOutput);
            File.WriteAllText(@"./Users.xml", usersOutput);
        }
    }
}
