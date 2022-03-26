using System;
using System.Collections.Generic;

namespace Item12_70page
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass2 some = new MyClass2(2);
        }
    }

    class MyClass // 좋은 예
    {
        // 생성자 안에서 초기화x 선언 당시 초기화하는 것이 좋음
        private List<int> list = new List<int>();
    }

    public class MyClass2 // 나쁜 예
    {
        // 이미 메모리 블록을 0으로 설정하기에 굳이 0으로 초기화할 필요는 없음
        private int a = 0;

        private List<int> list;

        public MyClass2()
        {
            list = new List<int>();
        }

        public MyClass2(int size)
        {
            // 이렇게 생성자 별로 다르게 초기화 하는 경우에는 사용하지 않는 게 좋음
            list = new List<int>(size);
        }
    }
}
