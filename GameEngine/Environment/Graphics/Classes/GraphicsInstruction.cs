namespace GameEngine {
    public enum GraphicsInstructions {
        DrawLine,
        DrawTriangle,
        FillTriangle
    }

    public class GraphicsInstruction {
        public GraphicsInstructions Instruction;
        public object[] Parameters;

        public GraphicsInstruction(GraphicsInstructions instruction, params object[] parameters) {
            Instruction = instruction;
            Parameters = parameters;
        }
    }
}
