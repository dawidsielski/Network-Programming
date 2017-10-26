"""
Author: Dawid Sielski 18.10.2017r.
"""
import socket
import sys
import threading

HOST = '127.0.0.1'
PORT = 40000

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
print ('Socket created')

try:
    s.bind(('', PORT))
except socket.error as msg:
    print ('Bind failed. Error Code : ' + str(msg[0]) + ' Message ' + msg[1])
    sys.exit()

print ('Socket bind complete')

s.listen(10)
print ('Socket now listening')


def client_thread(conn):
    conn.send('Welcome to the server. Type something and hit enter\n'.encode('utf8'))

    while True:
        try:
            data = conn.recv(1024)
        except ConnectionResetError:
            break

        reply = 'Message: ' + data.decode('utf8')
        if not data:
            break

        conn.sendall(reply.encode('utf8'))
    conn.close()

while True:
    conn, addr = s.accept()
    print ('Connected with ' + addr[0] + ':' + str(addr[1]))

    th = threading.Thread(target=client_thread, args=(conn,))
    th.start()


s.close()