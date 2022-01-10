using System;

namespace BuilderPattern01
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoreBuilder scoreBuilder = new ScoreBuilder();
            scoreBuilder.SetKor(100).SetEng(50).SetMat(100);
            scoreBuilder.PrintBuild();
        }
    }
    // StudentScore Class
    public class StudentScore
    {
        public int Mat;
        public int Eng;
        public int Kor;
        public int Soc;
        public int Sci;
        // 생성자 -> 이렇게 쓸 경우 상당히 실수하기 쉽고, 변경이 어렵다!
        public StudentScore(int mat, int eng, int kor, int soc, int sci)
        {
        }
    }

    // -----------------------------------------------------------------------------------------------------------------------------------------------------------

    // Builder Class
    public class ScoreBuilder
    {
        private StudentScore studentScore; // 인스턴스 변수선언

        // ScoreBuilder 생성시 StudentScore가 같이 생성됨.
        public ScoreBuilder() // 생성자
        {
            studentScore = new StudentScore(0, 0, 0, 0, 0);
        }

        // 생성된 studentScore 출력하는 메서드
        public void PrintBuild()
        {
            Console.WriteLine(studentScore.Kor + ", " + studentScore.Mat + ", " + studentScore.Eng);
        }

        // 메서드들 (하나씩 과목점수 설정 가능! -> 수정 용이!)
        public ScoreBuilder SetMat(int value)
        {
            studentScore.Mat = value;
            return this; // 값 넣으면 studentScore에 값이 들어간 상태로 있나, 아님 0인 상태인가 모르겠음
        }
        public ScoreBuilder SetKor(int value)
        {
            studentScore.Kor = value;
            return this;
        }
        public ScoreBuilder SetEng(int value)
        {
            studentScore.Eng = value;
            return this;
        }
    }
}
