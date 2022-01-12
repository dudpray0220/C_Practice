using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConsoleUdpChatServer
{
    public class MainServer
    {
        ClientManager _clientManager = null;
        ConcurrentBag<string> chattingLog = null;   // ConcurrentBag : 스레드로부터 안전한 정렬되지 않은 개체 컬렉션을 나타냅니다.
        ConcurrentBag<string> accessLog = null;
        Thread connectCheckThread = null;

        // 생성자 (1. ClientManager 객체 생성 / 2. 채팅로그, 접속로그 컬렉션 생성 / 3. 서버 스레드, 하트비트 스레드 시작 
        public MainServer()
        {
            _clientManager = new ClientManager();
            chattingLog = new ConcurrentBag<string>();
            accessLog = new ConcurrentBag<string>();
        }

        // 하트비트 스레드 메서드
        private void ConnectCheckLoop()
        {
            while (true)
            {
    
            }
        }
    }
