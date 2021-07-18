import socket

client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
server_address = ('localhost', 65535)

data = input("Message: ")
message = data.encode()

try:

    print('This is the message: ', message)
    sent = client_socket.sendto(message, server_address)
    print('Waiting for the message server...')
    data, server = client_socket.recvfrom(4096)
    print('Message: ',data)

finally:
    print('Client disconnected')
    client_socket.close()


