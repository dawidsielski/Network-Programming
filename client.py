"""
Author: Dawid Sielski 18.10.2017r.
"""
import socket
import sys

soc = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

HOST = 'localhost'

try:
    soc.connect((socket.gethostbyname(HOST), 40000))
    print(socket.gethostbyname(HOST))
except OverflowError:
    print("Port number is too large or two low.")
except Exception as e:
    print(e)
    sys.exit()

while True:
    clients_input = input("Enter your message:\n")
    if not clients_input:
        break

    try: 
        soc.send(clients_input.encode("utf8"))
    except Exception as error:
        print(error)

    try:
        result_bytes = soc.recv(1024)
    except InterruptedError as error:
        print("Socket interruption.")
        print(error)

    result_string = result_bytes.decode("utf8")

    print("Result from server is {}".format(result_string))

print("Disconnected.")
soc.close()