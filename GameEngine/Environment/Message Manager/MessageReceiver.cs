using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
    public class MessageReceiver {
        private Dictionary<MessageType, List<Action<object[]>>> messageActions;

        protected MessageReceiver() {
            MessageManager.AddMessageReceiver(this);
            messageActions = new Dictionary<MessageType, List<Action<object[]>>>();
        }

        protected void AddMessageAction(MessageType messageType, Action<object[]> action) {
            if (messageActions.ContainsKey(messageType)) {
                messageActions[messageType].Add(action);
            } else {
                messageActions.Add(messageType, new List<Action<object[]>>() { action });
            }
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
