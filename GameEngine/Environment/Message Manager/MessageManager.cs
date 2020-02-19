using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
    public static class MessageManager {
        private static List<MessageReceiver> messageReceivers;
        private static List<Message> outgoingMessages;

        public static void Init() {
            messageReceivers = new List<MessageReceiver>();
        }

        public static void DistributeMessages() {
            foreach (MessageReceiver mr in messageReceivers) {
                foreach (Message m in outgoingMessages) {
                    mr.HandleMessage(m);
                }
            }
            outgoingMessages.Clear();
        }

        public static void SendMessage(Message message) {
            outgoingMessages.Add(message);
        }

        public static void AddMessageReceiver(MessageReceiver messageReceiver) {
            messageReceivers.Add(messageReceiver);
        }
    }
}
