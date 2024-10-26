"""import socket
import threading

# Настройки клиента
SERVER_HOST = '127.0.0.1'  # Адрес сервера
SERVER_PORT = 65432        # Порт сервера

def receive_messages(client_socket):
    while True:
        try:
            message = client_socket.recv(1024).decode('utf-8')
            if not message:
                break
            print(message)
        except:
            print("Ошибка при получении сообщения. Отключаюсь.")
            client_socket.close()
            break

def send_messages(client_socket):
    while True:
        message = input()
        if message.lower() == 'exit':
            client_socket.close()
            break
        client_socket.send(message.encode('utf-8'))

def start_client():
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((SERVER_HOST, SERVER_PORT))
    
    print(f"Подключено к серверу {SERVER_HOST}:{SERVER_PORT}")
    
    receive_thread = threading.Thread(target=receive_messages, args=(client_socket,))
    receive_thread.start()
    
    send_thread = threading.Thread(target=send_messages, args=(client_socket,))
    send_thread.start()

if __name__ == "__main__":
    
    start_client()"""
import socket

client = socket.socket()            # создаем сокет клиента
hostname = socket.gethostname()     # получаем хост локальной машины
port = 12345                        # устанавливаем порт сервера
client.connect((hostname, port))    # подключаемся к серверу
message = input("Input a text: ")   # вводим сообщение
client.send(message.encode())       # отправляем сообщение серверу
data = client.recv(1024)            # получаем данные с сервера
print("Server sent: ", data.decode()) 
client.close()                      # закрываем подключение