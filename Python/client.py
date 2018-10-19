import argparse

from pythonosc import udp_client


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--ip", default="127.0.0.1", help="The ip of the OSC server")
    parser.add_argument("--port", type=int, default=5005, help="The port the OSC server is listening on")
    args = parser.parse_args()

    client = udp_client.SimpleUDPClient(args.ip, args.port)

    client.send_message("/volume", 0.1)
    client.send_message("/volume", "Hello")
    client.send_message("/volume", [1, 2, 3])
    client.send_message("/volume", {"one": 1, "two": 2})
