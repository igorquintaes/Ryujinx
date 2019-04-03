using Ryujinx.Graphics.Shader.IntermediateRepresentation;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    class AstOperation : AstNode
    {
        public Instruction Inst { get; }

        public IAstNode[] Sources { get; }

        public AstOperation(Instruction inst, params IAstNode[] sources)
        {
            Inst    = inst;
            Sources = sources;
        }
    }
}