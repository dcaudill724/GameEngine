using System;
using System.Collections.Generic;

namespace GameEngine {
    public class MessageReceiver {
        private Dictionary<MessageType, List<Action<object[]>>> messageActions;

        protected MessageReceiver() {
            messageActions = new Dictionary<MessageType, List<Action<object[]>>>();
        }

        protected void AddMessageAction(MessageType messageType, Action<object[]> action) {
            Console.WriteLine("Adddeedddd");
            //getting here but cube message isn't firing
            if (messageActions.ContainsKey(messageType)) {
                messageActions[messageType].Add(action);
            } else {
                messageActions.Add(messageType, new List<Action<object[]>>() { action });
            }
        }

        protected void Delete() {
            MessageManager.RemoveMessageReceiver(this);
        }

        public void HandleMessage (Message message) {
            if (messageActions.ContainsKey(message.MessageType)) {
                List<Action<object[]>> currentMessageActions = messageActions[message.MessageType];
                foreach (Action<object[]> a in currentMessageActions) {
                    a(message.Parameters);
                }
            }
        }
    }
}
