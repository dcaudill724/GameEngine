using System;
using System.Collections.Generic;

namespace GameEngine {
    public static class MessageManager {
        private static List<MessageReceiver> messageReceivers;

        public static void Init() {
            messageReceivers = new List<MessageReceiver>();
        }

        public static void SendMessage(Message message) {
            foreach (MessageReceiver mr in messageReceivers) {
                mr.HandleMessage(message);
            }
        }

        public static void AddMessageReceiver(MessageReceiver messageReceiver) {
            messageReceivers.Add(messageReceiver);
        }

        public static void RemoveMessageReceiver(MessageReceiver messageReceiver) {
            messageReceivers.Remove(messageReceiver);
        }
    }
}
