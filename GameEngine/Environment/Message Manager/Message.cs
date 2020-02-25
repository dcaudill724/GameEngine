namespace GameEngine{
    public enum MessageType {
        KeyUp,
        KeyDown
    }

    public class Message {
        public MessageType MessageType;
        public object[] Parameters;

        public Message (MessageType messageType, params object[] parameters) {
            MessageType = messageType;
            Parameters = parameters;
        }
    }
}